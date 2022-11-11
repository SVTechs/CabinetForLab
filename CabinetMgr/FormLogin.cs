using CabinetMgr.BLL;
using CabinetMgr.Common;
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
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using testface;

namespace CabinetMgr
{
    public partial class FormLogin : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static IList<Info> infoList;
        private List<UserInfo> imagesFeatureList = new List<UserInfo>();
        private float threshold = 80f;
        private string lastCardNum = "";

        public static ManualResetEvent FaceDataManualEvent = new ManualResetEvent(false);
        public static ManualResetEvent FingerDataManualEvent = new ManualResetEvent(false);

        SoundPlayer showFace = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("FaceCric"));
        SoundPlayer pressFinger = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("PressFinger"));
        SoundPlayer swipeCard = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("SwipeCard"));
        SoundPlayer enterPassword = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("EnterPassword"));

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (AppRt.HaveFaceDevice)
            {
                InitFaceData();
                InitFaceCricThread();
            }
            if (AppRt.HaveFpDevice)
            {
                InitFpData();
                InitFpCricThread();
            }
            if (AppRt.HaveCardDevice)
            {
                InitCardCricThread();
            }
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            LoadInfo();
        }

        public void LoadInfo()
        {
            InfoClear();
            infoList = BllInfo.SearchInfo(0, 3, null, out _);
            foreach (Info info in infoList)
            {
                AddInfo(info.InfoContent, info.InfoType, info.Id);
            }
            flowLayoutPanel1.Refresh();
        }

        private void uiImageButtonFace_Click(object sender, EventArgs e)
        {
            if (!AppRt.HaveFaceDevice)
            {
                UIMessageBox.Show("未检测到人脸识别设备");
                return;
            }

            AppRt.FaceEnable = true;
            AppRt.FormFaceShow.FormVisible(true);
            showFace.Play();
            timerStopCrit.Start();
        }

        private void uiImageButtonFingerPrint_Click(object sender, EventArgs e)
        {
            if (!AppRt.HaveFpDevice)
            {
                UIMessageBox.Show("未检测到指纹设备");
                return;
            }
            AppRt.FpEnable = true;
            AppRt.FormFingerShow.FormVisible(true);
            pressFinger.Play();
            timerStopCrit.Start();
        }

        private void uiImageButtonCard_Click(object sender, EventArgs e)
        {
            //textBoxCardNum.Text = "";
            //lastCardNum = "";
            AppRt.CardEnable = true;
            swipeCard.Play();
            //textBoxCardNum.Focus();
            timerStopCrit.Start();
        }

        private void uiImageButtonPassword_Click(object sender, EventArgs e)
        {
            enterPassword.Play();
            FormPasswordLogin formPasswordLogin = FormPasswordLogin.Instance();
            formPasswordLogin.ShowDialog();

        }

        private void FormLogin_Click(object sender, EventArgs e)
        {
            //windowVideo?.Dispose();
        }

        #region Face

        private void InitFaceCricThread()
        {
            Thread t = new Thread(FaceCric) { IsBackground = true };
            t.Start();
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
                    if (!AppRt.FaceEnable) continue;
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
                            BDFaceFeature[] ff = faceFeature.test_get_face_feature_by_path(image);
                            UserInfo ui = compareFeature(ff[0], out float similarity);
                            if (ui != null)
                            {
                                FpCallBack.OnUserRecognised?.Invoke(ui.TemplateId, 1);
                                AppRt.FaceEnable = false;
                                AppRt.FormFaceShow.FormVisible(false);
                            }
                        }

                        Thread.Sleep(1000);

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
                if (!ui.HasFingerFeature) continue;
                int ret = FpDevice.DownChar(ui.FingerFeature);
                if (ret != DriveOpration.PS_OK) isAllSucceed = false;
                ret = FpDevice.StoreChar((int)ui.TemplateId);
                if (ret != DriveOpration.PS_OK) isAllSucceed = false;
            }
            if (!isAllSucceed)
            {
                UIMessageBox.ShowError("指纹下发出错，部分指纹将不能使用");
                //AddInfo("指纹下发出错，部分指纹将不能使用", 2, "");
            }

        }

        private void InitFpCricThread()
        {
            Thread t = new Thread(FpCric) { IsBackground = true };
            t.Start();
        }

        private void FpCric()
        {
            int address = -1, score = 0;
            byte[] imageData = new byte[192 * 192];
            ushort templateLength = 0;
            while (true)
            {
                Thread.Sleep(300);
                if (!AppRt.FpEnable) continue;
                int ret = FpDevice.GetImage();
                if (ret != DriveOpration.PS_OK) continue;
                ret = FpDevice.UpImage(out imageData, ref templateLength);
                if (ret != DriveOpration.PS_OK) 
                { 
                    AppRt.FormFingerShow.SetResultLabelValue("获取指纹图像失败"); 
                    continue; 
                };
                AppRt.FormFingerShow.ShowFingerPrint(imageData);
                ret = FpDevice.GenChar(1);
                if (ret != DriveOpration.PS_OK) 
                { 
                    AppRt.FormFingerShow.SetResultLabelValue("生成特征失败");
                    continue; 
                };
                ret = FpDevice.SearchFeature(ref address, ref score);
                if (ret == DriveOpration.PS_OK)
                {
                    AppRt.FormFingerShow.SetResultLabelValue("登录成功");
                    FpCallBack.OnUserRecognised?.Invoke(address, 2);
                    AppRt.FpEnable = false;
                    AppRt.FormFingerShow.FormVisible(false);
                }
                else
                {
                    AppRt.FormFingerShow.SetResultLabelValue("特征比对失败");
                    continue; 
                }

            }
        }



        #endregion

        #region Card

        private void InitCardCricThread()
        {
            Thread t = new Thread(CardCric) { IsBackground = true };
            t.Start();
        }

        private void CardCric()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(700);
                    if (!AppRt.CardEnable) continue;
                    //if (string.IsNullOrEmpty(textBoxCardNum.Text)) continue;
                    //string cardNum = textBoxCardNum.Text;
                    //if (lastCardNum != cardNum)
                    //{
                    //    lastCardNum = cardNum;
                    //    continue;
                    //}
                    //ClearTextBox();
                    //AppRt.FormLog.AddLine(cardNum);
                    //UserInfo ui = BllUserInfo.GetUserInfoByCardNum(cardNum, out _);
                    //FpCallBack.OnUserRecognised?.Invoke(ui.TemplateId, 3);
                    //AppRt.CardEnable = false;

                    string cardNum = CardDevice.PiccRequest();
                    if (!string.IsNullOrEmpty(cardNum))
                    {
                        AppRt.FormLog.AddLine(cardNum);
                        UserInfo ui = BllUserInfo.GetUserInfoByCardNum(cardNum, out _);
                        if (ui == null) continue;
                        FpCallBack.OnUserRecognised?.Invoke(ui.TemplateId, 3);
                        AppRt.CardEnable = false;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }

            }
        }

        #endregion




        private delegate void AddInfoDelegate(string infoContent, int infoLevel, string id);
        private void AddInfo(string infoContent, int infoLevel, string id)
        {
            if (flowLayoutPanel1.InvokeRequired)
            {
                AddInfoDelegate d = AddInfo;
                flowLayoutPanel1.Invoke(d, infoContent, infoLevel);
            }
            else
            {
                UIButton button = new UIButton();
                button.Font = new Font("HarmonyOS Sans SC", 20);
                button.Text = infoContent;
                button.Width = flowLayoutPanel1.Width - 20;
                button.Height = 75;
                button.Click += InfoButtonClick;
                button.Tag = id;
                switch (infoLevel)
                {
                    case 0:
                        button.Style = UIStyle.Green;
                        flowLayoutPanel1.Controls.Add(button);
                        break;
                    case 1:
                        button.Style = UIStyle.Orange;
                        flowLayoutPanel1.Controls.Add(button);
                        break;
                    case 2:
                        button.Style = UIStyle.Red;
                        flowLayoutPanel1.Controls.Add(button);
                        break;
                }
            }

        }

        private void InfoButtonClick(object sender, EventArgs e)
        {
            if(AppRt.CurUser == null)
            {
                UIMessageBox.ShowError("请登录后再进行操作");
                return;
            }
            UIButton btn = sender as UIButton;
            int result = BllInfo.DeleteInfo(btn.Tag as string, out _);
            LoadInfo();
        }

        private delegate void InfoClearDelegate();
        private void InfoClear()
        {
            if (flowLayoutPanel1.InvokeRequired)
            {
                InfoClearDelegate d = InfoClear;
                flowLayoutPanel1.Invoke(d);
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
            }
            
        }

        private delegate void ClearTextBoxDelegate();
        private void ClearTextBox()
        {
            if (textBoxCardNum.InvokeRequired)
            {
                ClearTextBoxDelegate d = ClearTextBox;
                textBoxCardNum.Invoke(d);
            }
            else
            {
                textBoxCardNum.Text = "";
            }
        }

        private void timerStopCrit_Tick(object sender, EventArgs e)
        {
            AppRt.FormFaceShow.FormVisible(false);
            AppRt.FormFingerShow.FormVisible(false);
            AppRt.FaceEnable = false;
            AppRt.FpEnable = false;
            AppRt.CardEnable = false;
            ClearTextBox();
            flowLayoutPanel1.Focus();
        }

        private void FormLogin_VisibleChanged(object sender, EventArgs e)
        {
            LoadInfo();
            AppRt.FormMain.SetPicTitle(true);
            AppRt.FormMain.SetUiLabelUserName("", false);
        }
    }
}
