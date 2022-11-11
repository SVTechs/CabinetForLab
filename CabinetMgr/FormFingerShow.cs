using Hardware.DeviceInterface;
using NLog;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMgr
{
    public partial class FormFingerShow : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static FormFingerShow formFingerShow;
        private Bitmap bmp = new Bitmap(192, 192);//指纹图片

        public static FormFingerShow Instance()
        {
            if (formFingerShow == null || formFingerShow.IsDisposed) formFingerShow = new FormFingerShow();
            return formFingerShow;
        }

        public FormFingerShow()
        {
            InitializeComponent();
            Location = new System.Drawing.Point(1, 1);
        }

        #region delegate


        private delegate void SetPicBgDelegate(PictureBox pb, Bitmap pic);
        private void SetPicBg(PictureBox pb, Bitmap pic)
        {
            if (pb.InvokeRequired)
            {
                SetPicBgDelegate d = SetPicBg;
                pb.Invoke(d, pb, pic);
            }
            else
            {
                pb.BackgroundImage = pic;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private delegate void SetLableTextDelegate(Label lbl, string text);
        private void SetLableText(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                SetLableTextDelegate d = SetLableText;
                lbl.Invoke(d, lbl, text);
            }
            else
            {
                lbl.Text = text;
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

        #endregion

        public void ShowFingerPrint(byte[] rgbValues)
        {
            bmp = new Bitmap(192, 192);
            int pading = 30;
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    int value = (int)rgbValues[i * bmp.Width + j];
                    Color c = Color.FromArgb(value, value, value);

                    bmp.SetPixel(j, i, c);
                }
            }
            SetPicBg(pictureBoxFingerBmp, bmp);
        }

        public void SetResultLabelValue(string text)
        {
            SetLableText(uiLabelPressResult, text);
        }

        private void FormFingerShow_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) Location = new System.Drawing.Point(1, 1);
            else
            {
                SetPicBg(pictureBoxFingerBmp, new Bitmap(192, 192));
                SetLableText(uiLabelPressResult, "");
            }
        }
    }
}
