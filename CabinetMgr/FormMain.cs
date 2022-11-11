using CabinetMgr.BLL;
using CabinetMgr.Config;
using CabinetMgr.RtVars;
using Domain.Main.Domain;
using Hardware.DeviceInterface;
using Newtonsoft.Json;
using NLog;
using OpenCvSharp;
using Sunny.UI;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using testface;

namespace CabinetMgr
{
    public partial class FormMain : Form
    {
        private Form _curForm;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Form _loginForm;
        public Form _indexForm;
        public Form _manageForm;
        public Form _recordForm;
        public Form _systemManage;
        public Form _toolManage;
        public Form _userManage;

        SoundPlayer loginSuccess = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("LoginSuccess"));

        private int manageCount = 7;
        private int currentCount = 1;

        public FormMain()
        {
            InitializeComponent();
            FpCallBack.OnUserRecognised = OnUserRecognised;
            CabinetServerCallback.MsgReceived += MsgReceived;
            CabinetServerCallback.BorrowReturnCmd += BorrowReturnCmd;
            CabinetServerCallback.NewSessionConnected += NewSessionConnected;
            CabinetServerCallback.SessionClosed += SessionClosed;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            AppRt.FormLog = new FormLog();
            AppRt.FormMain = this;

            FormDeviceLoader dlForm = new FormDeviceLoader();
            dlForm.ShowDialog();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitForm();

            ShowWindow(_loginForm);

            Thread t = new Thread(AlertOutDate) { IsBackground = true };
            t.Start();
        }

