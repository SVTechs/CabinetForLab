using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸检测能力加载 (可定制化conf，也可采用系统默认配置)
namespace testface.load_ability
{
   
    class LoadDetectAbility
    {
        // DetectConf 为检测配置
        // 检测默认配置
        [DllImport("BaiduFaceApi.dll", EntryPoint = "default_detect_ability", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        // type 0:rgb 1: nir
        public static extern int default_detect_ability(int type = 0);
        // 检测conf配置
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_detect_ability", CharSet = CharSet.Ansi
         , CallingConvention = CallingConvention.Cdecl)]
        // type 0:rgb 1: nir
        public static extern int load_detect_ability(ref DetectConf conf, int type = 0);      

        static public int load_rgb_detect()
        {
            int type = 0;
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = false;
            if (default_conf)
            {
                default_detect_ability(type);
            }
            else
            {              
                int max_detect_num = 10; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50
                DetectConf conf = new DetectConf();
                conf.max_detect_num = max_detect_num; // 最大人脸个数
                conf.min_face_size = 0; // 最小人脸面积检测 
                conf.scale_ratio = -1;  // 缩放比例
                conf.not_face_threshold = 0.5f; //置信度设为0.5 
                load_detect_ability(ref conf, type);
            }
            return 0;
        }

        static public int load_nir_detect()
        {
            int type = 1;
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = true;
            if (default_conf)
            {
                // Console.WriteLine("before detect ability and type is:{0}",type);
                default_detect_ability(type);
            }
            else
            {
                
                int max_detect_num = 50; // 设置最多检测跟踪人数（多人脸检测），默认为1，最多可设为50
                DetectConf conf = new DetectConf();
                conf.max_detect_num = max_detect_num; // 最大人脸个数
                conf.min_face_size = 0; // 最小人脸面积检测 
                conf.scale_ratio = -1;  // 缩放比例
                conf.not_face_threshold = 0.5f; //置信度设为0.5 
                load_detect_ability(ref conf, type);
            }
            return 0;
        }
    }
}
