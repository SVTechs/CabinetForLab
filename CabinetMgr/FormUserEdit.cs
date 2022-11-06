using CabinetMgr.BLL;
using CabinetMgr.Common;
using CabinetMgr.Config;
using CabinetMgr.RtVars;
using Domain.Main.Domain;
using Hardware.DeviceInterface;
using NLog;
using OpenCvSharp;
using Sunny.UI;
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
using Utilities.Encryption;

namespace CabinetMgr
{
    public partial class FormUserEdit : UIForm
    {
        public static FormUserEdit formUserEdit;
        private static string _userId;
        private static long _templateId;
        private static byte[] fingerTemplate;
        private static byte[] faceTemplate;
        private static string cardNum;
        private static string lastCardNum;

        private VideoCapture cap;
        private Window windowVideo;
        private bool enableVideo = false;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        SoundPlayer cardCatched = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("CardCatched"));
        SoundPlayer faceCatched = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("FaceCatched"));
        SoundPlayer fpCatched = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("FpCatched"));


        public static FormUserEdit Instance(string userId)
        {
            if (formUserEdit == null || formUserEdit.IsDisposed) formUserEdit = new FormUserEdit();
            _userId = userId;
            return formUserEdit;
        }
        public FormUserEdit()
        {
            InitializeComponent();
            LoadRoleData();
        }

        private void LoadRoleData()
        {
            uiComboTreeViewRole.Nodes.Clear();
            var node = TreeManager.GetRoleNode();
            IList<RoleSettings> roleSettings = BllRoleSettings.SearchRoleSettings(_userId, 0, -1, null, out _);
            foreach (RoleInfo ri in node.TreeChildren)
            {
                RoleSettings rs = roleSettings.FirstOrDefault(x => x.RoleId == ri.Id);
                TreeNode tn = new TreeNode()
                {
                    Text = ri.RoleName,
                    Tag = ri.Id + "|" + ri.IsProtected,
                    Checked = rs != null
                };
                uiComboTreeViewRole.Nodes.Add(tn);
            }
        }

        private void uiButtonCard_Click(object sender, EventArgs e)
        {
            uiTextBoxCardNum.Text = "";
            lastCardNum = "";
            cardNum = "";
            uiTextBoxCardNum.Focus();
            Thread t = new Thread(CatchCardNum) { IsBackground = true };
            t.Start();
         
        }

        private void CatchCardNum()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(700);
                    if (string.IsNullOrEmpty(uiTextBoxCardNum.Text)) continue;
                    cardNum = uiTextBoxCardNum.Text;
                    if (lastCardNum != cardNum)
                    {
                        lastCardNum = cardNum;
                        continue;
                    }
                    uiTextBoxUserName.Focus();
                    ClearTextBox();
                    AppRt.FormLog.AddLine(cardNum);
                    cardCatched.Play();
                    break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private void uiButtonFace_Click(object sender, EventArgs e)
        {
            windowVideo = new Window("windowVideo");
            windowVideo.Move(1, 1);
            //WindowHelper.SetWindowTopMost(handle);
            cap = AppRt.VideoCaptureDevice;
            Mat image = new Mat();
            enableVideo = true;
            uiButtonFaceCap.Visible = true;
            while (enableVideo)
            {
                cap.Read(image);
                if (!image.Empty())
                {
                    int ilen = 40;//传入的人脸数
                    BDFaceBBox[] info = new BDFaceBBox[ilen];

                    int sizeTrack = Marshal.SizeOf(typeof(BDFaceBBox));
                    IntPtr ptT = Marshal.AllocHGlobal(sizeTrack * ilen);

                    int faceSize = ilen;//返回人脸数  分配人脸数和检测到人脸数的最小值
                    int curSize = ilen;//当前人脸数 输入分配的人脸数，输出实际检测到的人脸数
                    int type = 0;
                    faceSize = FaceDetect.detect(ptT, image.CvPtr, type);
                    //if (faceSize > 1) faceSize = 1;
                    for (int index = 0; index < faceSize; index++)
                    {
                        IntPtr ptr = new IntPtr();
                        if (8 == IntPtr.Size)
                        {
                            ptr = (IntPtr)(ptT.ToInt64() + sizeTrack * index);
                        }
                        else if (4 == IntPtr.Size)
                        {
                            ptr = (IntPtr)(ptT.ToInt32() + sizeTrack * index);
                        }

                        info[index] = (BDFaceBBox)Marshal.PtrToStructure(ptr, typeof(BDFaceBBox));
                    }

                    FaceDraw.draw_rects(ref image, faceSize, info);
                    //FaceDraw.draw_shape(ref image, faceSize, track_info);
                    Marshal.FreeHGlobal(ptT);
                    windowVideo.ShowImage(image);
                    Cv2.WaitKey(1);
                }
                else
                {
                    Console.WriteLine("mat is empty");
                }
            }
        }

        private void uiButtonFaceCap_Click(object sender, EventArgs e)
        {

            try
            {
                Mat image = new Mat();
                cap.Read(image); // same as cvQueryFrame
                if (!image.Empty())
                {
                    int ilen = 40;//传入的人脸数
                    BDFaceBBox[] info = new BDFaceBBox[ilen];

                    int sizeTrack = Marshal.SizeOf(typeof(BDFaceBBox));
                    IntPtr ptT = Marshal.AllocHGlobal(sizeTrack * ilen);

                    int faceSize = ilen;//返回人脸数  分配人脸数和检测到人脸数的最小值
                    int curSize = ilen;//当前人脸数 输入分配的人脸数，输出实际检测到的人脸数
                    int type = 0;
                    faceSize = FaceDetect.detect(ptT, image.CvPtr, type);
                    if (faceSize < 1)
                    {
                        UIMessageBox.Show("未识别到人脸");
                        windowVideo.Dispose();
                        windowVideo = new Window("windowVideo");
                        windowVideo.Move(1, 1);
                        return;
                    }
                    for (int index = 0; index < faceSize; index++)
                    {
                        IntPtr ptr = new IntPtr();
                        if (8 == IntPtr.Size)
                        {
                            ptr = (IntPtr)(ptT.ToInt64() + sizeTrack * index);
                        }
                        else if (4 == IntPtr.Size)
                        {
                            ptr = (IntPtr)(ptT.ToInt32() + sizeTrack * index);
                        }

                        info[index] = (BDFaceBBox)Marshal.PtrToStructure(ptr, typeof(BDFaceBBox));
                    }

                    Marshal.FreeHGlobal(ptT);
                    Cv2.WaitKey(1);
                    enableVideo = false;
                    windowVideo.Dispose();

                    FaceFeature faceFeature = new FaceFeature();
                    BDFaceFeature[] ff = faceFeature.test_get_face_feature_by_path(image);
                    BDFaceFeature bDFaceFeature = ff[0];
                    byte[] faceByte = new byte[bDFaceFeature.data.Length * 4];
                    int j = 0;
                    for (int i = 0; i < bDFaceFeature.data.Length; i++)
                    {
                        Buffer.BlockCopy(BitConverter.GetBytes(bDFaceFeature.data[i]), 0, faceByte, j, 4);
                        j = j + 4;
                    }
                    faceTemplate = faceByte;
                    uiButtonFaceCap.Visible = false;
                    faceCatched.Play();
                }
            }

            catch(Exception ex)
            {

            }

        }

        private void uiButtonFinger_Click(object sender, EventArgs e)
        {
            FormFingerCap formFingerCap = FormFingerCap.Instance(_templateId);
            formFingerCap.ShowDialog();
            fingerTemplate = formFingerCap.fingerTemplate;
            formFingerCap.FormReset();
            fpCatched.Play();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            UserInfo result = null;
            if (string.IsNullOrEmpty(uiTextBoxUserName.Text))
            {
                UIMessageBox.ShowError("请填写工号");
                return;
            }
            if (string.IsNullOrEmpty(uiTextBoxFullName.Text))
            {
                UIMessageBox.ShowError("请填写姓名");
                return;
            }
            if (string.IsNullOrEmpty(uiTextBoxPassword.Text) && string.IsNullOrEmpty(_userId))
            {
                UIMessageBox.ShowError("请填写密码");
                return;
            }
            if (string.IsNullOrEmpty(_userId)) result = InsertUserInfo();
            else result = UpdateUserInfo();
            if (result == null)
            {
                UIMessageBox.ShowError("保存失败");
                return;
            }
            if (faceTemplate != null) result.FaceFeature = faceTemplate;
            if (fingerTemplate != null) result.FingerFeature = fingerTemplate;
            if (!string.IsNullOrEmpty(cardNum)) result.CardNum = cardNum;
            int i = BllUserInfo.UpdateUserInfo(result, out Exception ex);
            if(i < 0) return;
            ClearInputData();
            Hide();
        }

        private UserInfo InsertUserInfo()
        {
            UserInfo userinfo = BllUserInfo.GetUserInfoByUserName(uiTextBoxUserName.Text, out _);
            if(userinfo != null)
            {
                UIMessageBox.ShowError($"该工号已被使用");
                return null;
            }
            UserInfo ui = new UserInfo()
            {
                ID = Guid.NewGuid().ToString(),
                UserName = uiTextBoxUserName.Text.Trim(),
                Password = Md5Encode.Encode(uiTextBoxPassword.Text, false),
                FullName = uiTextBoxFullName.Text,
                Createtime = DateTime.Now,
                CreateUser = AppRt.CurUser.FullName,
                Updatetime = Env.MinTime,
            };
            int result = BllUserInfo.SaveUserInfo(ui, out Exception ex);
            IList<RoleSettings> roleSettings = new List<RoleSettings>();
            foreach(TreeNode tn in uiComboTreeViewRole.Nodes)
            {
                if (!tn.Checked) continue;
                RoleSettings rs = new RoleSettings()
                {
                    Id = Guid.NewGuid().ToString().ToUpper(),
                    RoleId = (tn.Tag as string).Split('|')[0],
                    UserId = ui.ID,
                    AddTime = DateTime.Now
                };
                roleSettings.Add(rs);
            }
            BllRoleSettings.BatchSaveRoleSettings(ui.ID, roleSettings, out _);

            if (result < 0)
            {
                UIMessageBox.ShowError($"保存失败，原因：\n{ex.Message}");
                return null;
            }
            return BllUserInfo.GetUserInfoByUserName(uiTextBoxUserName.Text, out _);
        }

        private UserInfo UpdateUserInfo()
        {
            UserInfo user = BllUserInfo.GetUserInfo(_userId, out _);
            if (uiTextBoxUserName.Text != user.UserName)
            {
                if (BllUserInfo.GetUserInfoByUserName(uiTextBoxUserName.Text, out _) != null)
                {
                    UIMessageBox.ShowError($"该工号已被使用");
                    return null;
                }
            }
            user.UserName = uiTextBoxUserName.Text;
            user.FullName = uiTextBoxFullName.Text;
            if (!string.IsNullOrEmpty(uiTextBoxPassword.Text)) user.Password = Md5Encode.Encode(uiTextBoxPassword.Text, false);
            user.Updatetime = DateTime.Now;
            user.UpdateUser = AppRt.CurUser.FullName;
            IList<RoleSettings> roleSettings = new List<RoleSettings>();
            foreach (TreeNode tn in uiComboTreeViewRole.Nodes)
            {
                if (!tn.Checked) continue;
                RoleSettings rs = new RoleSettings()
                {
                    Id = Guid.NewGuid().ToString().ToUpper(),
                    RoleId = (tn.Tag as string).Split('|')[0],
                    UserId = user.ID,
                    AddTime = DateTime.Now
                };
                roleSettings.Add(rs);
            }
            BllRoleSettings.BatchSaveRoleSettings(user.ID, roleSettings, out _);
            int result = BllUserInfo.UpdateUserInfo(user, out Exception ex);
            if (result < 0)
            {
                UIMessageBox.ShowError($"保存失败，原因：\n{ex.Message}");
                return null;
            }
            return user;
        }

        private void FormUserEdit_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_userId))
            {
                _templateId = -1;
                return; 
            }
            UserInfo userInfo = BllUserInfo.GetUserInfo(_userId, out _);
            _templateId = userInfo.TemplateId;
            IList<RoleSettings> roleSettings = BllRoleSettings.SearchRoleSettings(_userId, 0, -1, null, out _);
            uiTextBoxUserName.Text = userInfo.UserName;
            uiTextBoxFullName.Text = userInfo.FullName;
            uiTextBoxPassword.Text = "";
            foreach(TreeNode tn in uiComboTreeViewRole.Nodes)
            {
                RoleSettings rs = roleSettings.FirstOrDefault(x => x.RoleId == (tn.Tag as string).Split('|')[0]);
                if (rs != null)
                {
                    tn.Checked = true;
                    uiComboTreeViewRole.Text += (tn.Text+";");
                }
            }
        }

        private void ClearInputData()
        {
            uiTextBoxUserName.Text = "";
            uiTextBoxFullName.Text = "";
            uiTextBoxPassword.Text = "";
            foreach(TreeNode tn in uiComboTreeViewRole.Nodes)
            {
                tn.Checked = false;
            }
            uiComboTreeViewRole.Text = "";
            fingerTemplate = null;
            faceTemplate = null;
            cardNum = null;
        }

        private delegate void ClearTextBoxDelegate();
        private void ClearTextBox()
        {
            if (uiTextBoxCardNum.InvokeRequired)
            {
                ClearTextBoxDelegate d = ClearTextBox;
                uiTextBoxCardNum.Invoke(d);
            }
            else
            {
                uiTextBoxCardNum.Text = "";
            }
        }

    }
}
