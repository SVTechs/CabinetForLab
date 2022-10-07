using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;

// 动作活体能力加载 (可定制化conf，也可采用系统默认配置)
namespace testface.load_ability
{

    /**
     * @brief   动作活体参数配置结构体
     */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct BDFaceActionLiveConf
    {
        public float eye_open_threshold;       // 睁眼的阈值
        public float eye_close_threshold;      // 闭眼的阈值
        public float mouth_open_threshold;     // 张嘴的阈值
        public float mouth_close_threshold;    // 闭嘴的阈值
        public float look_up_threshold;        // 抬头的阈值
        public float look_down_threshold;      // 低头的阈值
        public float turn_left_threshold;      // 向左转头的阈值
        public float turn_right_threshold;     // 向右转头的阈值
        public float nod_threshold;            // 点头的角度差阈值
        public float shake_threshold;          // 摇头的角度差阈值
        public int max_cache_num;                // 缓存的帧数
    };
    class LoadActionLiveAbility
    {
        // 动作活体模型加载（默认配置）
        [DllImport("BaiduFaceApi.dll", EntryPoint = "default_action_live_ability", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        public static extern int default_action_live_ability();
        //  动作活体模型加载（conf配置）
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_action_live_ability", CharSet = CharSet.Ansi
         , CallingConvention = CallingConvention.Cdecl)]
        public static extern int load_action_live_ability(ref BDFaceActionLiveConf conf);
        

        static public int load_action_live()
        {
            // 启用默认配置，则不传参，定制配置，传conf，二者二选一
            bool default_conf = true;
            if (default_conf)
            {
                default_action_live_ability();
            }
            else
            {
                // 定制化配置
                BDFaceActionLiveConf conf = new BDFaceActionLiveConf();
                conf.eye_open_threshold = 0.5f;
                conf.eye_close_threshold = 0.5f;
                conf.mouth_open_threshold = 0.5f;
                conf.mouth_close_threshold = 0.5f;
                conf.look_up_threshold = 0.5f;
                conf.look_down_threshold = 0.5f;
                conf.turn_left_threshold = 0.5f;
                conf.turn_right_threshold = 0.5f;
                conf.nod_threshold = 0.5f;
                conf.shake_threshold = 0.5f;
                conf.max_cache_num = 1;               

                load_action_live_ability(ref conf);
            }
            return 0;
        }

       
    }
}