        private void AlertOutDate()
        {

            while (true)
            {
                IList<BorrowRecord> outDateList = BllBorrowRecord.NotReturnRecord(out _);
                foreach(BorrowRecord br in outDateList)
                {
                    ToolInfo ti = BllToolInfo.GetToolInfo(br?.ToolId, out _);
                    if (ti == null) continue;
                    if (ti.WarnType == 1) continue;
                    TimeSpan ts = DateTime.Now - br.EventTime;
                    if(ts.TotalHours > ti.WarnValue)
                    {
                        br.Status = -30;
                        BllBorrowRecord.UpdateBorrowRecord(br, out _);
                    }
                }
                Thread.Sleep(60000 * 5);
            }
            

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Face.sdk_destroy();
            CabinetServer.Stop();
            FpDevice.CloseDeviceEx();
            Application.Exit();
            //AppRt.VideoCaptureDevice?.Dispose();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Alt && e.KeyCode == Keys.A)
            {
                OnUserRecognised(2, 2);
                return;
            }
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
                MessageBox.Show("重置完成");
                return;
            }
            if (e.Shift && e.Alt && e.KeyCode == Keys.L)
            {
                FormLog formLog = AppRt.FormLog;
                formLog.Show();
                return;
            }
            if (e.Shift && e.Alt && e.KeyCode == Keys.O)
            {
                IList<DoorInfo> doorList = CabinetServer.GetDoorList();

                foreach(DoorInfo di in doorList)
                {
                    CabinetServer.OpenDoors(di.Id, di.Nch);
                    AppRt.FormLog.AddLine($"OpenDoor{di.Id}:{di.Nch}");
                    Thread.Sleep(100);
                }
                return;
            }
            if (e.Shift && e.Alt && e.KeyCode == Keys.D)
            {
                IList<DoorInfo> doorList = CabinetServer.GetDoorList();
                StringBuilder sb = new StringBuilder();
                foreach (DoorInfo di in doorList)
                {
                    sb.Append($"{di.Id}:{di.Nch}_{di.IsClosed};");
                }
                AppRt.FormLog.AddLine(sb.ToString());
                return;
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void panelWindow_SizeChanged(object sender, EventArgs e)
        {
            if (_curForm != null)
            {
                _curForm.Width = panelWindow.Width;
                _curForm.Height = panelWindow.Height;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// 1.人脸 2.指纹  3.IC卡 4.密码
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

                    IList<ToolSettings> toolSettings = BllToolSettings.GetToolSettings(roleAry, out _);
                    IList<ToolInfo> ToolList = new List<ToolInfo>();
                    foreach (ToolSettings ts in toolSettings)
                    {
                        ToolInfo ti = BllToolInfo.GetToolInfo(ts.ToolId, out e);
                        ToolList.Add(ti);
                    }
                    AppRt.CurUser = loginUser;
                    AppRt.RoleList = RoleList;
                    AppRt.RoleSettings = roleSettings;
                    AppRt.LatticeList = LatticeList;
                    AppRt.ToolList = ToolList;
                    //SetLabelText(uiLabelUserName, AppRt.CurUser.FullName ?? "" + " | 退出账号", true);
                    //SetPictureBoxStatus(pictureBoxTitleE, false, null);
                    //SetPictureBoxStatus(pictureBoxTitleC, false, null);
                    loginSuccess.Play();
                    ShowWindow(_indexForm);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

        }

        #region ControlDelegate

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

        public delegate void SetLabelTextDelegate(Label label, string text, bool visible);
        public void SetLabelText(Label label, string text, bool visible)
        {
            if (label.InvokeRequired)
            {
                SetLabelTextDelegate d = SetLabelText;
                label.Invoke(d, label, text, visible);
            }
            else
            {
                label.Text = text;
                label.Visible = visible;
            }
        }

        private delegate void SetPictureBoxStatusDelegate(PictureBox pictureBox, bool visible, Bitmap pic);
        public void SetPictureBoxStatus(PictureBox pictureBox, bool visible, Bitmap pic)
        {
            try
            {
                if (pictureBox.InvokeRequired)
                {
                    SetPictureBoxStatusDelegate d = SetPictureBoxStatus;
                    pictureBox.Invoke(d, pictureBox, visible, pic);
                }
                else
                {
                    pictureBox.Visible = visible;
                    if(pic != null)
                    {
                        pictureBox.BackgroundImage = pic;
                        pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        #endregion

        private void InitForm()
        {
            try
            {
                _loginForm = new FormLogin();
                AddToPanel(_loginForm);

                _indexForm = new FormIndex0();
                AddToPanel(_indexForm);

                _manageForm = new FormManage();
                AddToPanel(_manageForm);

                _recordForm = new FormRecord();
                AddToPanel(_recordForm);

                _systemManage = new FormSystemManage();
                AddToPanel(_systemManage);

                _toolManage = new FormToolManage0();
                _userManage = new FormUserManage();
                (_systemManage as FormSystemManage)._toolManageForm = _toolManage;
                (_systemManage as FormSystemManage).AddToPanel(_toolManage);
                (_systemManage as FormSystemManage)._userManageForm = _userManage;
                (_systemManage as FormSystemManage).AddToPanel(_userManage);

                AppRt.FormFaceShow = FormFaceShow.Instance();
                AppRt.FormFingerShow = FormFingerShow.Instance();

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void ShowWindow(Form targetForm)
        {
            if (_curForm == targetForm)
            {
                return;
            }
            foreach (var form in panelWindow.Controls)
            {
                var curForm = form as Form;
                if (curForm != null)
                {
                    FormVisible(false, curForm);
                }
            }
            _curForm = targetForm;
            FormVisible(true, targetForm);
        }

        private void AddToPanel(Form targetForm)
        {
            targetForm.TopLevel = false;
            targetForm.Width = panelWindow.Width;
            targetForm.Height = panelWindow.Height;
            panelWindow.Controls.Add(targetForm);
        }

        private void MsgReceived(string parseStr)
        {
            AppRt.FormLog.AddLine(parseStr);
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

        private void BorrowReturnCmd(AppSession session, string cmd)
        //private void BorrowReturnCmd(string cmd)
        {
            if (AppRt.CurUser == null)
            {
                UIMessageBox.Show("请先登录再申请借还");
                return;
            }
            var value = cmd.Replace($"\\", "").Replace("{", "").Replace("}", "").Replace($"\"", "");
            string[] cmdAry = value.Split(',');
            bool success = true;
            foreach (string cmdStr in cmdAry)
            {
                if (string.IsNullOrEmpty(cmdStr)) continue;
                var toolLocation = cmdStr.Split(":")[0];
                var cmdType = cmdStr.Split(":")[1];
                int result = ExecuteCmd(toolLocation, cmdType);
                if (result <= 0) success = false;
            }
            //session.Send(JsonConvert.SerializeObject($"{{\"success\":{success}}}"));
            (_indexForm as FormIndex0).ReloadData();
            (_indexForm as FormIndex0).LoadPage();
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

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            if (_curForm != _indexForm) PerformManualLogin();
            ShowWindow(_loginForm);
        }

        private void pictureBoxTitleC_Click(object sender, EventArgs e)
        {
            currentCount += 1;
            if (currentCount == manageCount)
            {
                currentCount = 1;
                ShowWindow(_manageForm);
            }
        }

        private void uiLabelUserName_Click(object sender, EventArgs e)
        {
            PerformManualLogin();
        }

        public void SetUiLabelUserName(string text, bool visible)
        {
            SetLabelText(uiLabelUserName, text, visible);
        }

        public void SetPicTitle(bool visible)
        {
            SetPictureBoxStatus(pictureBoxTitleE, visible, null);
            SetPictureBoxStatus(pictureBoxTitleC, visible, null);
        }

        private void PerformManualLogin()
        {
            AppRt.ResetUserInfo();
            (_loginForm as FormLogin).LoadInfo();
            ShowWindow(_loginForm);

            //SetLabelText(uiLabelUserName, "", false);
            //SetPictureBoxStatus(pictureBoxTitleE, true, null);
            //SetPictureBoxStatus(pictureBoxTitleC, true, null);
        }

    }
}
