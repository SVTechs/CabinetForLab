using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 嘴巴闭合检测
namespace testface
{
    /**
        * @brief   嘴巴闭合
        */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // 嘴巴闭合
    struct BDFaceMouthClose
    {
        public float score; //置信度分值
    };
    /**
        * @brief   
        */

    // 嘴巴闭合检测
    class FaceMouthClose
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_mouth_close", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern int face_mouth_close(IntPtr ptr, IntPtr mat);

        public void test_get_face_mouth_close()
        {
            Mat mat = Cv2.ImRead("../images/1.jpg");
            get_face_mouth_close(mat);
        }
        // 嘴巴闭合检测
        public void get_face_mouth_close(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceMouthClose[] info = new BDFaceMouthClose[max_face_num];
            int size = Marshal.SizeOf(typeof(BDFaceMouthClose));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);

            int faceNum = face_mouth_close(ptT, mat.CvPtr);
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

                info[index] = (BDFaceMouthClose)Marshal.PtrToStructure(ptr, typeof(BDFaceMouthClose));
                // 嘴巴闭合置信度分值
                Console.WriteLine("mouth close score is {0}:", info[index].score);
            }
            Marshal.FreeHGlobal(ptT);
        }
    }
}
