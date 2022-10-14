﻿using CabinetMgr.BLL;
using CabinetMgr.Common;
using CabinetMgr.Config;
using CabinetMgr.RtVars;
using Domain.Main.Domain;
using OpenCvSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testface;
using Utilities.Encryption;

namespace CabinetMgr
{
    public partial class FormUserEdit : UIForm
    {
        public static FormUserEdit formUserEdit;
        private static string userName;
        private VideoCapture cap;
        private Window windowVideo;
        private bool enableVideo = false;
        private Mat mat;
        private bool faceCap = false;

        public static FormUserEdit Instance(string name = "")
        {
            if (formUserEdit == null || formUserEdit.IsDisposed) formUserEdit = new FormUserEdit();
            userName = name;
            return formUserEdit;
        }

        public FormUserEdit()
        {
            InitializeComponent();
        }

        private void FormUserEdit_Load(object sender, EventArgs e)
        {

        }

        private void LoadData(string userName)
        {
            UserInfo ui = BllUserInfo.GetUserInfoByUserName(userName, out _);
            if (ui == null) return;

            uiTextBoxFullName.Text = ui.FullName;
            uiSwitchSex.Active = ui.Sex == "男";
            uiSwitchUserState.Active = ui.UserState == 1;
            if (!string.IsNullOrEmpty(ui.Image))
            {
                Bitmap image = (Bitmap)StrUtil.Base64StringToImage(ui.Image);
                pictureBoxFace.BackgroundImage = image;
            }
            else
            {
                pictureBoxFace.BackgroundImage = Properties.Resources.Avatar;
            }

        }

        private void uiButtonDetect_Click(object sender, EventArgs e)
        {
            windowVideo = new Window("windowVideo");
            windowVideo.Move(1, 1);
            cap = AppRt.VideoCaptureDevice;
            Mat image = new Mat();
            enableVideo = true;
            uiButtonCap.Visible = true;
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

                    //FaceDraw.draw_rects(ref image, faceSize, info);
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

        private void uiButtonCap_Click(object sender, EventArgs e)
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

                //FaceDraw.draw_rects(ref image, faceSize, info);
                //FaceDraw.draw_shape(ref image, faceSize, track_info);
                Marshal.FreeHGlobal(ptT);
                Cv2.WaitKey(1);
                enableVideo = false;
                windowVideo.Dispose();

                //if (File.Exists("PicCap.bmp"))
                //{
                //    File.Delete("PicCap.bmp");
                //    image.SaveImage("PicCap.bmp");
                //}
                MemoryStream ms = image.ToMemoryStream();
                mat = image;
                Bitmap bp = new Bitmap(ms);
                pictureBoxFace.BackgroundImage = bp;
                faceCap = true;
            }
        }

