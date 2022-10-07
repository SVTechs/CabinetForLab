using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 佩戴口罩检测
namespace testface
{
    /**
        * @brief   佩戴口罩检测
        */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // 佩戴口罩检测
    struct BDFaceMouthMask
    {
        public float score; //置信度分值
    };
    /**
        * @brief   
        */

    // 佩戴口罩检测
    class FaceMouthMask
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_mouth_mask", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern int face_mouth_mask(IntPtr ptr, IntPtr mat);

        public void test_get_face_mouth_mask()
        {
            Mat mat = Cv2.ImRead("../images/mask.jpg");     
            get_face_mouth_mask(mat);
        }
        // 佩戴口罩检测
        public void get_face_mouth_mask(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceMouthMask[] info = new BDFaceMouthMask[max_face_num];
            int size = Marshal.SizeOf(typeof(BDFaceMouthMask));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);

            int faceNum = face_mouth_mask(ptT, mat.CvPtr);
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

                info[index] = (BDFaceMouthMask)Marshal.PtrToStructure(ptr, typeof(BDFaceMouthMask));
                // 是否佩戴口罩信度分值
                Console.WriteLine("mouth mask score is {0}:", info[index].score);
            }
            Marshal.FreeHGlobal(ptT);
        }
    }
}
