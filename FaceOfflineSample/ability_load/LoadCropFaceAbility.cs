using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸扣图能力加载 (可定制化conf，也可采用系统默认配置)
namespace testface.load_ability
{
    class LoadCropFaceAbility
    {
        // 默认人脸扣图能力加载
        [DllImport("BaiduFaceApi.dll", EntryPoint = "default_crop_face_ability", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        public static extern int default_crop_face_ability();
        //  conf人脸扣图能力加载
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_crop_face_ability", CharSet = CharSet.Ansi
         , CallingConvention = CallingConvention.Cdecl)]
        public static extern int load_crop_face_ability(ref BDFaceCropFaceConf conf);
       

        static public int load_crop_face()
        {
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = true;
            if (default_conf)
            {
                default_crop_face_ability();
            }
            else
            {
                BDFaceCropFaceConf conf = new BDFaceCropFaceConf();
                conf.is_flat = 0;
                conf.crop_size = 200;
                conf.enlarge_ratio = 0.8f;
                load_crop_face_ability(ref conf);
            }
            return 0;
        }

        
    }
}
