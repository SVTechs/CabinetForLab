using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// 适配奥比中光镜头
namespace testface
{
    class OrbeCamera
    {
        // 获取orbeCamera对象  奥比中光海燕等众多奥比镜头
        [DllImport("BaiduFaceApi.dll", EntryPoint = "new_orbe", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr new_orbe();

        // 打开奥比中光
        [DllImport("BaiduFaceApi.dll", EntryPoint = "open_orbe", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        public static extern int open_orbe(IntPtr porbe, IntPtr cv_rgb, IntPtr cv_depth);

        // 释放奥比中光
        [DllImport("BaiduFaceApi.dll", EntryPoint = "orbe_release", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        public static extern void orbe_release(IntPtr orbe);

    }
}
