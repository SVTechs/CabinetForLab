using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using OpenCvSharp;

namespace testface
{
    // 示例demo全集，可通过打开注释编译执行
    public class FaceDemo
    {
        // 人脸库示例
        public static void test_face_manager()
        {
            // 人脸库示例
            FaceManager manager = new FaceManager();
            //  人脸注册
            manager.test_user_add();
            // 人脸更新
            // manager.test_user_update();         

            // 人脸删除
            //  manager.test_user_face_delete();
            // 用户删除
            //  manager.test_user_delete();
            // 组添加
            //   manager.test_group_add();
            // 组删除
            //  manager.test_group_delete();
            // 查询用户信息
            //  manager.test_get_user_info();
            // 用户组列表查询
            // manager.test_get_user_list();
            // 组列表查询
            // manager.test_get_group_list();
        }
        // 人脸检测示例
        public static void test_face_detect()
        {
            FaceDetect detect = new FaceDetect();
            // 人脸usb摄像头检测
             detect.usb_video_detect();
            // 人脸检测图片
           // detect.image_detect();
        }
        // 人脸跟踪示例
        public static void test_face_track()
        {
            FaceTrack face_track = new FaceTrack();
            // 传入图片
            // face_track.image_track();
            //usb 摄像头实时人脸检测
             face_track.usb_video_track();
            // 清除跟踪的人脸信息
          //  face_track.test_clear_tracked_faces();
        }
        // 获取人脸特征值示例
        public static void test_face_feature()
        {
            FaceFeature feature = new FaceFeature();
          //  feature.test_face_feature();
            // 获取rgb+depth双面摄像头的特征值
            string rgb_path = "../images/rgb.png";
            string depth_path = "../images/depth.png";
            feature.test_get_rgbd_feature_by_path(rgb_path, depth_path);
        }

        // 人脸比较&识别示例
        public static void test_face_compare()
        {
            FaceCompare comp = new FaceCompare();
            // 按特征值人脸1:1比对        
          //  comp.test_match();
            // 1：N识别，（和已提前加载的整个库比对,要先使用FaceManager注册人脸入库)
            comp.test_identify_with_all();
            // 1:N识别（和库里的比对, 按注册的组和库里比对,请参考FaceManager)
            //  comp.test_identify();
        }
        // 人脸活体检测示例
        public static void test_face_liveness()
        {
            FaceLiveness live = new FaceLiveness();
            // 测试单目RGB静默活体检测（传入图片文件路径)
            //   live.test_liveness_by_image();
            // 双目RGB和IR静默活体检测（传入opencv视频帧)
            //  live.test_rgb_ir_liveness_check_by_opencv();
            // 双目RGB和DEPTH静默活体检测（传入opencv视频帧，适配奥比中光双目摄像头如海燕
          //  live.test_rgb_depth_liveness_check_by_orbe();
            // 双目摄像头进行rgb,depth活体检测(此处适配了华杰艾米的双目摄像头如A-200)
              live.test_rgb_depth_liveness_check_by_hjimi();
        }
        // 以下为sdk demo示例，可通过打开注释运行验证
        public int face_demo()
        {
            // 人脸检测示例
              test_face_detect();
            // 人脸跟踪示例
           //  test_face_track();
            // 获取人脸属性示例
            FaceAttr attr = new FaceAttr();
           // attr.test_get_face_attr();

            // 获取眼部状态示例
            FaceEyeClose eye = new FaceEyeClose();
           // eye.test_get_face_eye_close();

            // 获取注意力示例
            FaceGaze gaze = new FaceGaze();
          //  gaze.test_get_face_gaze();

            // 人脸姿态偏转角示例
            FaceHeadPose head_pose = new FaceHeadPose();
           // head_pose.test_get_face_head_pose();

            // 人脸光照示例
            FaceIllumination illumi = new FaceIllumination();
           // illumi.test_get_face_illumination();

            // 嘴巴闭合示例
            FaceMouthClose mouth_close = new FaceMouthClose();
            // mouth_close.test_get_face_mouth_close();

            // 是否佩戴口罩检测
            FaceMouthMask mouth_mask = new FaceMouthMask();
           // mouth_mask.test_get_face_mouth_mask();

            // 人脸遮挡度检测
            FaceOcclusion occlusion = new FaceOcclusion();
           // occlusion.test_get_face_occlusion();

            // 人脸模糊度检测
            FaceBlur face_blur = new FaceBlur();
           // face_blur.test_get_face_blur();

            // 暗光恢复
            DarkEnhance dark_enhance = new DarkEnhance();
           // dark_enhance.test_get_dark_enhance();

            // 人脸扣图
            FaceCrop face_crop = new FaceCrop();
           // face_crop.test_get_face_crop();

            // 最优人脸检测
            FaceBest face_best = new FaceBest();
           // face_best.test_get_face_best();

            //人脸关键点检测
            FaceLandmarkDemo landmark = new FaceLandmarkDemo();
           // landmark.test_get_face_landmark();          

            // 获取人脸特征值示例         
            // test_face_feature();
            // 人脸管理示例
           //  test_face_manager();            
            // 人脸比较&识别示例
           //   test_face_compare();
            // 人脸活体检测示例
           //   test_face_liveness();
            // 动作活体示例
            FaceActionLive action_live = new FaceActionLive();
          //  action_live.test_action_live();
            return 0;
        }
    }
}
