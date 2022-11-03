using Hardware.DeviceInterface;
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
    public partial class FormFingerCap : Form
    {
        public static FormFingerCap formFingerCap;
        private static int capTimes = 3;
        private static long _templateId = -1;
        private Bitmap bmp = new Bitmap(192, 192);//指纹图片
        public byte[] fingerTemplate;
        Thread CollectionThread;

        public static FormFingerCap Instance(long templateId)
        {
            if (formFingerCap == null || formFingerCap.IsDisposed) formFingerCap = new FormFingerCap();
            _templateId = templateId;
            return formFingerCap;
        }

        public FormFingerCap()
        {
            InitializeComponent();
        }

        public void FormReset()
        {
            pictureBoxFingerBmp.BackgroundImage = new Bitmap(192, 192);
            fingerTemplate = null;
            uiLabelPressRemind.Text = "";
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

        private delegate void SetFormHideDelegate();
        private void SetFormHide()
        {
            if (InvokeRequired)
            {
                SetFormHideDelegate d = SetFormHide;
                Invoke(d);
            }
            else
            {
                Hide();
            }
            
        }

        #endregion

        private void FormFingerCap_Shown(object sender, EventArgs e)
        {
            CollectionThread = new Thread(new ThreadStart(FigerCollection));
            CollectionThread.Start();
        }

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

        private void FigerCollection()
        {
            try
            {
                int iFingerNum = 1;
                int ret = -1;
                while (iFingerNum <= capTimes)
                {
                    SetLableText(uiLabelPressRemind, "请按压手指");
                    SetLableText(uiLabelCapTimesCount, $"当前第{iFingerNum}次");
                    ret = FpDevice.GetImage();
                    if (ret != DriveOpration.PS_OK) continue;

                    SetLableText(uiLabelPressRemind, "请抬起手指");
                    byte[] imageData = new byte[192 * 192];
                    ushort templateLength = 0;
                    ret = FpDevice.UpImage(out imageData, ref templateLength);//上传图片
                    if (ret == DriveOpration.PS_OK)
                    {
                        ShowFingerPrint(imageData);
                    }
                    else
                    {
                        SetLableText(uiLabelCapTimesCount, $"第{iFingerNum}次采集图像获取失败");
                        continue;
                    }

                    ret = FpDevice.GenChar(iFingerNum);//生成特征信息
                    if (ret != DriveOpration.PS_OK)
                    {
                        SetLableText(uiLabelCapTimesCount, $"第{iFingerNum}次特征生成失败");
                        continue;
                    }
                    else
                    {
                        SetLableText(uiLabelCapTimesCount, $"第{iFingerNum}次特征生成成功");
                    }

                    Thread.Sleep(380);
                    if (iFingerNum < capTimes)
                    {
                        iFingerNum++;
                        Thread.Sleep(380);
                        continue;
                    }
                    iFingerNum++;//最后一次

                    ret = FpDevice.RegModule();  //合并特征
                    if (ret != DriveOpration.PS_OK)
                    {
                        SetLableText(uiLabelCapTimesCount, $"合并特征失败");
                        continue;
                    }
                    if(_templateId > 0)
                    {
                        ret = FpDevice.StoreChar((int)_templateId);
                    }
                    else
                    {
                        ret = FpDevice.StoreChar(199);
                    }
                    
                    if (ret != DriveOpration.PS_OK)
                    {
                        SetLableText(uiLabelCapTimesCount, $"模板保存失败");
                        continue;
                    }

                    byte[] chatData = new byte[3620];
                    templateLength = 0;
                    ret = FpDevice.UpChar(chatData, ref templateLength);
                    if (ret != DriveOpration.PS_OK)
                    {
                        SetLableText(uiLabelCapTimesCount, $"模板上传失败");
                        //continue;
                    }
                    SetLableText(uiLabelCapTimesCount, $"指纹采集成功");
                    fingerTemplate = chatData;
                    SetFormHide();
                    break;
                }
            }

            catch (Exception ex)
            {

            }
            finally
            {
                CollectionThread?.Abort();
            }
        }

        private void uiButtonStartCap_Click(object sender, EventArgs e)
        {
            FormReset();
            CollectionThread = new Thread(new ThreadStart(FigerCollection));
            CollectionThread.Start();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            FormReset();
            Hide();

        }
    }
}
