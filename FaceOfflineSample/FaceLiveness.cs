using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using OpenCvSharp;

namespace testface
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // 活体分值
    struct BDLivenessScore
    {
        public float score; //分值
    };
    // 活体检测
    public class FaceLiveness
    {
        // 单目RGB静默活体检测
        [DllImport("BaiduFaceApi.dll", EntryPoint = "rgb_liveness", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern int rgb_liveness(IntPtr ptr_trackinfo, IntPtr ptr_score, IntPtr mat);

        // 单目近红外静默活体检测
        [DllImport("BaiduFaceApi.dll", EntryPoint = "nir_liveness", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern int nir_liveness(IntPtr ptr_trackinfo, IntPtr ptr_score, IntPtr mat);

        // 双目深度静默活体检测
        [DllImport("BaiduFaceApi.dll", EntryPoint = "rgb_depth_liveness", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern int rgb_depth_liveness(IntPtr ptr_trackinfo, IntPtr ptr_rgbscore, IntPtr ptr_depthcore, IntPtr rgb_mat, IntPtr depth_mat);
              

        public void test_liveness_by_image()
        {
            // rgb 活体检测
            string img_rgb = "../images/rgb.png";
            liveness_check(img_rgb, 0);
            // nir 活体检测
            string img_nir = "../images/nir.png";
           // liveness_check(img_nir, 1);
           
        }

        // 测试单目RGB静默活体检测（传入图片文件路径，活体类型)
        public float liveness_check(string img_path, int live_type)
        {
            Mat mat = Cv2.ImRead(img_path);
            int max_face_num = 1; // 活体仅返回一个人脸，多人取最大人脸

            BDFaceTrackInfo[] track_info = new BDFaceTrackInfo[max_face_num];
            for (int i = 0; i < max_face_num; i++)
            {
                track_info[i] = new BDFaceTrackInfo();
                track_info[i].box = new BDFaceBBox();
                track_info[i].box.score = 0;
                track_info[i].box.width = 0;
                track_info[i].landmark.data = new float[144];
                track_info[i].face_id = 0;
            }
            int sizeTrack = Marshal.SizeOf(typeof(BDFaceTrackInfo));
            IntPtr ptT = Marshal.AllocHGlobal(sizeTrack * max_face_num);
           

            BDLivenessScore[] score_info = new BDLivenessScore[max_face_num];
            int sizeScore = Marshal.SizeOf(typeof(BDLivenessScore));
            IntPtr ptS = Marshal.AllocHGlobal(sizeScore * max_face_num);
            // faceNum为返回的检测到的人脸个数
            int faceNum = 0;
            if (live_type == 0)
            {
                faceNum = rgb_liveness(ptT, ptS, mat.CvPtr);
            }
            else if (live_type == 1)
            {
                faceNum = nir_liveness(ptT, ptS, mat.CvPtr);
            }
           
             
            //Console.WriteLine("faceSize is:" + faceNum);
            for (int index = 0; index < faceNum; index++)
            {

                IntPtr ptr = new IntPtr();
                IntPtr ptrScore = new IntPtr();
                if (8 == IntPtr.Size)
                {
                    ptr = (IntPtr)(ptT.ToInt64() + sizeTrack * index);
                    ptrScore = (IntPtr)(ptS.ToInt64() + sizeScore * index);
                }
                else if (4 == IntPtr.Size)
                {
                    ptr = (IntPtr)(ptT.ToInt32() + sizeTrack * index);
                    ptrScore = (IntPtr)(ptS.ToInt32() + sizeScore * index);
                }

                track_info[index] = (BDFaceTrackInfo)Marshal.PtrToStructure(ptr, typeof(BDFaceTrackInfo));

                score_info[index] = (BDLivenessScore)Marshal.PtrToStructure(ptrScore, typeof(BDLivenessScore));
                //Console.WriteLine("track face_id is {0}:", track_info[index].face_id);
                //Console.WriteLine("track landmarks is:");
                //// 索引值
                //Console.WriteLine("track index is:{0}", track_info[index].box.index);
                //// 置信度
                //Console.WriteLine("track score is:{0}", track_info[index].box.score);
                //// 角度
                //Console.WriteLine("track mAngle is:{0}", track_info[index].box.angle);
                //// 人脸宽度
                //Console.WriteLine("track mWidth is:{0}", track_info[index].box.width);
                //// 中心点X,Y坐标
                //Console.WriteLine("track mCenter_x is:{0}", track_info[index].box.center_x);
                //Console.WriteLine("track mCenter_y is:{0}", track_info[index].box.center_y);
                //// rgb 活体分值
                //Console.WriteLine("liveness score is:{0}", score_info[index].score);

            }
            Marshal.FreeHGlobal(ptT);
            return score_info[0].score;
        }

        public float liveness_check(Mat mat, int live_type)
        {
            int max_face_num = 1; // 活体仅返回一个人脸，多人取最大人脸

            BDFaceTrackInfo[] track_info = new BDFaceTrackInfo[max_face_num];
            for (int i = 0; i < max_face_num; i++)
            {
                track_info[i] = new BDFaceTrackInfo();
                track_info[i].box = new BDFaceBBox();
                track_info[i].box.score = 0;
                track_info[i].box.width = 0;
                track_info[i].landmark.data = new float[144];
                track_info[i].face_id = 0;
            }
            int sizeTrack = Marshal.SizeOf(typeof(BDFaceTrackInfo));
            IntPtr ptT = Marshal.AllocHGlobal(sizeTrack * max_face_num);


            BDLivenessScore[] score_info = new BDLivenessScore[max_face_num];
            int sizeScore = Marshal.SizeOf(typeof(BDLivenessScore));
            IntPtr ptS = Marshal.AllocHGlobal(sizeScore * max_face_num);
            // faceNum为返回的检测到的人脸个数
            int faceNum = 0;
            if (live_type == 0)
            {
                faceNum = rgb_liveness(ptT, ptS, mat.CvPtr);
            }
            else if (live_type == 1)
            {
                faceNum = nir_liveness(ptT, ptS, mat.CvPtr);
            }


            //Console.WriteLine("faceSize is:" + faceNum);
            for (int index = 0; index < faceNum; index++)
            {

                IntPtr ptr = new IntPtr();
                IntPtr ptrScore = new IntPtr();
                if (8 == IntPtr.Size)
                {
                    ptr = (IntPtr)(ptT.ToInt64() + sizeTrack * index);
                    ptrScore = (IntPtr)(ptS.ToInt64() + sizeScore * index);
                }
                else if (4 == IntPtr.Size)
                {
                    ptr = (IntPtr)(ptT.ToInt32() + sizeTrack * index);
                    ptrScore = (IntPtr)(ptS.ToInt32() + sizeScore * index);
                }

                track_info[index] = (BDFaceTrackInfo)Marshal.PtrToStructure(ptr, typeof(BDFaceTrackInfo));

                score_info[index] = (BDLivenessScore)Marshal.PtrToStructure(ptrScore, typeof(BDLivenessScore));
                //Console.WriteLine("track face_id is {0}:", track_info[index].face_id);
                //Console.WriteLine("track landmarks is:");
                //// 索引值
                //Console.WriteLine("track index is:{0}", track_info[index].box.index);
                //// 置信度
                //Console.WriteLine("track score is:{0}", track_info[index].box.score);
                //// 角度
                //Console.WriteLine("track mAngle is:{0}", track_info[index].box.angle);
                //// 人脸宽度
                //Console.WriteLine("track mWidth is:{0}", track_info[index].box.width);
                //// 中心点X,Y坐标
                //Console.WriteLine("track mCenter_x is:{0}", track_info[index].box.center_x);
                //Console.WriteLine("track mCenter_y is:{0}", track_info[index].box.center_y);
                //// rgb 活体分值
                //Console.WriteLine("liveness score is:{0}", score_info[index].score);

            }
            Marshal.FreeHGlobal(ptT);
            return score_info[0].score;
        }

        // 选择usb视频摄像头id,方法里面有获取连接的摄像头列表，包括id，名称和路径等
        public int select_usb_device_id()
        {
            ArrayList capDevs = new ArrayList();
            int device_id = 0;
            try
            {
                if (!File.Exists(Path.Combine(Environment.SystemDirectory, @"dpnhpast.dll")))
                {
                    Console.WriteLine("DirectX NOT installed!");
                    return - 1;
                }
                if (!DevEnum.GetDevicesOfCat(FilterCategory.VideoInputDevice, out capDevs))
                {
                    Console.WriteLine("No video capture devices found!");
                    return -1;
                }
                if (capDevs.Count < 2)
                {
                    Console.WriteLine("ir and rgb camera devices needed");
                    return -1;
                }
                foreach (DsDevice d in capDevs) {
                    Console.WriteLine("== VIDEO DEVICE (id:{0}) ==", d.id);
                    Console.WriteLine("Name: {0}", d.Name);
                    Console.WriteLine("Path: {0}", d.Path);
                }

                if (capDevs.Count > 0)
                {
                    device_id = ((DsDevice)capDevs[0]).id;
                    Console.WriteLine("select device id is:{0}", device_id);
                }
            }
            catch(Exception)
            {
                if (capDevs != null)
                {
                    foreach (DsDevice d in capDevs)
                        d.Dispose();
                    capDevs = null;
                }
                return -1;
            }
            return device_id;
        }

        // 双目RGB和IR静默活体检测（可使用迪威泰或视派尔等rgb+nir双目摄像头),rgb和nir的分值都通过如0.8才算活体通过
        public bool rgb_ir_liveness_check_mat()
        {
            int max_face_num = 1;//取最大人脸的活体
            BDLivenessScore[] rgb_score_info = new BDLivenessScore[max_face_num];
            BDLivenessScore[] nir_score_info = new BDLivenessScore[max_face_num];
            int sizeScore = Marshal.SizeOf(typeof(BDLivenessScore));
            IntPtr ptSRGB = Marshal.AllocHGlobal(sizeScore * max_face_num);
            IntPtr ptSNIR = Marshal.AllocHGlobal(sizeScore * max_face_num);

            // 初始化rgb 返回的人脸数据
            BDFaceTrackInfo[] rgb_track_info = new BDFaceTrackInfo[max_face_num];
            for (int i = 0; i < max_face_num; i++)
            {
                rgb_track_info[i].box = new BDFaceBBox();
                rgb_track_info[i].box.score = 0;
                rgb_track_info[i].box.width = 0;
                rgb_track_info[i].landmark.data = new float[144];
                rgb_track_info[i].face_id = 0;
            }
            int sizeTrack = Marshal.SizeOf(typeof(BDFaceTrackInfo));
            IntPtr ptTRGB = Marshal.AllocHGlobal(sizeTrack * max_face_num);

            // 初始化nir 返回的人脸数据
            BDFaceTrackInfo[] nir_track_info = new BDFaceTrackInfo[max_face_num];
            for (int i = 0; i < max_face_num; i++)
            {
                nir_track_info[i].box = new BDFaceBBox();
                nir_track_info[i].box.score = 0;
                nir_track_info[i].box.width = 0;
                nir_track_info[i].landmark.data = new float[144];
                nir_track_info[i].face_id = 0;
            }
            sizeTrack = Marshal.SizeOf(typeof(BDFaceTrackInfo));
            IntPtr ptTNIR = Marshal.AllocHGlobal(sizeTrack * max_face_num);

            // 序号0为电脑识别的usb摄像头编号，本demo中0为ir红外摄像头
            // 不同摄像头和电脑识别可能有区别
            // 编号一般从0-10   */            
            int device = select_usb_device_id();
            VideoCapture camera1 = VideoCapture.FromCamera(device);
            if(!camera1.IsOpened())
            {
                Console.WriteLine("camera1 open error");
                return false;
            }

            VideoCapture camera2 = VideoCapture.FromCamera(device+1);
            if (!camera2.IsOpened())
            {
                Console.WriteLine("camera2 open error");
                return false;
            }

            Mat frame1 = new Mat();
            Mat frame2 = new Mat();
            Mat rgb_mat = new Mat();
            Mat ir_mat = new Mat();
            var window_ir = new Window("ir_face");
            var window_rgb = new Window("rgb_face");
            while (true)
            {               
                camera1.Read(frame1);
                camera2.Read(frame2);
                if(!frame1.Empty() && !frame2.Empty())
                {                   
                    if (frame1.Channels() == 3)
                    {
                        rgb_mat = frame1;
                        ir_mat = frame2;
                    }
                    else
                    {
                        rgb_mat = frame2;
                        ir_mat = frame1;
                    }
                    float rgb_score = 0;
                    float ir_score = 0;                
                    int face_size = rgb_liveness(ptTRGB, ptSRGB, rgb_mat.CvPtr);                   
                    face_size = nir_liveness(ptTNIR, ptSNIR, ir_mat.CvPtr);
                    // 获取的人脸数
                    Console.WriteLine("faceNum is:{0}", face_size);
                    for (int index = 0; index < face_size; index++)
                    {
                        
                        IntPtr ptrTrack = new IntPtr();
                        IntPtr ptrRGBScore = new IntPtr();
                        IntPtr ptrNIRScore = new IntPtr();
                        if (8 == IntPtr.Size)
                        {
                            ptrTrack = (IntPtr)(ptTRGB.ToInt64() + sizeTrack * index);
                            ptrRGBScore = (IntPtr)(ptSRGB.ToInt64() + sizeScore * index);
                            ptrNIRScore = (IntPtr)(ptSNIR.ToInt64() + sizeScore * index);
                        }
                        else if (4 == IntPtr.Size)
                        {
                            ptrTrack = (IntPtr)(ptTRGB.ToInt32() + sizeTrack * index);
                            ptrRGBScore = (IntPtr)(ptSRGB.ToInt32() + sizeScore * index);
                            ptrNIRScore = (IntPtr)(ptSNIR.ToInt32() + sizeScore * index);
                        }
                        
                        rgb_track_info[index] = (BDFaceTrackInfo)Marshal.PtrToStructure(ptrTrack, typeof(BDFaceTrackInfo));
                        
                        rgb_score_info[index] = (BDLivenessScore)Marshal.PtrToStructure(ptrRGBScore, typeof(BDLivenessScore));
                        nir_score_info[index] = (BDLivenessScore)Marshal.PtrToStructure(ptrNIRScore, typeof(BDLivenessScore));
                        rgb_score = rgb_score_info[index].score;
                        ir_score = nir_score_info[index].score;
                        if (rgb_score <= 0.1f)
                        {
                            rgb_score = 0;
                        }
                        if (ir_score <= 0.1f)
                        {
                            ir_score = 0;
                        }
                        Console.WriteLine("demo ccccc");
                        // 角度
                        Console.WriteLine("mAngle is:{0:f}", rgb_track_info[index].box.angle);
                        // 人脸宽度
                        Console.WriteLine("mWidth is:{0:f}", rgb_track_info[index].box.width);
                        // 中心点X,Y坐标
                        Console.WriteLine("mCenter_x is:{0:f}", rgb_track_info[index].box.center_x);
                        Console.WriteLine("mCenter_y is:{0:f}", rgb_track_info[index].box.center_y);
                                          
                    }
                    
                    string msg_depth = "ir score is:" + ir_score.ToString();
                   
                    Cv2.PutText(ir_mat, msg_depth, new Point(20, 50), HersheyFonts.HersheyComplex, 1, new Scalar(255, 100, 0));
                   
                    string msg_rgb = "rgb score is:" + rgb_score.ToString();
                    Cv2.PutText(rgb_mat, msg_rgb, new Point(20, 50), HersheyFonts.HersheyComplex, 1, new Scalar(255, 100, 0));
                    if (face_size > 0)
                    {
                        // 画人脸框
                        FaceDraw.draw_rects(ref rgb_mat, face_size, rgb_track_info);
                        // 画关键点
                        // FaceDraw.draw_shape(ref rgb_mat, face_size, rgb_track_info);
                    }                   
                    window_rgb.ShowImage(rgb_mat);
                    window_ir.ShowImage(ir_mat);
                    Cv2.WaitKey(1);                   
                }
            }
            Marshal.FreeHGlobal(ptTRGB);
            Marshal.FreeHGlobal(ptTNIR);
            rgb_mat.Release();
            ir_mat.Release();
            frame1.Release();
            frame2.Release();
            Cv2.DestroyWindow("ir_face");
            Cv2.DestroyWindow("rgb_face");
            return true;
        }
        // 双目摄像头进行rgb,depth活体检测(此处适配了华杰艾米的双目摄像头)rgb和depth的分值都通过如0.8才算活体通过
        public bool rgb_depth_liveness_check_hjimi()
        {
            int max_face_num = 1;//取最大人脸的活体
          
            BDLivenessScore[] rgb_score_info = new BDLivenessScore[max_face_num];
            BDLivenessScore[] depth_score_info = new BDLivenessScore[max_face_num];
            int sizeScore = Marshal.SizeOf(typeof(BDLivenessScore));
            IntPtr ptRGBS = Marshal.AllocHGlobal(sizeScore * max_face_num);
            IntPtr ptDepthS = Marshal.AllocHGlobal(sizeScore * max_face_num);

            BDFaceTrackInfo[] track_info = new BDFaceTrackInfo[max_face_num];
            for (int i = 0; i < max_face_num; i++)
            {
                track_info[i].box = new BDFaceBBox();
                track_info[i].box.score = 0;
                track_info[i].box.width = 0;
                track_info[i].landmark.data = new float[144];
                track_info[i].face_id = 0;
            }
            int sizeTrack = Marshal.SizeOf(typeof(BDFaceTrackInfo));
            IntPtr ptT = Marshal.AllocHGlobal(sizeTrack * max_face_num);
            IntPtr phjimi = HjimiCamera.new_hjimi();
            var rgb_win = new Window("rgb", WindowMode.AutoSize);
            var depth_win = new Window("depth", WindowMode.Normal);
            float rgb_score = 0;
            float depth_score = 0;
            Mat cv_depth = new Mat();
            Mat cv_rgb = new Mat();
            while (true)
            {
                bool ok = HjimiCamera.open_hjimimat(phjimi, cv_rgb.CvPtr, cv_depth.CvPtr);
                if (!ok)
                {
                    depth_score = 0;
                    rgb_score = depth_score; 
                    Console.WriteLine("open camera faile");
                    continue;
                }
                if(cv_rgb.Empty())
                {
                    continue;
                }
                if (cv_depth.Empty())
                {
                    continue;
                }
                // 返回人脸个数
                int face_size = rgb_depth_liveness(ptT, ptRGBS, ptDepthS, cv_rgb.CvPtr, cv_depth.CvPtr);
                
                Console.WriteLine("res is:{0}", face_size);                             
                depth_score = 0;
                rgb_score = depth_score;                           
                for (int index = 0; index < face_size; index++)
                {
                    IntPtr ptrTrack = new IntPtr();
                    IntPtr ptrRGBScore = new IntPtr();
                    IntPtr ptrDepthScore = new IntPtr();
                    if (8 == IntPtr.Size)
                    {
                        ptrTrack = (IntPtr)(ptT.ToInt64() + sizeTrack * index);
                        ptrRGBScore = (IntPtr)(ptRGBS.ToInt64() + sizeScore * index);
                        ptrDepthScore = (IntPtr)(ptDepthS.ToInt64() + sizeScore * index);
                    }
                    else if (4 == IntPtr.Size)
                    {
                        ptrTrack = (IntPtr)(ptT.ToInt32() + sizeTrack * index);
                        ptrRGBScore = (IntPtr)(ptRGBS.ToInt32() + sizeScore * index);
                        ptrDepthScore = (IntPtr)(ptDepthS.ToInt32() + sizeScore * index);
                    }
                    
                    track_info[index] = (BDFaceTrackInfo)Marshal.PtrToStructure(ptrTrack, typeof(BDFaceTrackInfo));
                    Console.WriteLine("in Liveness::usb_track face_id is {0}:", track_info[index].face_id);
                    Console.WriteLine("landmarks is:");

                    rgb_score_info[index] = (BDLivenessScore)Marshal.PtrToStructure(ptrRGBScore, typeof(BDLivenessScore));
                    rgb_score = rgb_score_info[index].score;
                    depth_score_info[index] = (BDLivenessScore)Marshal.PtrToStructure(ptrDepthScore, typeof(BDLivenessScore));
                    depth_score = depth_score_info[index].score;
                    // 分值太低，会显示小数点太长，直接赋值0
                    if (depth_score <= 0.1f)
                    {
                        depth_score = 0;
                    }
                    if (rgb_score <= 0.1f)
                    {
                        rgb_score = 0;
                    }

                    // 角度
                    Console.WriteLine("mAngle is:{0:f}", track_info[index].box.angle);
                    // 人脸宽度
                    Console.WriteLine("mWidth is:{0:f}", track_info[index].box.width);
                    // 中心点X,Y坐标
                    Console.WriteLine("mCenter_x is:{0:f}", track_info[index].box.center_x);
                    Console.WriteLine("mCenter_y is:{0:f}", track_info[index].box.center_y);
                   
                } 
              

                Mat depth_img = new Mat();
                cv_depth.ConvertTo(depth_img, MatType.CV_8UC1, 255.0 / 4500);
                string msg_depth = "depth score is:" + depth_score.ToString();
                Cv2.PutText(depth_img, msg_depth, new Point(20, 50), HersheyFonts.HersheyComplex, 1, new Scalar(255, 100, 0));

                string msg_rgb = "rgb score is:" + rgb_score.ToString();
                Cv2.PutText(cv_rgb, msg_rgb, new Point(20, 50), HersheyFonts.HersheyComplex, 1, new Scalar(255, 100, 0));
                if (face_size > 0)
                {
                    // 画人脸框
                    FaceDraw.draw_rects(ref cv_rgb, face_size, track_info);
                    // 画关键点
                    FaceDraw.draw_shape(ref cv_rgb, face_size, track_info);
                }
                
                rgb_win.ShowImage(cv_rgb);
                depth_win.ShowImage(depth_img);
                Cv2.WaitKey(1);
                depth_img.Release();
            }
            Marshal.FreeHGlobal(ptT);
            cv_rgb.Release();
            cv_depth.Release();
            Cv2.DestroyWindow("rgb");
            Cv2.DestroyWindow("depth");
            HjimiCamera.hjimi_release(phjimi);
            return true;
        }
        //双目RGB和DEPTH静默活体检测（传入opencv视频帧)适配奥比中光海燕等双目摄像头
        public bool rgb_depth_liveness_check_orbe()
        {
            int max_face_num = 1;//取最大人脸的活体

            BDLivenessScore[] rgb_score_info = new BDLivenessScore[max_face_num];
            BDLivenessScore[] depth_score_info = new BDLivenessScore[max_face_num];
            int sizeScore = Marshal.SizeOf(typeof(BDLivenessScore));
            IntPtr ptRGBS = Marshal.AllocHGlobal(sizeScore * max_face_num);
            IntPtr ptDepthS = Marshal.AllocHGlobal(sizeScore * max_face_num);

            BDFaceTrackInfo[] track_info = new BDFaceTrackInfo[max_face_num];
            for (int i = 0; i < max_face_num; i++)
            {
                track_info[i].box = new BDFaceBBox();
                track_info[i].box.score = 0;
                track_info[i].box.width = 0;
                track_info[i].landmark.data = new float[144];
                track_info[i].face_id = 0;
            }
            int sizeTrack = Marshal.SizeOf(typeof(BDFaceTrackInfo));
            IntPtr ptT = Marshal.AllocHGlobal(sizeTrack * max_face_num);

            IntPtr porbe = OrbeCamera.new_orbe();
            var rgb_win = new Window("rgb", WindowMode.AutoSize);
            var depth_win = new Window("depth", WindowMode.Normal);
            float rgb_score = 0;
            float depth_score = 0;
            Mat cv_depth = new Mat();
            Mat cv_rgb = new Mat();
            while (true)
            {
                int res_ok = OrbeCamera.open_orbe(porbe, cv_rgb.CvPtr, cv_depth.CvPtr);
                if (res_ok != 0)
                {
                    depth_score = 0;
                    rgb_score = depth_score;
                    Console.WriteLine("open camera faile");
                    continue;
                }
                if (cv_rgb.Empty())
                {
                    continue;
                }
                if (cv_depth.Empty())
                {
                    continue;
                }
                // 返回人脸个数
                int face_size = rgb_depth_liveness(ptT, ptRGBS, ptDepthS, cv_rgb.CvPtr, cv_depth.CvPtr);

                Console.WriteLine("res is:{0}", face_size);
                depth_score = 0;
                rgb_score = depth_score;
                for (int index = 0; index < face_size; index++)
                {
                    IntPtr ptrTrack = new IntPtr();
                    IntPtr ptrRGBScore = new IntPtr();
                    IntPtr ptrDepthScore = new IntPtr();
                    if (8 == IntPtr.Size)
                    {
                        ptrTrack = (IntPtr)(ptT.ToInt64() + sizeTrack * index);
                        ptrRGBScore = (IntPtr)(ptRGBS.ToInt64() + sizeScore * index);
                        ptrDepthScore = (IntPtr)(ptDepthS.ToInt64() + sizeScore * index);
                    }
                    else if (4 == IntPtr.Size)
                    {
                        ptrTrack = (IntPtr)(ptT.ToInt32() + sizeTrack * index);
                        ptrRGBScore = (IntPtr)(ptRGBS.ToInt32() + sizeScore * index);
                        ptrDepthScore = (IntPtr)(ptDepthS.ToInt32() + sizeScore * index);
                    }

                    track_info[index] = (BDFaceTrackInfo)Marshal.PtrToStructure(ptrTrack, typeof(BDFaceTrackInfo));
                    Console.WriteLine("in Liveness::usb_track face_id is {0}:", track_info[index].face_id);
                    Console.WriteLine("landmarks is:");

                    rgb_score_info[index] = (BDLivenessScore)Marshal.PtrToStructure(ptrRGBScore, typeof(BDLivenessScore));
                    rgb_score = rgb_score_info[index].score;
                    depth_score_info[index] = (BDLivenessScore)Marshal.PtrToStructure(ptrDepthScore, typeof(BDLivenessScore));
                    depth_score = depth_score_info[index].score;
                    // 分值太低，会显示小数点太长，直接赋值0
                    if (depth_score <= 0.1f)
                    {
                        depth_score = 0;
                    }
                    if (rgb_score <= 0.1f)
                    {
                        rgb_score = 0;
                    }

                    // 角度
                    Console.WriteLine("mAngle is:{0:f}", track_info[index].box.angle);
                    // 人脸宽度
                    Console.WriteLine("mWidth is:{0:f}", track_info[index].box.width);
                    // 中心点X,Y坐标
                    Console.WriteLine("mCenter_x is:{0:f}", track_info[index].box.center_x);
                    Console.WriteLine("mCenter_y is:{0:f}", track_info[index].box.center_y);

                }


                Mat depth_img = new Mat();
                cv_depth.ConvertTo(depth_img, MatType.CV_8UC1, 255.0 / 4500);
                string msg_depth = "depth score is:" + depth_score.ToString();
                Cv2.PutText(depth_img, msg_depth, new Point(20, 50), HersheyFonts.HersheyComplex, 1, new Scalar(255, 100, 0));

                string msg_rgb = "rgb score is:" + rgb_score.ToString();
                Cv2.PutText(cv_rgb, msg_rgb, new Point(20, 50), HersheyFonts.HersheyComplex, 1, new Scalar(255, 100, 0));
                if (face_size > 0)
                {
                    // 画人脸框
                    FaceDraw.draw_rects(ref cv_rgb, face_size, track_info);
                    // 画关键点
                    // FaceDraw.draw_shape(ref cv_rgb, face_size, track_info);
                }
                rgb_win.ShowImage(cv_rgb);
                depth_win.ShowImage(depth_img);
                Cv2.WaitKey(1);
                depth_img.Release();
            }
            Marshal.FreeHGlobal(ptT);
            cv_rgb.Release();
            cv_depth.Release();
            Cv2.DestroyWindow("rgb");
            Cv2.DestroyWindow("depth");
            OrbeCamera.orbe_release(porbe);
            return true;
        }
             
        public void test_rgb_ir_liveness_check_by_opencv()
        {
            rgb_ir_liveness_check_mat();
        }

        // 双目RGB和DEPTH静默活体检测,适配奥比中光海燕等双目摄像头
        public void test_rgb_depth_liveness_check_by_orbe()
        {
            rgb_depth_liveness_check_orbe();
        }
      
        // 双目摄像头进行rgb,depth活体检测(此处适配了华杰艾米的双目摄像头)
        public void test_rgb_depth_liveness_check_by_hjimi()
        {
            rgb_depth_liveness_check_hjimi();
        }
    }
}
