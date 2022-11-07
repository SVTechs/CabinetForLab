using CabinetMgr.BLL;
using CabinetMgr.Config;
using CabinetMgr.RtVars;
using Hardware.DeviceInterface;
using NLog;
using OpenCvSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using testface;

namespace CabinetMgr
{
    public partial class FormDeviceLoader : UIForm
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private DataGridViewCellStyle _ctRed, _ctGreen;
        private bool _isPassed = true;
        private bool _cameraPassed = false, _cardDevicePassed = false, _fpDevicePassed = false;
        public static ManualResetEvent InitManualEvent = new ManualResetEvent(false);

        private void FormDeviceLoad_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            ConfigLoader.LoadConfig();

            InitGrid();
        }

        public FormDeviceLoader()
        {
            InitializeComponent();
            CabinetServerCallback.OnInitDone += OnCabinetInitDone;
        }

        private void FormDeviceLoad_Shown(object sender, EventArgs e)
        {
            Screen screen = Screen.PrimaryScreen;
            AppRt.ScreenSize = screen.Bounds.Size;
            if (AppConfig.DebugMode == 1) AppRt.FormLog.Show();
            Init();
            //InitCamera();
            //InitFpDevice();
            //InitFaceEngine();
            //InitCardDevice();
            InitSocketServer();
        }

        private async Task Init()
        {
            InitCamera();
            InitCardDevice();
            InitFpDevice();

            while (true)
            {
                Application.DoEvents();
                Thread.Sleep(100);
                if (_cameraPassed && _fpDevicePassed && _cardDevicePassed) break;
            }
        }

        private void InitGrid()
        {
            cStatusGrid.ColumnCount = 2;
            cStatusGrid.Columns[0].HeaderText = "项目";
            cStatusGrid.Columns[1].HeaderText = "状态";
            cStatusGrid.Columns[0].Width = (cStatusGrid.Width - 50) / 2;
            cStatusGrid.Columns[1].Width = (cStatusGrid.Width - 50) / 2;
            _ctRed = new DataGridViewCellStyle();
            _ctGreen = new DataGridViewCellStyle();
            _ctRed.BackColor = Color.HotPink;
            _ctGreen.BackColor = Color.LightGreen;
        }

        private Task InitCamera()
        {
            int index = cStatusGrid.Rows.Add();
            cStatusGrid.Rows[index].Cells[0].Value = "初始化摄像头";
            cStatusGrid.Rows[index].Cells[1].Value = "正在执行";

            var task = Task.Factory.StartNew(() => {

                //VideoCapture cap = VideoCapture.FromCamera(0);
                VideoCapture cap = VideoCapture.FromCamera(AppConfig.CameraPort);
                if (!cap.IsOpened())
                {
                    UpdateStatus("初始化摄像头", "初始化失败", 2);
                    _isPassed = false;
                    AppRt.HaveFaceDevice = false;
                }
                else
                {
                    AppRt.VideoCaptureDevice = cap;
                    AppRt.HaveFaceDevice = true;
                    UpdateStatus("初始化摄像头", "初始化成功", 1);
                }
                _cameraPassed = true;
            }, TaskCreationOptions.LongRunning);
            return task;
        }

        private Task InitCardDevice()
        {
            int index = cStatusGrid.Rows.Add();
            cStatusGrid.Rows[index].Cells[0].Value = "初始化读卡器";
            cStatusGrid.Rows[index].Cells[1].Value = "正在执行";

            var task = Task.Factory.StartNew(() => {

                try
                {
                    //if (!File.Exists(@"ReadCard.exe"))
                    //{
                    //    UpdateStatus("初始化读卡器", "初始化失败", 2);
                    //    _isPassed = false;
                    //    AppRt.HaveCardDevice = false;
                    //}
                    //else
                    //{
                    //    Process.Start(@"ReadCard.exe");
                    //    AppRt.HaveCardDevice = true;
                    //    UpdateStatus("初始化读卡器", "初始化成功", 1);
                    //}
                    byte result = CardDevice.PcdDeep(50);
                    AppRt.FormLog.AddLine("PcdBeepValue:" + result);
                    if (result != 0)
                    {
                        UpdateStatus("初始化读卡器", "初始化失败", 2);
                        _isPassed = false;
                        AppRt.HaveCardDevice = false;
                    }
                    else
                    {
                        AppRt.HaveCardDevice = true;
                        UpdateStatus("初始化读卡器", "初始化成功", 1);
                    }
                }
                catch(Exception ex)
                {
                    UpdateStatus("初始化读卡器", "初始化失败", 2);
                    _isPassed = false;
                    AppRt.HaveCardDevice = false;
                }
                finally {
                    _cardDevicePassed = true;
                }

            }, TaskCreationOptions.LongRunning);

            return task;

        }

        private Task InitFpDevice()
        {
            int index = cStatusGrid.Rows.Add();
            cStatusGrid.Rows[index].Cells[0].Value = "初始化指纹仪";
            cStatusGrid.Rows[index].Cells[1].Value = "正在执行";

            var task = Task.Factory.StartNew(() => {

                int result = FpDevice.Init(AppConfig.FpPort);
                if (result != 0)
                {
                    UpdateStatus("初始化指纹仪", "初始化失败", 2);
                    _isPassed = false;
                    AppRt.HaveFpDevice = false;
                }
                else
                {
                    AppRt.HaveFpDevice = true;
                    UpdateStatus("初始化指纹仪", "初始化成功", 1);
                }
                _fpDevicePassed = true;
                InitManualEvent.Set();
            }, TaskCreationOptions.LongRunning);

            return task;
        }



        //private Task InitFaceEngine()
        //{
        //    int index = cStatusGrid.Rows.Add();
        //    cStatusGrid.Rows[index].Cells[0].Value = "初始化人脸识别";
        //    cStatusGrid.Rows[index].Cells[1].Value = "正在执行";
        //    var task = Task.Factory.StartNew(() =>
        //    {
        //        try
        //        {
        //            string model_path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        //            int n = Face.sdk_init(null);
        //            if (n != 0)
        //            {
        //                UpdateStatus("初始化人脸识别", "初始化失败", 2);
        //                _isPassed = false;
        //                Logger.Error(n);
        //            }
        //            else
        //            {
        //                FaceAbilityLoad.load_all_ability();
        //                bool authed = Face.is_auth();
        //                UpdateStatus("初始化人脸识别", "初始化成功", 1);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            UpdateStatus("初始化人脸识别", "初始化失败", 2);
        //            _isPassed = false;
        //            Logger.Error(ex);
        //        }
        //        _faceEnginePassed = true;
        //        InitManualEvent.Set();


        //    }, TaskCreationOptions.LongRunning);
        //    return task;


        //}




        private void InitSocketServer()
        {
            InitManualEvent.WaitOne();
            int index = cStatusGrid.Rows.Add();
            cStatusGrid.Rows[index].Cells[0].Value = "初始化Scoket监听";
            cStatusGrid.Rows[index].Cells[1].Value = "正在执行";
            CabinetServer.Init(AppConfig.ServerIP, AppConfig.ServerPort, AppConfig.CanIP);
        }

        private delegate void UpdateStatusDelegate(string itemName, string result, int color = 0);
        public void UpdateStatus(string itemName, string result, int color = 0)
        {
            try
            {
                if (cStatusGrid.InvokeRequired)
                {
                    UpdateStatusDelegate d = UpdateStatus;
                    cStatusGrid.Invoke(d, itemName, result, color);
                }
                else
                {
                    for (int i = 0; i < cStatusGrid.Rows.Count; i++)
                    {
                        if (cStatusGrid.Rows[i].Cells[0].Value == itemName)
                        {
                            cStatusGrid.Rows[i].Cells[1].Value = result;
                            if (color == 1) cStatusGrid.Rows[i].Cells[1].Style = _ctGreen;//(i, 2, _ctGreen);
                            else if (color == 2) cStatusGrid.Rows[i].Cells[1].Style = _ctRed;//(i, 2, _ctRed);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public void OnCabinetInitDone(string result)
        {
            try
            {
                Invoke(new OnCabinetInitDoneDelegate(OnCabinetInitDoneMtd), result);
            }
            catch (Exception)
            {
                // ignored
            }
        }
        private delegate void OnCabinetInitDoneDelegate(string result);
        public void OnCabinetInitDoneMtd(string result)
        {
            try
            {
                int state = 2;
                if (!result.Contains("成功"))
                {
                    _isPassed = false;
                }
                else
                {
                    state = 1;
                }
                UpdateStatus("初始化Scoket监听", result, state);
                if (!_isPassed)
                {
                    using (FormMessageBox messageBox = new FormMessageBox("初始化过程出现错误，是否继续?", "提示", 1, 5000))
                    {
                        messageBox.ShowDialog();
                        if (messageBox.Result == 20)
                        {
                            Application.Exit();
                            return;
                        }
                    }
                }
                if (AppConfig.InitDB == 1)
                {
                    Thread.Sleep(1500);
                    IList<string> doorList = new List<string>();
                    foreach (DoorInfo di in CabinetServer.GetDoorList())
                    {
                        doorList.Add(di.Id + "|" + di.Nch);
                    }
                    int initDBResult = BllLatticeInfo.InitLattice(doorList, AppConfig.LabName, AppConfig.Location, out Exception ex);
                    if (initDBResult <= 0)
                    {
                        using (FormMessageBox messageBox = new FormMessageBox($"初始化Lattice信息失败,原因:\n{ex.Message}", "提示", 1, 5000))
                        {
                            messageBox.ShowDialog();
                            Application.Exit();
                            return;
                        }
                    }
                }
                AppRt.IsInit = false;
                CabinetServerCallback.OnInitDone -= OnCabinetInitDone;
                Close();

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
