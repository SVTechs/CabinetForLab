using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 注意力检测
namespace testface
{
    /**
         * @brief   双眼注意力信息
         */
    enum BDFaceGazeDirection
    {
        BDFACE_GAZE_DIRECTION_UP = 0,           // 向上看
        BDFACE_GAZE_DIRECTION_DOWN = 1,         // 向下看
        BDFACE_GAZE_DIRECTION_RIGHT = 2,        // 向右看
        BDFACE_GAZE_DIRECTION_LEFT = 3,         // 向左看
        BDFACE_GAZE_DIRECTION_FRONT = 4,        // 向前看
        BDFACE_GAZE_DIRECTION_EYE_CLOSE = 5,    // 闭眼
    };
    /**
     * @brief 注意力信息
     */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct BDFaceGaze
    {
        public BDFaceGazeDirection direction;      // 凝视方向
        public float confidence;                   // 置信度
    };

    /**
     * @brief   双眼注意力信息
     */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct BDFaceGazeInfo
    {
        public BDFaceGaze left_eye;    // 左眼注意力信息
        public BDFaceGaze right_eye;   // 右眼注意力信息
    };
    /**
        * @brief   
        */

    // 注意力检测
    class FaceGaze
    {
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_gaze", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern int face_gaze(IntPtr ptr, IntPtr mat);
    
        public void test_get_face_gaze()
        {
            string img_rgb = "../images/rgb.png";
            Mat mat = Cv2.ImRead(img_rgb);
            get_face_gaze(mat);
        }
        // 眼部状态检测
        public void get_face_gaze(Mat mat)
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceGazeInfo[] info = new BDFaceGazeInfo[max_face_num];
            int size = Marshal.SizeOf(typeof(BDFaceGazeInfo));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);

            int faceNum = face_gaze(ptT, mat.CvPtr);
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

                info[index] = (BDFaceGazeInfo)Marshal.PtrToStructure(ptr, typeof(BDFaceGazeInfo));
                // 左眼注意力
                Console.WriteLine("left eye direction is {0}:", info[index].left_eye.direction);
                // 左眼注意力置信度
                Console.WriteLine("left eye conf is {0}:", info[index].left_eye.confidence);
                // 右眼注意力
                Console.WriteLine("right eye direction is {0}:", info[index].right_eye.direction);
                // 右眼注意力置信度
                Console.WriteLine("right eye conf is {0}:", info[index].right_eye.confidence);

            }
            Marshal.FreeHGlobal(ptT);
        }
    }
}
