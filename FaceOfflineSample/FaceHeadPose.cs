using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸姿态角
namespace testface
{
    /**
        * @brief   姿态角
        */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct BDFaceHeadPose
    {
        public float yaw;        // 左右偏转角
        public float roll;       // 与人脸平行平面内的头部旋转角
        public float pitch;      // 上下偏转角
    };
    /**
        * @brief   
        */

    // 人脸姿态角检测
    class FaceHeadPose
    {
        // 获取姿态角
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_head_pose", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern int face_head_pose(IntPtr ptr, IntPtr mat);
        

        public void test_get_face_head_pose()
        {
            string img_rgb = "../images/rgb.png";          
            Mat mat = Cv2.ImRead(img_rgb);
            get_face_head_pose(mat);        
        }
        // 人脸姿态角检测
        public void get_face_head_pose(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceHeadPose[] info = new BDFaceHeadPose[max_face_num];
            int size = Marshal.SizeOf(typeof(BDFaceHeadPose));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);

            int faceNum = face_head_pose(ptT, mat.CvPtr);
            Console.WriteLine("faceNum is:" + faceNum);
            // 因为需预分配内存，所以返回的人脸数若大于预先分配的内存数，则仅仅显示预分配的人脸数
            if (faceNum > max_face_num)
            {
                faceNum = max_face_num;
            }
            for (int index = 0; index < faceNum; index++)
            {
                IntPtr ptr = new IntPtr();
                if (8 == IntPtr.Size)
                {
                    ptr = (IntPtr)(ptT.ToInt64() + size * index);
                }
                else if (4 == IntPtr.Size)
                {
                    ptr = (IntPtr)(ptT.ToInt32() + size * index);
                }

                info[index] = (BDFaceHeadPose)Marshal.PtrToStructure(ptr, typeof(BDFaceHeadPose));
                // 左右偏转角
                Console.WriteLine("yaw angle is {0}:", info[index].yaw);
                // 与人脸平行平面内的头部旋转角
                Console.WriteLine("roll angle is {0}:", info[index].roll);
                // 上下偏转角
                Console.WriteLine("pitch angle is {0}:", info[index].pitch);
                

            }
            Marshal.FreeHGlobal(ptT);
        }       
    }
}
