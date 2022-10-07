using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸关键点检测能力加载 (可定制化conf，也可采用系统默认配置)
namespace testface.load_ability
{

    class LoadAlignAbility
    {
        // fast align人脸关键点模型加载
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_fast_align_ability", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        public static extern int load_fast_align_ability(float threshold);
        //  accruate align人脸关键点模型加载
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_accruate_align_ability", CharSet = CharSet.Ansi
         , CallingConvention = CallingConvention.Cdecl)]
        public static extern int load_accruate_align_ability(float threshold);
        //  nir align人脸关键点模型加载
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_nir_align_ability", CharSet = CharSet.Ansi
         , CallingConvention = CallingConvention.Cdecl)]
        public static extern int load_nir_align_ability(float threshold);

        static public int load_fast_align()
        {
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = true;
            if (default_conf)
            {
                load_fast_align_ability(-1);
            }
            else
            {
                float threshold = 0.5f;
                load_fast_align_ability(threshold);
            }
            return 0;
        }

        static public int load_accruate_align()
        {
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = true;
            if (default_conf)
            {
                load_accruate_align_ability(-1);
            }
            else
            {
                float threshold = 0.5f;
                load_accruate_align_ability(threshold);
            }
            return 0;
        }

        static public int load_nir_align()
        {
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = false;
            if (default_conf)
            {
                load_nir_align_ability(-1);
            }
            else
            {
                float threshold = 0.5f;
                load_nir_align_ability(threshold);
            }
            return 0;
        }      
    }
}
