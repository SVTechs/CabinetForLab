using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸模糊度检测
namespace testface
{
    /**
        * @brief   模糊度
        */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // 模糊度
    struct BDFaceBlur
    {
        public float score; //置信度分值
    };
    /**
        * @brief   
        */

    // 人脸模糊度检测
    class FaceBlur
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_blur", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern int face_blur(IntPtr ptr, IntPtr mat);

        public void test_get_face_blur()
        {
            string img_rgb = "../images/rgb.png";
            Mat mat = Cv2.ImRead(img_rgb);
            get_face_blur(mat);
        }
        // 人脸模糊度检测
        public void get_face_blur(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceBlur[] info = new BDFaceBlur[max_face_num];
            int size = Marshal.SizeOf(typeof(BDFaceBlur));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);

            int faceNum = face_blur(ptT, mat.CvPtr);
            Console.WriteLine("faceNum is:" + faceNum);
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

                info[index] = (BDFaceBlur)Marshal.PtrToStructure(ptr, typeof(BDFaceBlur));
                // 模糊度分值
                Console.WriteLine("face blur score is {0}:", info[index].score);
            }
            Marshal.FreeHGlobal(ptT);
        }
    }
}
