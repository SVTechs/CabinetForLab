using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸光照检测
namespace testface
{
    /**
        * @brief   光照
        */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // 光照
    struct BDFaceIllumination
    {
        public int score; //置信度分值
    };
    /**
        * @brief   
        */

    // 人脸光照检测
    class FaceIllumination
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_illumination", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern int face_illumination(IntPtr ptr, IntPtr mat);

        public void test_get_face_illumination()
        {
            string img_rgb = "../images/rgb.png";
            Mat mat = Cv2.ImRead(img_rgb);
            get_face_illumination(mat);            
        }
        // 人脸光照检测
        public void get_face_illumination(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceIllumination[] info = new BDFaceIllumination[max_face_num];
            int size = Marshal.SizeOf(typeof(BDFaceIllumination));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);

            int faceNum = face_illumination(ptT, mat.CvPtr);
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

                info[index] = (BDFaceIllumination)Marshal.PtrToStructure(ptr, typeof(BDFaceIllumination));
                // 光照置信度分值
                Console.WriteLine("illumination value is {0}:", info[index].score);
            }
            Marshal.FreeHGlobal(ptT);
        }
    }
}
