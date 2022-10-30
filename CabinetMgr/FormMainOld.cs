using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CabinetMgr.BLL;
using CabinetMgr.Common;
using CabinetMgr.Config;
using CabinetMgr.RtVars;
using Domain.Main.Domain;
using Hardware.DeviceInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using OpenCvSharp;
using Sunny.UI;
using SuperSocket.SocketBase;
using testface;
using Utilities.FileHelper;
using Size = System.Drawing.Size;

// ReSharper disable FunctionNeverReturns
// ReSharper disable UnusedMember.Local
// ReSharper disable LocalizableElement

namespace CabinetMgr
{
    public partial class FormMainOld : Form
    {
        private Form _curForm;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private Form _indexForm;
        private Form _recordForm;
        private Form _toolManageForm;
        private Form _userManageForm;

        SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("Alarm"));
        SoundPlayer loginSound = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("LoginSuccess"));

        public static ManualResetEvent userLoginManualEvent = new ManualResetEvent(true);
        public static ManualResetEvent FaceDataManualEvent = new ManualResetEvent(false);

        private List<UserInfo> imagesFeatureList = new List<UserInfo>();
        //private List<UserInfo> imagesFeatureRecordList = new List<UserInfo>();
        private float threshold = 80f;
        private MemoryStream stream = new MemoryStream();

        public FormMainOld()
        {
            InitializeComponent();
            FpCallBack.OnUserRecognised = OnUserRecognised;
            CabinetServerCallback.BorrowReturnCmd += BorrowReturnCmd;
            CabinetServerCallback.NewSessionConnected += NewSessionConnected;
            CabinetServerCallback.SessionClosed += SessionClosed;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            CenterToScreen();

            FormDeviceLoaderOld dlForm = new FormDeviceLoaderOld();
            dlForm.ShowDialog();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            //加载窗口       
            InitForm();

            ShowWindow(_indexForm);

            ////保证UHF预扫描时间
            //tmUhfInit.Enabled = true;

            //InitAlarmThread();

            InitFaceData();
            InitFaceCricThread();
            InitFpData();
            InitFpCricThread();
        }

        private void JsonStrParsed(string parseStr)
        {
            AppRt.FormLog.AddLine(parseStr);
        }

        private void BorrowReturnCmd(AppSession session, string cmd)
        {
            if(AppRt.CurUser == null)
            {
                UIMessageBox.Show("请先登录再申请借还");
                return;
            }
            var value = cmd.Replace($"\\", "").Replace("{","").Replace("}","").Replace($"\"","");
            string[] cmdAry = value.Split(',');
            bool success = true;
            foreach(string cmdStr in cmdAry)
            {
                if (string.IsNullOrEmpty(cmdStr)) continue;
                var toolLocation = cmdStr.Split(":")[0];
                var cmdType = cmdStr.Split(":")[1];
                int result = ExecuteCmd(toolLocation, cmdType);
                if (result <= 0) success = false;
            }
            session.Send(JsonConvert.SerializeObject($"{{\"success\":{success}}}"));
            (_indexForm as FormIndexOld).ReloadData();
            (_indexForm as FormIndexOld).LoadPage();
        }

        private int ExecuteCmd(string toolLocation, string cmdType)
        {
            string[] locationParam = toolLocation.Split('-');
            string labName = locationParam[0];
            int labLocation = int.Parse(locationParam[1]);
            string cabinetNum = locationParam[2];
            string cabinetLatticeNum = locationParam[3];
            string toolCode = locationParam[4];
            LatticeInfo lattice = BllLatticeInfo.GetLatticeInfo(labName, labLocation, cabinetNum, cabinetLatticeNum, out Exception ex);
            if (lattice == null) return -1;
            ToolInfo ti = BllToolInfo.GetToolInfo(lattice.Id, toolCode, out ex);
            if (ti == null) return -1;
            switch (cmdType)
            {
                case "0":
                    return BllBorrowRecord.AddBorrowRecord(ti, AppRt.CurUser, out ex);
                
                case "1":
                    return BllReturnRecord.AddReturnRecord(ti, AppRt.CurUser, out ex);
                default:
                    return -1;
            }
            
        }

        private void NewSessionConnected(AppSession session)
        {
            AppRt.FormLog.AddLine($"{session.RemoteEndPoint.Address}:{session.RemoteEndPoint.Port} Connected");
        }

        private void SessionClosed(AppSession session, SuperSocket.SocketBase.CloseReason reason)
        {
            AppRt.FormLog.AddLine($"{session.RemoteEndPoint.Address}:{session.RemoteEndPoint.Port} Closed.");
            AppRt.FormLog.AddLine($"The Reason Is {reason}.");
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// 1.指纹 2.人脸  3.工卡
        public void OnUserRecognised(long templateId, int method)
        {
            try
            {
                UserInfo loginUser = BllUserInfo.GetUserInfoByTemplate(templateId, out var e);
                if (loginUser != null)
                {
                    IList<RoleSettings> roleSettings = BllRoleSettings.GetUserRoleSettings(loginUser.ID, out e);
                    string[] roleAry = roleSettings.Select(x => x.RoleId).ToArray();
                    IList<RoleInfo> RoleList = new List<RoleInfo>();
                    foreach (RoleSettings rs in roleSettings)
                    {
                        RoleInfo ri = BllRoleInfo.GetRoleInfo(rs.RoleId, out e);
                        RoleList.Add(ri);
                    }
                    long[] latticePermissionList = BllLatticePermissionSettings.GetLatticePermissionList(loginUser.ID, roleAry, out e);
                    IList<LatticeInfo> LatticeList = BllLatticeInfo.GetLatticeInfoList(latticePermissionList, out e);

                    AppRt.CurUser = loginUser;
                    AppRt.RoleList = RoleList;
                    AppRt.RoleSettings = roleSettings;
                    AppRt.LatticeList = LatticeList;

                    if (AppRt.RoleSettings.FirstOrDefault(x => x.RoleId == PresetRole.Admin) != null) SetPbVisible(true, pictureBoxSystem);

                    loginSound.Play();
                    DisplayUser((AppRt.CurUser.FullName ?? "") + "(单击退出)");
                    //ShowWindow(_toolReportForm);
                    //userLoginManualEvent.Reset();

                    //AppRt.IsNeedAlarm = true;
                    //AppRt.gUserLoginTime = DateTime.Now;
                    //AppRt.IsAlarmed = false;

                    //IList<RoleInfo> roleList = AppRt.RoleList;
                    //if (roleList == null)
                    //{
                    //    IList<RoleSettings> rsList = BllRoleSettings.GetUserRoleSettings(loginUser.ID);
                    //    IList<RoleInfo> RoleList = new List<RoleInfo>();
                    //    foreach (RoleSettings rs in rsList)
                    //    {
                    //        RoleInfo ri = BllRoleInfo.GetRoleInfo(rs.RoleId, out Exception ex);
                    //        RoleList.Add(ri);
                    //    }
                    //    AppRt.RoleList = RoleList;
                    //    roleList = RoleList;
                    //}
                    //foreach (RoleInfo ri in roleList)
                    //{
                    //    if (ri.RoleName.Contains("管理员"))
                    //    {
                    //        SetPbVisible(true, pbSetting);
                    //        break;
                    //    }
                    //}
                    //SetPbVisible(true, pbAuthority);
                    //userLoginManualEvent.Set();
                }
            }
            catch(Exception ex)
            {

            }

        }

        #region Face

        private void InitFaceCricThread()
        {
            Thread t = new Thread(FaceCric) { IsBackground = true };
            t.Start();
            //Thread t2 = new Thread(GetCameraPic) { IsBackground = true };
            //t2.Start();
        }

        private void InitFaceData()
        {
            IList<UserInfo> listUserInfo = BllUserInfo.SearchUserInfo(0, -1, null, out _);
            if (listUserInfo == null || listUserInfo.Count == 0) return;
            imagesFeatureList.Clear();
            for (int i = 0; i < listUserInfo.Count; i++)
            {
                UserInfo userInfo = listUserInfo[i];
                //userInfo.FaceFeature特征值转换为float数组
                if (userInfo.FaceFeature != null)
                {
                    float[] FaceFeature = GetFloat(userInfo.FaceFeature);

                    BDFaceFeature bdFaceFeature = new BDFaceFeature();
                    bdFaceFeature.size = FaceFeature.Length;
                    bdFaceFeature.data = FaceFeature;
                    userInfo.BDFaceFeature = bdFaceFeature;
                }
                imagesFeatureList.Add(userInfo);
            }

            FaceDataManualEvent.Set();
        }

        private float[] GetFloat(byte[] b)
        {
            byte[] b1 = new byte[4];
            float[] fat = new float[b.Length / 4];
            int c = 0;
            for (int i = 0; i < b.Length; i = i + 4)
            {
                Buffer.BlockCopy(b, i, b1, 0, 4);
                float f = BitConverter.ToSingle(b1, 0);
                fat[c] = f;
                b1 = new byte[4];
                c++;
            }
            return fat;
        }

        private UserInfo compareFeature(BDFaceFeature feature, out float similarity)
        {
            UserInfo result = null;
            similarity = 0f;
            FaceCompare faceCompare = new FaceCompare();
            //如果人脸库不为空，则进行人脸匹配
            if (imagesFeatureList != null && imagesFeatureList.Count > 0)
            {
                for (int i = 0; i < imagesFeatureList.Count; i++)
                {
                    if (imagesFeatureList[i].BDFaceFeature == null) continue;
                    if (((BDFaceFeature)imagesFeatureList[i].BDFaceFeature).size == 0)
                    {
                        return result;
                    }

                    BDFaceFeature bdFaceFeature = (BDFaceFeature)imagesFeatureList[i].BDFaceFeature;

                    similarity = faceCompare.CompareFaceFeature(ref feature, ref bdFaceFeature);

                    if (similarity >= threshold)
                    {
                        result = imagesFeatureList[i];
                        return result;
                    }
                }
            }
            return result;
        }

        private void FaceCric()
        {
            try
            {
                FaceDataManualEvent.WaitOne();
                VideoCapture cap = AppRt.VideoCaptureDevice;
                FaceFeature faceFeature = new FaceFeature();

                Mat image = new Mat();
                while (!AppRt.IsInit)
                {
                    if (Visible == false) continue;
                    if (cap == null) continue;
                    cap.Read(image);
                    if (!image.Empty())
                    {
                        int ilen = 20;//传入的人脸数
                        BDFaceBBox[] info = new BDFaceBBox[ilen];

                        int sizeTrack = Marshal.SizeOf(typeof(BDFaceBBox));
                        IntPtr ptT = Marshal.AllocHGlobal(sizeTrack * ilen);

                        int faceSize = ilen;//返回人脸数  分配人脸数和检测到人脸数的最小值
                        int curSize = ilen;//当前人脸数 输入分配的人脸数，输出实际检测到的人脸数
                        int type = 0;
                        faceSize = FaceDetect.detect(ptT, image.CvPtr, type);
                        if (faceSize > 0)
                        {
                            //lock (fileLock)
                            //{
                            //    if (File.Exists("detect.bmp"))
                            //    {
                            //        File.Delete("detect.bmp");
                            //    }
                            //    image.SaveImage("detect.bmp");

                            //    FaceFeature faceFeature = new FaceFeature();
                            //    BDFaceFeature[] ff = faceFeature.test_get_face_feature_by_path("detect.bmp");
                            //    UserInfo ui = compareFeature(ff[0], out float similarity);
                            //    if (ui != null && !AppRt.CollectFace)
                            //    {
                            //        File.Delete("detect.bmp");
                            //        SetPbBG(picBFace, (Bitmap)Base64StringToImage(ui.Images));
                            //        SetPbVisible(picBFace, true);
                            //        timer1.Enabled = false;
                            //        FpCallBack.OnUserRecognised?.Invoke(ui.TemplateUserId, 1);
                            //    }
                            //}

                            BDFaceFeature[] ff = faceFeature.test_get_face_feature_by_path(image);
                            UserInfo ui = compareFeature(ff[0], out float similarity);
                            if (ui != null)
                            {
                                //SetPbBG(picBFace, (Bitmap)Base64StringToImage(ui.Images));
                                //SetPbVisible(picBFace, true);
                                //timer1.Enabled = false;
                                FpCallBack.OnUserRecognised?.Invoke(ui.TemplateId, 2);
                            }
                        }

                        Thread.Sleep(1000);

                        //FaceDraw.draw_shape(ref image, faceSize, track_info);
                        Marshal.FreeHGlobal(ptT);
                        Cv2.WaitKey(1);

                    }
                    else
                    {

                    }
                }
            }
            catch (SEHException e)
            {
                Logger.Error(e);
            }
        }

        #endregion

        #region Finger

        private void InitFpData()
        {
            IList<UserInfo> listUserInfo = BllUserInfo.SearchUserInfo(0, -1, null, out _);
            if (listUserInfo == null || listUserInfo.Count == 0) return;
            bool isAllSucceed = true;
            foreach (UserInfo ui in listUserInfo)
            {
                //if (!ui.HasFingerFeature) continue;
                //int ret = FpDevice.DownChar(ui.FingerFeature);
                //if (ret != DriveOpration.PS_OK) isAllSucceed = false;
                //ret = FpDevice.StoreChar((int)ui.TemplateId);
                //if (ret != DriveOpration.PS_OK) isAllSucceed = false;
            }
            if(!isAllSucceed) SetLabelText(uiLabelErrInfo, "指纹下发出错，部分指纹将不能使用");
        }

        private void InitFpCricThread()
        {
            Thread t = new Thread(FpCric) { IsBackground = true };
            t.Start();
        }

        private void FpCric()
        {
            int address = -1, score = 0;
            while(true)
            {
                Thread.Sleep(300);
                if (AppRt.IsInit || !AppRt.FpEnable) continue;
                int ret = FpDevice.GetImage();
                if (ret != DriveOpration.PS_OK) continue;
                ret = FpDevice.GenChar(1);
                if (ret != DriveOpration.PS_OK) continue;
                ret = FpDevice.SearchFeature(ref address, ref score);
                if(ret == DriveOpration.PS_OK)
                {
                    FpCallBack.OnUserRecognised?.Invoke(address, 1);
                }
            }
        }

        #endregion

        #region ShowForms

        private void uiButtonIndex_Click(object sender, EventArgs e)
        {
            ShowWindow(_indexForm);
        }

        private void uiButtonUserManage_Click(object sender, EventArgs e)
        {
            if (AppRt.CurUser == null)
            {
                UIMessageBox.Show("请先进行登录");
                return;
            }
            ShowWindow(_userManageForm);
        }

        private void uiButtonToolManage_Click(object sender, EventArgs e)
        {
            if(AppRt.CurUser == null)
            {
                UIMessageBox.Show("请先进行登录");
                return;
            }
            ShowWindow(_toolManageForm);
        }

        private void uiButtonRecord_Click(object sender, EventArgs e)
        {
            if (AppRt.CurUser == null)
            {
                UIMessageBox.Show("请先进行登录");
                return;
            }
            ShowWindow(_recordForm);
        }

        #endregion

        #region pbClick


        private void pbKeyboard_Click(object sender, EventArgs e)
        {
            Osk.ShowInputPanel();
        }

        private void pictureBoxQuit_Click(object sender, EventArgs e)
        {
            if (UIMessageBox.Show("真的要退出程序吗？", "", buttons: UIMessageBoxButtons.OKCancel, showMask: true, topMost: true))
            {
                AppRt.VideoCaptureDevice.Dispose();
                GC.Collect();
                Environment.Exit(0);
            }
        }

        private void pictureBoxSystem_Click(object sender, EventArgs e)
        {
            FormSystemOld formSystem = FormSystemOld.Instance();
            formSystem.ShowDialog();
        }

        #endregion

        #region ControlDelegate

        private delegate void SetPbVisibleDelegate(bool visible, PictureBox pb);
        public void SetPbVisible(bool visible, PictureBox pb)
        {
            try
            {
                if (pb.InvokeRequired)
                {
                    SetPbVisibleDelegate d = SetPbVisible;
                    pb.Invoke(d, visible, pb);
                }
                else
                {
                    pb.Visible = visible;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private delegate void FormVisibleDelegate(bool visible, Form form);
        public void FormVisible(bool visible, Form form)
        {
            try
            {
                if (form.InvokeRequired)
                {
                    FormVisibleDelegate d = FormVisible;
                    form.Invoke(d, visible, form);
                }
                else
                {
                    if (visible)
                    {
                        form.Show();
                    }
                    else
                    {
                        form.Hide();
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public delegate void SetLabelTextDelegate(Label label, string text);
        public void SetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                SetLabelTextDelegate d = SetLabelText;
                label.Invoke(d, label, text);
            }
            else
            {
                label.Text = text;
                label.Visible = true;
            }
        }

        private delegate void UpdateTextDelegate(string text);
        public void DisplayUser(string userName)
        {
            try
            {
                if (uiLabelUser.InvokeRequired)
                {
                    UpdateTextDelegate d = DisplayUser;
                    uiLabelUser.Invoke(d, userName);
                }
                else
                {
                    uiLabelUser.Text = "当前用户: \n" + userName;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        #endregion

        public void ShowWindow(Form targetForm)
        {
            if (_curForm == targetForm)
            {
                return;
            }
            //AppRt.CollectFace = false;
            foreach (var form in panelWindow.Controls)
            {
                var curForm = form as Form;
                if (curForm != null)
                {
                    FormVisible(false, curForm);
                    //curForm.Hide();
                }
            }
            if (targetForm.Tag != null)
            {
                int selectedBtn = int.Parse(targetForm.Tag.ToString());
                foreach (var btn in panelTop.Controls)
                {
                    if (btn is UIButton curBtn)
                    {
                        if (int.TryParse(curBtn.Tag.ToString(), out var btnTag))
                        {
                            if (btnTag != selectedBtn) curBtn.Selected = false;
                            else curBtn.Selected = true;
                            //if (btnTag != selectedBtn) curBtn.BackgroundImage = _btnSelected[btnTag];
                            //else curBtn.BackgroundImage = _btnNormal[btnTag];
                        }
                    }
                }
            }
            _curForm = targetForm;
            FormVisible(true, targetForm);
        }

        private void InitForm()
        {
            try
            {

                _indexForm = new FormIndexOld();
                AddToPanel(_indexForm);

                _recordForm = new FormRecordOld();
                AddToPanel(_recordForm);

                _toolManageForm = new FormToolManageOld();
                AddToPanel(_toolManageForm);

                _userManageForm = new FormUserManageOld();
                AddToPanel(_userManageForm);

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private void AddToPanel(Form targetForm)
        {
            targetForm.TopLevel = false;
            targetForm.Width = panelWindow.Width;
            targetForm.Height = panelWindow.Height;
            panelWindow.Controls.Add(targetForm);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {

            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

            //panelTop.Width = Width;
            //panelWindow.Width = Width;
            //panelWindow.Height = Height - 350;
            //lbUserName.Left = Width - 200;
            //pbAvatar.Left = lbUserName.Left - pbAvatar.Width - 12;
        }

        private void panelWindow_SizeChanged(object sender, EventArgs e)
        {
            if (_curForm != null)
            {
                _curForm.Width = panelWindow.Width;
                _curForm.Height = panelWindow.Height;
            }
        }


        private void tmUhfInit_Tick(object sender, EventArgs e)
        {
            //lbInitTime.Text = "启动中,剩余:" + Env.UhfDelay + "秒";
            //Env.UhfDelay--;
            //if (Env.UhfDelay <= 0)
            //{
            //    AppRt.IsInit = false;
            //    tmUhfInit.Enabled = false;
            //    lbInitTime.Text = "";
            //}
        }

        private void uiLabelUser_Click(object sender, EventArgs e)
        {
            PerformManualLogin();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Alt && e.KeyCode == Keys.A)
            {
                OnUserRecognised(2, 2);
                return;
            }
            //if (e.Shift && e.Alt && e.KeyCode == Keys.F2)
            //{
            //    OnUserRecognised(1878, 100);
            //    return;
            //}
            if (e.Shift && e.Alt && e.KeyCode == Keys.R)
            {
                BllBorrowRecord.DeleteAll(out Exception ex);
                BllReturnRecord.DeleteAll(out ex);
                BllRoleInfo.DeleteAll(out ex);
                BllLatticeInfo.DeleteAll(out ex);
                BllLatticePermissionSettings.DeleteAll(out ex);
                BllToolInfo.DeleteAll(out ex);
                BllToolType.DeleteAll(out ex);
                BllUserInfo.DeleteAll(out ex);
                //清除登录状态
                PerformManualLogin();

                //窗口刷新
                ShowWindow(_indexForm);
                MessageBox.Show("重置完成");
                return;
            }
            //if (e.Shift && e.Alt && e.KeyCode == Keys.F12)
            //{
            //    FormDeviceDebug dbForm = new FormDeviceDebug();
            //    dbForm.Show();
            //    return;
            //}
            //if (e.Shift && e.Alt && e.KeyCode == Keys.N)
            //{
            //    FormUserInfoCollect dbForm = new FormUserInfoCollect();
            //    dbForm.Show();
            //    return;
            //}
            if (e.Shift && e.Alt && e.KeyCode == Keys.L)
            {
                FormLog formLog = AppRt.FormLog;
                formLog.Show();
                return;
            }
        }

        private void PerformManualLogin()
        {
            if (AppRt.CurUser == null) return;
            AppRt.ResetUserInfo();
            DisplayUser("");
            SetPbVisible(false, pictureBoxSystem);
            ShowWindow(_indexForm);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            CabinetServer.Stop();
            AppRt.VideoCaptureDevice.Dispose();
            GC.Collect();
            Environment.Exit(0); //现场时关闭此窗体后，程序没有完全退出，加了这个，去现场时再调试下,已经调试了
        }


        ////若不关门，则一直会报警(目前代码不是这种处理)
        ////无用户登录，返回（正常流程情况下，不会出现门开着，用户没有登录的情况），有用户登录时（有门没关时），到第1个时间，报警，到第2个时间，记录下来，记录下来后，不退出登录，结束报警
        //private void ProcessAlarm()
        //{
        //    try
        //    {
        //        /*bool bAlarm = false;*/ //是否已经播放报警声音
        //        while (true)
        //        {
        //            Thread.Sleep(1000);

        //            userLoginManualEvent.WaitOne();

        //            if (AppRt.CurUser == null) continue;
        //            List<CabinetModule> moduleList = CabinetSrv.GetModuleStatus();
        //            int doorOpened = 0;
        //            foreach (CabinetModule cm in moduleList)
        //            {
        //                List<CabinetDoorStatus> doorOpenedList = cm.DoorList.Where(p => p.DoorClosed == false).ToList();
        //                doorOpened += doorOpenedList.Count;

        //            }
        //            long n = SysHelper.GetLastInputTime() / 1000;
        //            TimeSpan timeSpan = DateTime.Now - AppRt.gUserLoginTime;
        //            if (doorOpened == 0)
        //            {
        //                simpleSound.Stop();
        //            }
        //            if (n > AppConfig.UserQuitTime && doorOpened == 0 && timeSpan.TotalSeconds > AppConfig.UserQuitTime)
        //            {
        //                AppRt.IsAlarmed = true;
        //                DisplayUser("");
        //                AppRt.CurUser = null;
        //                AppRt.IsNeedAlarm = false;
        //                SetPbVisible(false, pbSetting);
        //                SetPbVisible(false, pbAuthority);
        //                Logger.Info("退出完成");
        //                continue;
        //            }

        //            //if (n > AppConfig.AlarmTime && doorOpened > 0 && AppRt.IsNeedAlarm && timeSpan.TotalSeconds > AppConfig.AlarmTime)
        //            //{
        //            //    //报警
        //            //    if (!bAlarm)
        //            //    {
        //            //        bAlarm = true;
        //            //        Logger.Info("报警");
        //            //        simpleSound.PlayLooping();
        //            //    }
        //            //}
        //            //else //调试时加的
        //            //{
        //            //    if (bAlarm)
        //            //    {
        //            //        bAlarm = false;
        //            //        Logger.Info("报警停止");
        //            //        simpleSound.Stop();
        //            //    }
        //            //}
        //            if (AppConfig.AlarmEnable != 1) continue;
        //            if (AppRt.gDoorOpenTime == DateTime.MinValue) AppRt.gDoorOpenTime = DateTime.Now;
        //            TimeSpan doorTimeSpan = DateTime.Now - AppRt.gDoorOpenTime;
        //            if (doorOpened > 0 && AppRt.IsNeedAlarm && doorTimeSpan.TotalSeconds > AppConfig.AlarmTime)
        //            {
        //                if (!AppRt.IsAlarmed)
        //                {
        //                    //AppRt.IsAlarmed = true;
        //                    Logger.Info("报警");
        //                    simpleSound.PlayLooping();
        //                }
        //                DateTime currentTime = DateTime.Now;
        //                foreach (CabinetModule cm in moduleList)
        //                {
        //                    List<CabinetDoorStatus> doorOpenedList = cm.DoorList.Where(p => p.DoorClosed == false).ToList();
        //                    for (int i = 0; i < doorOpenedList.Count; i++)
        //                    {
        //                        CaPageMenus cpm =
        //                            BllCaPageMenus.GetCaPageMenus(AppRt.currentCabinet.Id, cm.ModuleAddr.ToString(),
        //                                doorOpenedList[i].DoorAddr.ToString(), out Exception ex);
        //                        NotCloseDoorRecord ncdr = BllNotCloseDoorRecord.GetNotCloseDoorRecord(cpm.Id,
        //                            AppRt.CurUser.ID, AppRt.CurUser.FullName, currentTime, out ex);
        //                        if (ncdr == null)
        //                        {

        //                            BllNotCloseDoorRecord.AddNotCloseDoorRecord(cpm.Id, AppRt.CurUser.ID,
        //                                AppRt.CurUser.FullName, AppRt.currentCabinet.Id);
        //                        }

        //                    }

        //                }
        //                //记录完后，不退出登录，停止报警
        //                //DisplayUser("");
        //                //AppRt.CurUser = null;
        //                //DelegareNotCloseDoor.RefreshNotCloseDoorGrid?.Invoke();
        //                //AppRt.IsNeedAlarm = false;
        //                Logger.Info("记录完成");

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex);
        //    }
        //}
    }
}