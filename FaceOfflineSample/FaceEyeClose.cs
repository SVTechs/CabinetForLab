using System;
using System.Runtime.InteropServices;
using OpenCvSharp;


namespace testface
{
    /**
         * @brief   人眼闭合状态结构体
         */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct BDFaceEyeClose
    {
        public float left_eye_close_conf;      // 左眼闭合的置信度
        public float right_eye_close_conf;     // 右眼闭合的置信度
    };

    /**
        * @brief   
        */

    // 眼部状态检测
    class FaceEyeClose
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_eye_close", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        public static extern int face_eye_close(IntPtr ptr, IntPtr mat);
        
        public void test_get_face_eye_close()
        {
            string img_rgb = "../images/rgb.png";
            Mat mat = Cv2.ImRead(img_rgb);
            get_face_eye_close(mat);
        }
        // 眼部状态检测
        public void get_face_eye_close(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceEyeClose[] info = new BDFaceEyeClose[max_face_num];
            int size = Marshal.SizeOf(typeof(BDFaceEyeClose));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);

            int faceNum = face_eye_close(ptT, mat.CvPtr);
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

                info[index] = (BDFaceEyeClose)Marshal.PtrToStructure(ptr, typeof(BDFaceEyeClose));
                // 左眼闭合置信度
                Console.WriteLine("left eye close conf is {0}:", info[index].left_eye_close_conf);
                // 右眼闭合置信度
                Console.WriteLine("left eye close conf is {0}:", info[index].right_eye_close_conf);
            }
            Marshal.FreeHGlobal(ptT);
        }       
    }
}
