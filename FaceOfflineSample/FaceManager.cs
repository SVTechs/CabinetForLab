using System;
using System.Runtime.InteropServices;
/**
 *  备注（人脸数据库管理说明）：
 *  人脸数据库为采用sqlite3的数据库，会自动生成一个db目录夹，下面有数据库face.db文件保存数据库
 *  可用sqliteExpert之类的可视化工具打开查看,亦可用命令行，方法请自行百度。
 *  该数据库仅仅可适应于5w人左右的人脸库，且设计表格等属于小型通用化。
 *  若不能满足客户个性化需求，客户可自行设计数据库保存数据。宗旨就是每个人脸图片提取一个特征值保存。
 *  人脸1:1,1:N比对及识别实际就是特征值的比对。1:1只要提取2张不同的图片特征值调用compare_feature比对。
 *  1：N是提取一个特征值和数据库中已保存的N个特征值一一比对(比对速度很快，不用担心效率问题)，
 *  最终取分数高的值为最高相似度。
 *  相似度识别的分数可自行测试根据实验结果拟定，一般推荐相似度大于80分为同一人。
 * 
 */
namespace testface
{
    class FaceManager
    {
        // 人脸注册(传特征值,特征值可参考FaceFeature.cs提取，亦可参考FaceCompare.cs查看特征值的比对)
        [DllImport("BaiduFaceApi.dll", EntryPoint = "user_add", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr user_add(ref BDFaceFeature f1, string user_id, string group_id, 
            string user_info="");

        // 人脸更新(传特征值)
        [DllImport("BaiduFaceApi.dll", EntryPoint = "user_update", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr user_update(ref BDFaceFeature f1, string user_id, string group_id,
            string user_info = "");
      
        // 人脸删除
        [DllImport("BaiduFaceApi.dll", EntryPoint = "user_face_delete", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr user_face_delete(string user_id, string group_id, string face_token);
        // 用户删除
        [DllImport("BaiduFaceApi.dll", EntryPoint = "user_delete", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr user_delete(string user_id, string group_id);
        // 组添加
        [DllImport("BaiduFaceApi.dll", EntryPoint = "group_add", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr group_add(string group_id);
        // 组删除
        [DllImport("BaiduFaceApi.dll", EntryPoint = "group_delete", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr group_delete(string group_id);
        // 查询用户信息
        [DllImport("BaiduFaceApi.dll", EntryPoint = "get_user_info", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr get_user_info(string user_id, string group_id);
        // 用户组列表查询
        [DllImport("BaiduFaceApi.dll", EntryPoint = "get_user_list", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr get_user_list(string group_id, int start = 0, int length = 100);
        // 组列表查询
        [DllImport("BaiduFaceApi.dll", EntryPoint = "get_group_list", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr get_group_list(int start = 0, int length = 100);

       
        // 测试人脸注册
        public void test_user_add()
        {
            // 人脸注册
            string user_id = "test_user";
            string group_id = "test_group";
            string file_name = "../images/2.jpg";
           
            string user_info = "user_info";
            // 提取人脸特征值数组（多人会提取多个人的特征值）
            FaceFeature feature = new FaceFeature();
            BDFaceFeature[] feaList1 = feature.test_get_face_feature_by_path(file_name);
            // 假设测试的图片是1个人，
            BDFaceFeature f1 = feaList1[0];
            // 人脸注册
            IntPtr ptr = user_add(ref f1, user_id, group_id, user_info);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("user_add res is:" + buf);
        }
      
        // 测试人脸更新
        public void test_user_update()
        {
            // 人脸注册
            string user_id = "test_user";
            string group_id = "test_group";
            string file_name = "../images/1.jpg";
            string user_info = "user_info";
            // 提取人脸特征值数组（多人会提取多个人的特征值）
            FaceFeature feature = new FaceFeature();
            BDFaceFeature[] feaList1 = feature.test_get_face_feature_by_path(file_name);
            // 假设测试的图片是1个人，
            BDFaceFeature f1 = feaList1[0];
            // 人脸更新
            IntPtr ptr = user_update(ref f1, user_id, group_id, user_info);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("user_update res is:" + buf);
        }     

        // 测试人脸删除
        public void test_user_face_delete()
        {
            string user_id = "test_user";
            string group_id = "test_group";
            // face_token为库里面的特征值进行md5，库里面特征值是对128个float浮点进行base64保存
            string face_token = "b0becbf6966b15b79fef0eea9af73816";
            IntPtr ptr = user_face_delete(user_id, group_id, face_token);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("user_face_delete res is:" + buf);
        }

        // 测试用户删除
        public void test_user_delete()
        {
            string user_id = "test_user";
            string group_id = "test_group";
            IntPtr ptr = user_delete(user_id, group_id);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("user_delete res is:" + buf);
        }

        // 组添加
        public void test_group_add()
        {
            string group_id = "test_group2";
            IntPtr ptr = group_add(group_id);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("group_add res is:" + buf);
        }

        // 组删除
        public void test_group_delete()
        {
            string group_id = "test_group2";
            IntPtr ptr = group_delete(group_id);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("group_delete res is:" + buf);
        }

        // 查询用户信息
        public void test_get_user_info()
        {
            string user_id = "test_user";
            string group_id = "test_group";
            IntPtr ptr = get_user_info(user_id , group_id);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("get_user_info res is:" + buf);
        }

        // 用户组列表查询
        public void test_get_user_list()
        {
            string group_id = "test_group";
            IntPtr ptr = get_user_list(group_id);
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("get_user_list res is:" + buf);
        }

        // 组列表查询
        public void test_get_group_list()
        {
            IntPtr ptr = get_group_list();
            string buf = Marshal.PtrToStringAnsi(ptr);
            Console.WriteLine("get_group_list res is:" + buf);
        }
    }
}
