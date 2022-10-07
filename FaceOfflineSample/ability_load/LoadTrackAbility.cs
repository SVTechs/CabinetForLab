using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 人脸跟踪能力加载 (可定制化conf，也可采用系统默认配置)
namespace testface.load_ability
{

    class LoadTrackAbility
    {
        // 人脸跟踪模型默认加载
        [DllImport("BaiduFaceApi.dll", EntryPoint = "default_track_ability", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        // type 0:rgb 1: nir
        public static extern int default_track_ability(int type = 0);
        // 人脸跟踪模型配置加载
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_track_ability", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        // type 0:rgb 1: nir
        public static extern int load_track_ability(ref BDFaceTrackConf conf, int type = 0);
       
       
        static public int load_rgb_track()
        {
            int type = 0;
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = true;
            if (default_conf)
            {
                default_track_ability(type);
            }
            else
            {
                BDFaceTrackConf conf = new BDFaceTrackConf();
                conf.detect_intv_before_track = 0.02f;
                conf.detect_intv_during_track = 0.02f;
                load_track_ability(ref conf, type);
            }
            return 0;
        }

        static public int load_nir_track()
        {
            int type = 1;
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = false;
            if (default_conf)
            {
                default_track_ability(type);
            }
            else
            {
                BDFaceTrackConf conf = new BDFaceTrackConf();
                conf.detect_intv_before_track = 0.02f;
                conf.detect_intv_during_track = 0.02f;
                load_track_ability(ref conf, type);
            }
            return 0;
        }
    }
}
