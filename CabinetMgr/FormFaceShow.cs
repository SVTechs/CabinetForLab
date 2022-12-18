using CabinetMgr.RtVars;
using NLog;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMgr
{
    public partial class FormFaceShow : Form
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static FormFaceShow formFaceShow;
        public static FormFaceShow Instance()
        {
            if (formFaceShow == null || formFaceShow.IsDisposed) formFaceShow = new FormFaceShow();
            return formFaceShow;
        }

        public FormFaceShow()
        {
            InitializeComponent();
            Location = new System.Drawing.Point(1, 1);
            Thread t = new Thread(FaceShow) { IsBackground = true };
            t.Start();
        }

        private void FaceShow()
        {
            try
            {
                VideoCapture cap = AppRt.VideoCaptureDevice;
                Mat image = new Mat();
                while (!AppRt.IsInit)
                {
                    if (cap == null) continue;
                    if (!Visible) continue;
                    if (!AppRt.FaceEnable) continue;
                    cap.Read(image);
                    MemoryStream ms = image.Clone().ToMemoryStream();
                    Bitmap bp = new Bitmap(ms);
                    SetPictureBoxBg(bp);
                }
            }
            catch (SEHException e)
            {
                Logger.Error(e);
            }
        }

        private delegate void SetPictureBoxBgDelegate(Bitmap pic);
        public void SetPictureBoxBg(Bitmap pic)
        {
            try
            {
                if (pictureBoxCapImg.InvokeRequired)
                {
                    SetPictureBoxBgDelegate d = SetPictureBoxBg;
                    pictureBoxCapImg.Invoke(d, pic);
                }
                else
                {
                    pictureBoxCapImg.BackgroundImage = pic;
                    pictureBoxCapImg.BackgroundImageLayout = ImageLayout.Stretch;

                }
            }
            catch (Exception)
            {
                // ignored
            }
        }


        private delegate void FormVisibleDelegate(bool visible);
        public void FormVisible(bool visible)
        {
            if (InvokeRequired)
            {
                FormVisibleDelegate d = FormVisible;
                Invoke(d, visible);
            }
            else
            {
                if (visible) Show();
                else Hide();
            }
        }

        private void FormFaceShow_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) Location = new System.Drawing.Point(1, 1);
        }
    }
}
