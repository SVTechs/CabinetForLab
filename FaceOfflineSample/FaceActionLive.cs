using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 动作活体
namespace testface
{

    /**
     * @brief   动作活体类型枚举
     */
    public enum BDFaceActionLiveType
    {
        BDFACE_ACTION_LIVE_BLINK = 0,           // 眨眨眼
        BDFACE_ACTION_LIVE_OPEN_MOUTH = 1,      // 张张嘴
        BDFACE_ACTION_LIVE_NOD = 2,             // 点点头
        BDFACE_ACTION_LIVE_SHAKE_HEAD = 3,      // 摇摇头
        BDFACE_ACTION_LIVE_LOOK_UP = 4,         // 抬头
        BDFACE_ACTION_LIVE_TURN_LEFT = 5,       // 向左转
        BDFACE_ACTION_LIVE_TURN_RIGHT = 6,      // 向右转
    };
   
    // 活体动作示例及接口
    class FaceActionLive
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_action_live", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        // 返回int为人脸个数，action_type为传入的活体动作, action_result为1时候表示存在传入的活体动作
        private static extern int face_action_live(IntPtr ptr, int action_type, ref int action_result, IntPtr mat);

        [DllImport("BaiduFaceApi.dll", EntryPoint = "action_live_clear_history", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        //清除动作活体历史
        private static extern int action_live_clear_history();
        

        // 测试获取人脸属性(打开usb摄像头，可用笔记本自带,亦可接入自带摄像头)
        public void test_action_live()
        {
            // 摄像头编号，默认为0，若外接，则可能为1，请根据实际情况修改
            int dev = 0;
            using (var window = new Window("face"))
            using (VideoCapture cap = VideoCapture.FromCamera(dev))
            {
                if (!cap.IsOpened())
                {
                    Console.WriteLine("open camera error");
                    return;
                }
                // Frame image buffer
                Mat image = new Mat();
                FaceAttr attr = new FaceAttr();
                // When the movie playback reaches end, Mat.data becomes NULL.
                while (true)
                {
                    cap.Read(image); // same as cvQueryFrame
                    if (!image.Empty())
                    {
                        int ilen = 10;//传入的人脸数
                        BDFaceBBox[] info = new BDFaceBBox[ilen];
                        
                        int sizeTrack = Marshal.SizeOf(typeof(BDFaceBBox));
                        IntPtr ptT = Marshal.AllocHGlobal(sizeTrack * ilen);
                        //Cv2.ImWrite("usb_track_Cv2.jpg", image);
                       
                        int faceSize = ilen;//返回人脸数  分配人脸数和检测到人脸数的最小值
                        int curSize = ilen;//当前人脸数 输入分配的人脸数，输出实际检测到的人脸数
                        // 假设校验活体动作：眨眨眼 （其他动作的校验以此类推）
                        int action_type = (int)BDFaceActionLiveType.BDFACE_ACTION_LIVE_BLINK;
                        int action_result = 0;
                        
                        faceSize = face_action_live(ptT, action_type, ref action_result, image.CvPtr);
                        // 返回为1表示存在该动作(请眨眨眼测试验证)
                        if (action_result == 1)
                        {
                            Console.WriteLine("--------------action check success------------------");
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
                            Console.WriteLine("in action live face_id is {0}:", info[index].index);

                            Console.WriteLine("in action live score is:{0:f}", info[index].score);
                            // 角度
                            Console.WriteLine("in action live mAngle is:{0:f}", info[index].angle);
                            // 人脸宽度
                            Console.WriteLine("in action live mWidth is:{0:f}", info[index].width);
                            // 中心点X,Y坐标
                            Console.WriteLine("in action live mCenter_x is:{0:f}", info[index].center_x);
                            Console.WriteLine("in action live mCenter_y is:{0:f}", info[index].center_y);

                        }
                        // 绘制人脸框
                        FaceDraw.draw_rects(ref image, faceSize, info);
                        
                        Marshal.FreeHGlobal(ptT);
                        window.ShowImage(image);
                        Cv2.WaitKey(1);
                    }
                    else
                    {
                        Console.WriteLine("mat is empty");
                    }
                }           
            }
        }
        
    }
}
