using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

namespace testface
{  
    /**
         * @brief   人脸表情属性枚举
         */
    enum BDFaceAttributeEmotionType
    {
        BDFACE_ATTRIBUTE_EMOTION_FROWN = 0,     // 皱眉
        BDFACE_ATTRIBUTE_EMOTION_SMILE = 1,     // 笑
        BDFACE_ATTRIBUTE_EMOTION_CALM = 2,      // 平静
    };

    /**
     * @brief   人脸种族属性枚举
     */
    enum BDFaceRace
    {
        BDFACE_RACE_YELLOW = 0, // 黄种人
        BDFACE_RACE_WHITE = 1,  // 白种人
        BDFACE_RACE_BLACK = 2,  // 黑种人
        BDFACE_RACE_INDIAN = 3, // 印第安人
    };

    /**
     * @brief   眼镜状态属性枚举
     */
    enum BDFaceGlasses
    {
        BDFACE_NO_GLASSES = 0,   // 无眼镜
        BDFACE_GLASSES = 1,      // 有眼镜
        BDFACE_SUN_GLASSES = 2,  // 墨镜
    };

    /**
     * @brief   性别属性枚举
     */
    enum BDFaceGender
    {
        BDFACE_GENDER_FEMAILE = 0, // 女性
        BDFACE_GENDER_MALE = 1,    // 男性
    };


    /**
     * @brief   人脸属性结构体
     */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct BDFaceAttribute
    {
        public int age;                            // 年龄
        public BDFaceRace race;                    // 种族
        public BDFaceAttributeEmotionType emotion; // 表情
        public BDFaceGlasses glasses;              // 戴眼镜状态
        public BDFaceGender gender;                // 性别
    };

    // 人脸属性示例及接口
    class FaceAttr
    {
        // 获取人脸属性
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_attr", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        public static extern int face_attr(IntPtr ptr, IntPtr mat);

        // 测试获取人脸属性
        public void test_get_face_attr()
        {
            int max_face_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50

            BDFaceAttribute[] attr_info = new BDFaceAttribute[max_face_num];
            int size = Marshal.SizeOf(typeof(BDFaceAttribute));
            IntPtr ptT = Marshal.AllocHGlobal(size * max_face_num);
            string img_path = "../images/rgb.png";
            Mat mat = Cv2.ImRead(img_path);
            int faceNum = face_attr(ptT, mat.CvPtr);
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

                attr_info[index] = (BDFaceAttribute)Marshal.PtrToStructure(ptr, typeof(BDFaceAttribute));
                // 年龄
                Console.WriteLine("age is {0}:", attr_info[index].age);
                // 种族
                Console.WriteLine("race is:{0}", attr_info[index].race);
                // 表情
                Console.WriteLine("emotion is:{0}", attr_info[index].emotion);
                // 戴眼镜状态
                Console.WriteLine("glasses is:{0}", attr_info[index].glasses);
                // 性别
                Console.WriteLine("gender is:{0}", attr_info[index].gender);
            }
            Marshal.FreeHGlobal(ptT);
        }
       
    }
}
