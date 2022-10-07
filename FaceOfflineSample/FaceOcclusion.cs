using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸遮挡度检测
namespace testface
{
    /**
        * @brief   遮挡度
        */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct BDFaceOcclusion
    {
        public float left_eye;    // 左眼遮挡置信度
        public float right_eye;   // 右眼遮挡置信度
        public float nose;        // 鼻子遮挡置信度
        public float mouth;       // 嘴巴遮挡置信度
        public float left_cheek;  // 左脸遮挡置信度
        public float right_cheek; // 右脸遮挡置信度
        public float chin;        // 下巴遮挡置信度
    };
    /**
        * @brief   
        */

    // 人脸遮挡度检测
    class FaceOcclusion
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_occlusion", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern int face_occlusion(IntPtr ptr, IntPtr mat);

        public void test_get_face_occlusion()
        {
            Mat mat = Cv2.ImRead("../images/1.jpg");
            get_face_occlusion(mat);
        }
        // 人脸遮挡度检测
        public void get_face_occlusion(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceOcclusion[] info = new BDFaceOcclusion[max_face_num];
            for(int i = 0; i < max_face_num; i++)
            {
                info[i].left_eye = 0;
                info[i].right_eye = 0;
                info[i].nose = 0;
                info[i].mouth = 0;
                info[i].left_cheek = 0;
                info[i].right_cheek = 0;
                info[i].chin = 0;
            }
            int size = Marshal.SizeOf(typeof(BDFaceOcclusion));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);

            int faceNum = face_occlusion(ptT, mat.CvPtr);
            Console.WriteLine("faceNum is:" + faceNum);
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

                info[index] = (BDFaceOcclusion)Marshal.PtrToStructure(ptr, typeof(BDFaceOcclusion));
                // 左眼遮挡置信度
                Console.WriteLine("left eye occlu score is {0}:", info[index].left_eye);
                // 右眼遮挡置信度
                Console.WriteLine("right eye occlu score is {0}:", info[index].right_eye);
                // 鼻子遮挡置信度
                Console.WriteLine("nose occlu score is {0}:", info[index].nose);
                // 嘴巴遮挡置信度
                Console.WriteLine("mouth occlu score  is {0}:", info[index].mouth);
                // 左脸遮挡置信度
                Console.WriteLine("left cheek occlu score is {0}:", info[index].left_cheek);
                // 右脸遮挡置信度
                Console.WriteLine("right cheek occlu score is {0}:", info[index].right_cheek);
                // 下巴遮挡置信度
                Console.WriteLine("chin occlu score is {0}:", info[index].chin);
            }
            Marshal.FreeHGlobal(ptT);
        }
    }
}