        private void uiButtonFingerFeature_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uiTextBoxUserName.Text.Trim()))
            {
                UIMessageBox.ShowError("请先输入工号", true, true);
            }

        }

        private void uiButtonFaceFeature_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uiTextBoxUserName.Text.Trim())) UIMessageBox.ShowError("请先输入工号", true, true);
            if(!faceCap) UIMessageBox.ShowError("请先进行拍照", true, true);
            UserInfo ui = BllUserInfo.GetUserInfoByUserName(uiTextBoxUserName.Text.Trim(), out Exception ex);
            Bitmap bp = (Bitmap)pictureBoxFace.BackgroundImage;
            if (bp != null && mat != null)
            {
                string image = StrUtil.ImageToBase64String(bp);
                if (image != ui.Image)
                {
                    ui.Image = image;
                    //string picPath = "PicCap.bmp";
                    FaceFeature faceFeature = new FaceFeature();
                    BDFaceFeature[] ff = faceFeature.test_get_face_feature_by_path(mat);
                    BDFaceFeature bDFaceFeature = ff[0];
                    byte[] faceByte = new byte[bDFaceFeature.data.Length * 4];
                    int j = 0;
                    for (int i = 0; i < bDFaceFeature.data.Length; i++)
                    {
                        Buffer.BlockCopy(BitConverter.GetBytes(bDFaceFeature.data[i]), 0, faceByte, j, 4);
                        j = j + 4;
                    }
                    ui.FaceFeature = faceByte;
                }
            }
            int result = BllUserInfo.UpdateUserInfo(ui, out ex);
            if(result <= 0)
            {
                UIMessageBox.ShowError($"保存失败，原因:{ex.Message}", true, true);
                return;
            }
            uiButtonCap.Visible = false;
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            int result = -1;
            if (string.IsNullOrEmpty(uiTextBoxUserName.Text.Trim())) UIMessageBox.ShowError("请先输入工号", true, true);
            if (string.IsNullOrEmpty(userName)) result = AddUserInfo();
            else result = UpdateUserInfo();
            if(result > 0)
            {
                userName = uiTextBoxUserName.Text.Trim();
                LoadData(userName);
            }
        }

        private int AddUserInfo()
        {
            if(string.IsNullOrEmpty(uiTextBoxPassword.Text)) UIMessageBox.ShowError("请输入密码", true, true);
            UserInfo ui = new UserInfo()
            {
                ID = Guid.NewGuid().ToString(),
                UserName = uiTextBoxUserName.Text.Trim(),
                Password = Md5Encode.Encode(uiTextBoxPassword.Text.Trim(), false),
                FullName = uiTextBoxFullName.Text.Trim(),
                Sex = uiSwitchSex.Active ? "男" : "女",
                UserState = uiSwitchUserState.Active ? 1 : 0,
                Createtime = DateTime.Now,
                Updatetime = Env.MinTime,
            };
            int result = BllUserInfo.SaveUserInfo(ui, out Exception ex);
            if(result <= 0)
            {
                UIMessageBox.ShowError($"保存失败，原因:{ex.Message}", true, true);
            }
            return result;
        }

        private int UpdateUserInfo()
        {
            if(uiTextBoxUserName.Text.Trim() != userName)
            {
                UserInfo tmpUser = BllUserInfo.GetUserInfoByUserName(uiTextBoxUserName.Text.Trim(), out _);
                if(tmpUser != null)
                {
                    UIMessageBox.ShowError($"该工号已被{tmpUser.FullName}使用", true, true);
                    return -1;
                }
            }
            UserInfo ui = BllUserInfo.GetUserInfoByUserName(userName, out _);
            if (!string.IsNullOrEmpty(uiTextBoxPassword.Text.Trim())) ui.Password = Md5Encode.Encode(uiTextBoxPassword.Text.Trim(), false);
            ui.UserName = uiTextBoxUserName.Text.Trim();
            ui.FullName = uiTextBoxFullName.Text.Trim();
            ui.Sex = uiSwitchSex.Active ? "男" : "女";
            ui.UserState = uiSwitchUserState.Active ? 1 : 0;
            ui.Updatetime = DateTime.Now;
            int result = BllUserInfo.UpdateUserInfo(ui, out Exception ex);
            if (result <= 0)
            {
                UIMessageBox.ShowError($"保存失败，原因:{ex.Message}", true, true);
            }
            return result;
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            enableVideo = false;
            windowVideo?.Dispose();
            FormReset();
            Hide();
        }

        private void FormReset()
        {
            userName = "";
            uiTextBoxUserName.Text = "";
            uiTextBoxPassword.Text = "";
            uiTextBoxFullName.Text = "";
            uiSwitchSex.Active = true;
            uiSwitchUserState.Active = true;
            pictureBoxFace.BackgroundImage = Properties.Resources.Avatar;
            uiButtonCap.Visible = false;
            faceCap = false;
        }

        private void FormUserEdit_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userName)) return;
            uiTextBoxUserName.Text = userName;
            LoadData(userName);
        }

        private void FormUserEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            enableVideo = false;
            windowVideo?.Dispose();
            FormReset();
            Hide();
        }
    }
}
