using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸关键点
namespace testface
{
    // 人脸关键点
    class FaceLandmarkDemo
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_landmark", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        // type:(0表示rgb人脸关键点，采用accurate模型，1表示rgb人脸关键点，采用fast模型，2表示ir人脸关键点，采用accurate模型)
        private static extern int face_landmark(IntPtr ptr, IntPtr mat, int type = 0);

        public void test_get_face_landmark()
        {
            Mat mat = Cv2.ImRead("../images/1.jpg");
            get_face_landmark(mat);
        }
        // 人脸关键点
        public void get_face_landmark(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceLandmark[] info = new BDFaceLandmark[max_face_num];
            for (int i = 0; i < max_face_num; i++)
            {             
                info[i].data = new float[144];
                info[i].size = 0;
                info[i].score = 0;
                info[i].index = 0;
            }
            int size = Marshal.SizeOf(typeof(BDFaceLandmark));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);
            // type 0: 表示rgb人脸关键点，采用accurate模型，1表示rgb人脸关键点，采用fast模型，2表示ir人脸关键点，采用accurate模型
            int type = 2;
            int faceNum = face_landmark(ptT, mat.CvPtr, type);
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

                info[index] = (BDFaceLandmark)Marshal.PtrToStructure(ptr, typeof(BDFaceLandmark));
                Console.WriteLine("landmark size is {0}:", info[index].size);
                for (int j = 0; j < info[index].size; j++)
                {
                    Console.WriteLine("landmark is {0}:", info[index].data[j]);
                }
                
            }
           // FaceDraw.draw_landmark(ref mat, faceNum, info);
            // 打开注释，可把图片保存到本地，查看人脸关键点绘制情况
          //  mat.ImWrite("landmark.jpg");
            Marshal.FreeHGlobal(ptT);
        }
    }
}
