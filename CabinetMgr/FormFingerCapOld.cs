using CabinetMgr.RtVars;
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
    public partial class FormFingerCapOld : UIForm
    {
        public static FormFingerCapOld formFingerCap;
        private static int capTimes = 3;
        private Bitmap bmp = new Bitmap(192, 192);//指纹图片
        private static int templateId;
        //private static int pageId;
        public byte[] fingerTemplate;
        Thread CollectionThread;

        public static FormFingerCapOld Instance(int id)
        {
            if (formFingerCap == null || formFingerCap.IsDisposed) formFingerCap = new FormFingerCapOld();
            templateId = id;
            return formFingerCap;
        }

        public FormFingerCapOld()
        {
            InitializeComponent();
        }

        public void FormReset()
        {
            pictureBoxFingerBmp.BackgroundImage = new Bitmap(192, 192);
            fingerTemplate = null;
            uiLabelPressRemind.Text = "";
            uiLabelCapTimesCount.Text = "";
            richTextBoxErrMsg.Text = "";
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


        private delegate void SetBtnEnableDelegate(UIButton button, bool enable);
        private void SetBtnEnable(UIButton button, bool enable)
        {
            if (button.InvokeRequired)
            {
                SetBtnEnableDelegate d = SetBtnEnable;
                button.Invoke(d, button, enable);
            }
            else
            {
                button.Enabled = enable;
            }
        }

        private delegate void RichTextBoxAddStrDelegate(RichTextBox rtb, string msg);
        private void RichTextBoxAddStr(RichTextBox rtb, string msg)
        {
            if (rtb.InvokeRequired)
            {
                RichTextBoxAddStrDelegate d = RichTextBoxAddStr;
                rtb.Invoke(d, rtb, msg);
            }
            else
            {
                rtb.AppendText(msg + "\n");
            }
        }


        #endregion

        private void uiButtonStartCap_Click(object sender, EventArgs e)
        {
            CollectionThread = new Thread(new ThreadStart(FigerCollection));
            CollectionThread.Start();
            SetBtnEnable(uiButtonStopCap, true);
            SetBtnEnable(uiButtonStartCap, false);
        }

        private void uiButtonStopCap_Click(object sender, EventArgs e)
        {
            SetBtnEnable(uiButtonStopCap, true);
            SetBtnEnable(uiButtonStartCap, false);
            CollectionThread?.Abort();
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
                        RichTextBoxAddStr(richTextBoxErrMsg, $"第{iFingerNum}次采集图像获取失败");
                        continue;
                    }

                    ret = FpDevice.GenChar(iFingerNum);//生成特征信息
                    if (ret != DriveOpration.PS_OK)
                    {
                        RichTextBoxAddStr(richTextBoxErrMsg, $"第{iFingerNum}次特征生成失败");
                        continue;
                    }
                    else
                    {
                        RichTextBoxAddStr(richTextBoxErrMsg, $"第{iFingerNum}次特征生成成功");
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
                        RichTextBoxAddStr(richTextBoxErrMsg, "合并特征失败");
                        continue;
                    }
                    ret = FpDevice.StoreChar(templateId);
                    if (ret != DriveOpration.PS_OK)
                    {
                        RichTextBoxAddStr(richTextBoxErrMsg, "模板保存失败");
                        continue;
                    }

                    byte[] chatData = new byte[3620];
                    templateLength = 0;
                    ret = FpDevice.UpChar(chatData, ref templateLength);
                    if (ret != DriveOpration.PS_OK)
                    {
                        RichTextBoxAddStr(richTextBoxErrMsg, "模板上传失败");
                        //continue;
                    }
                    RichTextBoxAddStr(richTextBoxErrMsg, "指纹采集成功!");
                    fingerTemplate = chatData;
                    break;
                }
                StopCollection();
            }

            catch (Exception ex)
            {
                CollectionThread?.Abort();
            }
            finally
            {
                SetBtnEnable(uiButtonStopCap, false);
                SetBtnEnable(uiButtonStartCap, true);
            }
        }


        //private void FigerCollection()
        //{
        //    try
        //    {
        //        bool IsCollection = false;
        //        SetBtnEnable(uiButtonStopCap, true);
        //        SetBtnEnable(uiButtonStartCap, false);
        //        do
        //        {
        //            SetLableText(uiLabelPressRemind, "请将手指平放在传感器上...");
        //            SetLableText(uiLabelCapTimesCount, $"当前第{capTimes+1}次");
        //            int ret = -1;
        //            do
        //            {
        //                ret = FpDevice.GetImage();
        //            }
        //            while (ret != DriveOpration.PS_OK);

        //            UInt16 templateLength = 0;
        //            byte[] imageData = new byte[256 * 288];
        //            ret = FpDevice.UpImage(out imageData, ref templateLength);//上传图片
        //            if (ret == DriveOpration.PS_OK)
        //            {
        //                ShowFingerPrint(imageData);
        //                SetLableText(uiLabelPressRemind, "请抬起手指");
        //            }
        //            else
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, $"第{capTimes + 1}次采集图像获取失败");
        //                continue;
        //            }

        //            ret = FpDevice.GenChar(1);//生成特征信息
        //            if (ret != DriveOpration.PS_OK)
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, $"第{capTimes + 1}次特征生成失败");
        //                continue;
        //            }
        //            capTimes++;
        //            SetLableText(uiLabelPressRemind, "请将手指平放在传感器上...");  //第二次获取指纹特征
        //            SetLableText(uiLabelCapTimesCount, $"当前第{capTimes + 1}次");
        //            ret = -1;
        //            do
        //            {
        //                ret = FpDevice.GetImage();
        //            }
        //            while (ret != DriveOpration.PS_OK);

        //            imageData = new byte[256 * 288];
        //            templateLength = 0;
        //            ret = FpDevice.UpImage(out imageData, ref templateLength);//上传图片
        //            if (ret == DriveOpration.PS_OK)
        //            {
        //                ShowFingerPrint(imageData);
        //                SetLableText(uiLabelPressRemind, "请抬起手指");
        //            }
        //            else
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, $"第{capTimes + 1}次采集图像获取失败");
        //                continue;
        //            }

        //            ret = FpDevice.GenChar(2);//生成特征信息
        //            if (ret != DriveOpration.PS_OK)
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, $"第{capTimes + 1}次特征生成失败");
        //                continue;
        //            }
        //            int matchPoint = 0;
        //            ret = FpDevice.Match(ref matchPoint);
        //            if (ret == DriveOpration.PS_NOT_MATCH)
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, "特征比对失败：请重新采集");
        //                continue;
        //            }
        //            else if (ret != DriveOpration.PS_OK)
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, $"特征比对失败：错误码{ret}");
        //                continue;
        //            }

        //            ret = FpDevice.RegModule();  //合并特征
        //            if (ret != DriveOpration.PS_OK)
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, "合并特征失败");
        //                continue;
        //            }

        //            //ret = DriveOpration.PSEmpty(DeviceHandle, N_ADDR);
        //            //if (ret != DriveOpration.PS_OK)
        //            //{
        //            //    ShowErrorMess(ret);
        //            //    continue;
        //            //}
        //            ret = FpDevice.StoreChar(bufferId, pageId);
        //            if (ret != DriveOpration.PS_OK)
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, "模板保存失败");
        //                continue;
        //            }
        //            //ret = DriveOpration.PSLoadChar(DeviceHandle, N_ADDR, 1, 0);
        //            //if (ret != DriveOpration.PS_OK)
        //            //{
        //            //    ShowErrorMess(ret);
        //            //    continue;
        //            //}
        //            byte[] chatData = new byte[1024];
        //            templateLength = 0;
        //            ret = FpDevice.UpChar(bufferId, chatData, ref templateLength);
        //            if (ret != DriveOpration.PS_OK)
        //            {
        //                RichTextBoxAddStr(richTextBoxErrMsg, "模板上传失败");
        //                //continue;
        //            }
        //            RichTextBoxAddStr(richTextBoxErrMsg, "指纹采集成功!");
        //            IsCollection = true;
        //        }
        //        while (!IsCollection);
        //        StopCollection();
        //    }

        //    catch (Exception ex)
        //    {
        //        CollectionThread?.Abort();
        //    }
        //    finally
        //    {
        //        SetBtnEnable(uiButtonStopCap, false);
        //        SetBtnEnable(uiButtonStartCap, true);
        //    }
        //}

        private void StopCollection()
        {
            try
            {
                SetBtnEnable(uiButtonStopCap, true);
                SetBtnEnable(uiButtonStartCap, false);
                CollectionThread?.Abort();
                //FpDevice.CloseDeviceEx();

            }
            catch (Exception ex)
            {

            }
        }

        private void FormFingerCap_Shown(object sender, EventArgs e)
        {
            AppRt.FpEnable = false;
        }

        private void FormFingerCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppRt.FpEnable = true;
            FormReset();
            Hide();
        }
    }
}
