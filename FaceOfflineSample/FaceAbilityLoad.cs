using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using OpenCvSharp;
using testface.load_ability;

// 人脸模型能力加载类
namespace testface
{
    // 模型能力加载
    public class FaceAbilityLoad
    {
        // 其他所有能力默认加载
        [DllImport("BaiduFaceApi.dll", EntryPoint = "load_other_ability", CharSet = CharSet.Ansi
          , CallingConvention = CallingConvention.Cdecl)]
        public static extern int load_other_ability();

        // 加载所有模型能力 (备注：如无必要，下面的模型加载能力代码无需改动,
        // 其中：TrackAbility, DetectAbility, AlignAbility 和 CropFaceAbility这4个能力还支持定制化配置加载，其他能力无需定制化配置，采用系统默认)
        static public void load_all_ability()
        { 
            // 加载rgb人脸检测能力
            LoadDetectAbility.load_rgb_detect();
            // 加载nir人脸检测能力
            LoadDetectAbility.load_nir_detect();
            // 加载fast align人脸关键点能力
            LoadAlignAbility.load_fast_align();
            // 加载accurate align人脸关键点能力
            LoadAlignAbility.load_accruate_align();
            // 加载nir align人脸关键点能力
            LoadAlignAbility.load_nir_align();
            // 加载rgb人脸跟踪能力
            LoadTrackAbility.load_rgb_track();
            // 加载nir人脸跟踪能力
            LoadTrackAbility.load_nir_track();
            // 加载人脸扣图能力
            LoadCropFaceAbility.load_crop_face();      
            // 加载其他所有能力
            load_other_ability();
            // 加载动作活体
            LoadActionLiveAbility.load_action_live();
        }      

    }
}
