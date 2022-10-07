using System;
using System.Runtime.InteropServices;
using System.IO;
using OpenCvSharp;

// 人脸比对（备注：人脸比对，实际上是人脸的特征值比对，提取出人脸特征值，用compare_feature方法比对)
namespace testface
{  
    // 人脸比较1:1、1:N、抽取人脸特征值、按特征值比较等
    public class FaceCompare       
    {
        // 特征值比对（传2个人脸的特征值,所有的1:1比对归根结底都是特征值比对，都可通过提取特征值来比对）
        [DllImport("BaiduFaceApi.dll", EntryPoint = "compare_feature", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        // type为0表示提取生活照的特征值，1表示证件照的特征值，2表示nir的特征值
        private static extern float compare_feature(ref BDFaceFeature f1, ref BDFaceFeature f2, int type = 0);

        // 1:N人脸识别（传人脸特征值和库里的比对, 人脸库可参考FaceManager）
        [DllImport("BaiduFaceApi.dll", EntryPoint = "identify", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        // type为0表示提取生活照的特征值，1表示证件照的特征值，2表示nir的特征值
        private static extern IntPtr identify(ref BDFaceFeature f1,  string group_id_list, 
            string user_id, int type = 0);

        // 提前加载库里所有数据到内存中
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_db_face", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        public static extern bool load_db_face();

        // 1:N人脸识别（特征值和内存已加载的整个库数据比对）
        [DllImport("BaiduFaceApi.dll", EntryPoint = "identify_with_all", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        // type为0表示提取生活照的特征值，1表示证件照的特征值，2表示nir的特征值
        private static extern IntPtr identify_with_all(ref BDFaceFeature f1, int type = 0);

        // 通过特征值比对（1:1）
        public void test_match()
        {           
            // 获取特征值1   共128个字节
            string file_name1 = "../images/1.jpg";
            FaceFeature feature = new FaceFeature();
            // 提取第一个人脸特征值数组（多人会提取多个人的特征值）
            BDFaceFeature[] feaList1  = feature.test_get_face_feature_by_path(file_name1);

            string file_name2 = "../images/2.jpg";
            // 提取第一个人脸特征值（多人会提取多个人的特征值）
            BDFaceFeature[] feaList2 = feature.test_get_face_feature_by_path(file_name2);
            // 假设测试的图片是1个人，
            BDFaceFeature f1 = feaList1[0];
            BDFaceFeature f2 = feaList2[0];          
            float score = compare_feature(ref  f1, ref  f2);
            Console.WriteLine("compare score result is:{0}", score);
        }

        // 测试1:N比较，传入图片文件路径
        public void test_identify()
        {
            // 获取特征值1   共128个字节
            string file_name1 = "../images/2.jpg";
            FaceFeature feature = new FaceFeature();
            // 提取第一个人脸特征值数组（多人会提取多个人的特征值）
            BDFaceFeature[] feaList1 = feature.test_get_face_feature_by_path(file_name1);

            string user_group = "test_group";
            string user_id = "test_user";
            BDFaceFeature f1 = feaList1[0];
            // type为0表示提取生活照的特征值，1表示证件照的特征值，2表示nir的特征值 (type需要和前面特征值提取的一致，否则会出错)
            IntPtr ptr = identify(ref f1, user_group, user_id);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("identify res is:" + buf);
            
        }
       
        // 测试1:N比较，传入提取的人脸特征值和已加载的内存中整个库比较
        public void test_identify_with_all()
        {
            // 和整个库比较，需要先加载整个数据库到内存中
            load_db_face();
            // 获取特征值1   共128个字节
            string file_name1 = "../images/2.jpg";
            FaceFeature feature = new FaceFeature();
            // 提取第一个人脸特征值数组（多人会提取多个人的特征值）
            BDFaceFeature[] feaList1 = feature.test_get_face_feature_by_path(file_name1);
            BDFaceFeature f1 = feaList1[0];
            // type为0表示提取生活照的特征值，1表示证件照的特征值，2表示nir的特征值 (type需要和前面特征值提取的一致，否则会出错)
            int type = 0;
            IntPtr ptr = identify_with_all(ref f1, type);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("identify with all db res is:" + buf);
        }

        public float CompareFaceFeature(ref BDFaceFeature f1, ref BDFaceFeature f2, int type = 0)
        {
            return compare_feature(ref f1, ref f2);
        }
    }
}
