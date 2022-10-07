using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using OpenCvSharp;

// 提取人脸特征值
namespace testface
{
    // 人脸特征值结构体
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BDFaceFeature
    {
        public int size;
        // 人脸的特征值，提取出来后是128个float的浮点值
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public float[] data;// = new float[128];
    }
    // 人脸特征值结构体
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BDDepthFeature
    {
        public int size;
        // 人脸的深度特征值，提取出来后是256个float的浮点值
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] data;// = new float[256];
    }
    public class FaceFeature
    {
        // 提取人脸特征值
        [DllImport("BaiduFaceApi.dll", EntryPoint = "face_feature", CharSet = CharSet.Ansi
            , CallingConvention = CallingConvention.Cdecl)]
        // 返回num为特征值的人数,type为0表示提取生活照的特征值，1表示证件照的特征值，2表示nir的特征值
        public static extern int face_feature(IntPtr feature, IntPtr box, IntPtr mat, int type);
        // 返回num为特征值的人数,通过rgb+depth双面摄像头提取特征值
        [DllImport("BaiduFaceApi.dll", EntryPoint = "rgbd_feature", CharSet = CharSet.Ansi
           , CallingConvention = CallingConvention.Cdecl)]
        public static extern int rgbd_feature(IntPtr feature, IntPtr box, IntPtr rgb_mat, IntPtr depth_mat);



        public void test_face_feature()
        {
            long t_begin = TimeUtil.get_time_stamp();
            BDFaceFeature[] fea1 = test_get_face_feature_by_path("../images/2.jpg");
            long t_end = TimeUtil.get_time_stamp();
            Console.WriteLine("get feature time cost is:" + (t_end - t_begin));
        }

        // 获取特征值，传入图片路径
        public BDFaceFeature[] test_get_face_feature_by_path(string img_path)
        {
            // 特征值的长度，128个float值
            int dim_count = 128;
            Mat mat = Cv2.ImRead(img_path);
            // 假设提取的人数，需要比实际的人数多，因为需要提取分配内存
            int faceNum = 5;
            BDFaceFeature[] feaList = new BDFaceFeature[faceNum];
            for(int i = 0; i < faceNum; i++)
            {
                feaList[i].data = new float[dim_count];
                feaList[i].size = 0;
            }
           
            if (mat.Empty())
            {
                return feaList;
            }

            int sizeFeature = Marshal.SizeOf(typeof(BDFaceFeature));
            IntPtr ptFea = Marshal.AllocHGlobal(sizeFeature * faceNum);

            // 构造返回的人脸框数据
            BDFaceBBox[] info = new BDFaceBBox[faceNum];
            int sizeBox = Marshal.SizeOf(typeof(BDFaceBBox));
            IntPtr ptBox = Marshal.AllocHGlobal(sizeBox * faceNum);
            // 返回num为特征值的人数,type为0表示提取生活照的特征值，1表示证件照的特征值，2表示nir的特征值
            int type = 0;
            int num = face_feature(ptFea, ptBox, mat.CvPtr, type);
            Console.WriteLine("face num is:{0}", num);
            // 请确保faceNum大于num, faceNum为c#期望的检测人数，需要预先分配内存，否则无法获取
            if (num > faceNum)
            {
                num = faceNum;
            }
            for (int index = 0; index < num; index++)
            {
                IntPtr ptrF = new IntPtr();
                IntPtr ptrB = new IntPtr();
                if (8 == IntPtr.Size)
                {
                    ptrF = (IntPtr)(ptFea.ToInt64() + sizeFeature * index);
                    ptrB = (IntPtr)(ptBox.ToInt64() + sizeBox * index);
                }
                else if (4 == IntPtr.Size)
                {
                    ptrF = (IntPtr)(ptFea.ToInt32() + sizeFeature * index);
                    ptrB = (IntPtr)(ptBox.ToInt32() + sizeBox * index);
                }
                feaList[index] = (BDFaceFeature)Marshal.PtrToStructure(ptrF, typeof(BDFaceFeature));
                Console.WriteLine("feaList[index].size is:{0}", feaList[index].size);
                

                for (int k = 0; k < feaList[index].size; k++)
                {
                    Console.WriteLine("feature is {0}:", feaList[index].data[k]);
                }

                info[index] = (BDFaceBBox)Marshal.PtrToStructure(ptrB, typeof(BDFaceBBox));

                // 索引值
                Console.WriteLine("detect score is:{0}", info[index].index);
                // 置信度
                Console.WriteLine("detect score is:{0}", info[index].score);
                // 角度
                Console.WriteLine("detect mAngle is:{0}", info[index].angle);
                // 人脸宽度
                Console.WriteLine("detect mWidth is:{0}", info[index].width);
                // 中心点X,Y坐标
                Console.WriteLine("detect mCenter_x is:{0}", info[index].center_x);
                Console.WriteLine("detect mCenter_y is:{0}", info[index].center_y);
            }
            // 绘制人脸框
            FaceDraw.draw_rects(ref mat, faceNum, info);
            mat.ImWrite("detect.jpg");
            return feaList;
        }

        public BDFaceFeature[] test_get_face_feature_by_path(Mat mat)
        {
            // 特征值的长度，128个float值
            int dim_count = 128;
            //Mat mat = Cv2.ImRead(img_path);
            // 假设提取的人数，需要比实际的人数多，因为需要提取分配内存
            int faceNum = 10;
            BDFaceFeature[] feaList = new BDFaceFeature[faceNum];
            for (int i = 0; i < faceNum; i++)
            {
                feaList[i].data = new float[dim_count];
                feaList[i].size = 0;
            }

            if (mat.Empty())
            {
                return feaList;
            }

            int sizeFeature = Marshal.SizeOf(typeof(BDFaceFeature));
            IntPtr ptFea = Marshal.AllocHGlobal(sizeFeature * faceNum);

            // 构造返回的人脸框数据
            BDFaceBBox[] info = new BDFaceBBox[faceNum];
            int sizeBox = Marshal.SizeOf(typeof(BDFaceBBox));
            IntPtr ptBox = Marshal.AllocHGlobal(sizeBox * faceNum);
            // 返回num为特征值的人数,type为0表示提取生活照的特征值，1表示证件照的特征值，2表示nir的特征值
            int type = 0;
            int num = face_feature(ptFea, ptBox, mat.CvPtr, type);
            Console.WriteLine("face num is:{0}", num);
            // 请确保faceNum大于num, faceNum为c#期望的检测人数，需要预先分配内存，否则无法获取
            if (num > faceNum)
            {
                num = faceNum;
            }
            for (int index = 0; index < num; index++)
            {
                IntPtr ptrF = new IntPtr();
                IntPtr ptrB = new IntPtr();
                if (8 == IntPtr.Size)
                {
                    ptrF = (IntPtr)(ptFea.ToInt64() + sizeFeature * index);
                    ptrB = (IntPtr)(ptBox.ToInt64() + sizeBox * index);
                }
                else if (4 == IntPtr.Size)
                {
                    ptrF = (IntPtr)(ptFea.ToInt32() + sizeFeature * index);
                    ptrB = (IntPtr)(ptBox.ToInt32() + sizeBox * index);
                }
                feaList[index] = (BDFaceFeature)Marshal.PtrToStructure(ptrF, typeof(BDFaceFeature));
                Console.WriteLine("feaList[index].size is:{0}", feaList[index].size);


                for (int k = 0; k < feaList[index].size; k++)
                {
                    Console.WriteLine("feature is {0}:", feaList[index].data[k]);
                }

                info[index] = (BDFaceBBox)Marshal.PtrToStructure(ptrB, typeof(BDFaceBBox));

                // 索引值
                Console.WriteLine("detect score is:{0}", info[index].index);
                // 置信度
                Console.WriteLine("detect score is:{0}", info[index].score);
                // 角度
                Console.WriteLine("detect mAngle is:{0}", info[index].angle);
                // 人脸宽度
                Console.WriteLine("detect mWidth is:{0}", info[index].width);
                // 中心点X,Y坐标
                Console.WriteLine("detect mCenter_x is:{0}", info[index].center_x);
                Console.WriteLine("detect mCenter_y is:{0}", info[index].center_y);
            }
            // 绘制人脸框
            FaceDraw.draw_rects(ref mat, faceNum, info);
            mat.ImWrite("detect.jpg");
            return feaList;
        }

        // 获取特征值，传入图片路径(传入rgb图和深度图)
        public BDDepthFeature[] test_get_rgbd_feature_by_path(string rgb_path, string depth_path)
        {
            // 特征值的长度，深度特征值为256个float值
            int dim_count = 256;
            Mat mat_rgb = Cv2.ImRead(rgb_path);                 
            byte[] depth_bytes = ImageUtil.get_img_data(depth_path);
            
            int depth_size = Marshal.SizeOf(depth_bytes[0]) * depth_bytes.Length;
            IntPtr ptr_depth = Marshal.AllocHGlobal(depth_size);
            Marshal.Copy(depth_bytes, 0, ptr_depth, depth_bytes.Length);

            // 假设提取的人数，需要比实际的人数多，因为需要提取分配内存
            int faceNum = 5;
            BDDepthFeature[] feaList = new BDDepthFeature[faceNum];
            for (int i = 0; i < faceNum; i++)
            {
                feaList[i].data = new float[dim_count];
                feaList[i].size = 0;
            }

            if (mat_rgb.Empty() || depth_bytes.Length<=0)
            {
                if (mat_rgb.Empty())
                {
                    Console.WriteLine("mat empty");
                }
              
                return feaList;
            }

            int sizeFeature = Marshal.SizeOf(typeof(BDFaceFeature));
            IntPtr ptFea = Marshal.AllocHGlobal(sizeFeature * faceNum);

            // 构造返回的人脸框数据
            BDFaceBBox[] info = new BDFaceBBox[faceNum];
            int sizeBox = Marshal.SizeOf(typeof(BDFaceBBox));
            IntPtr ptBox = Marshal.AllocHGlobal(sizeBox * faceNum);           
            int num = rgbd_feature(ptFea, ptBox, mat_rgb.CvPtr, ptr_depth);
           
            Console.WriteLine("face num is:{0}", num);
            // 请确保faceNum大于num, faceNum为c#期望的检测人数，需要预先分配内存，否则无法获取
            if (num > faceNum)
            {
                num = faceNum;
            }
            for (int index = 0; index < num; index++)
            {
                IntPtr ptrF = new IntPtr();
                IntPtr ptrB = new IntPtr();
                if (8 == IntPtr.Size)
                {
                    ptrF = (IntPtr)(ptFea.ToInt64() + sizeFeature * index);
                    ptrB = (IntPtr)(ptBox.ToInt64() + sizeBox * index);
                }
                else if (4 == IntPtr.Size)
                {
                    ptrF = (IntPtr)(ptFea.ToInt32() + sizeFeature * index);
                    ptrB = (IntPtr)(ptBox.ToInt32() + sizeBox * index);
                }
                feaList[index] = (BDDepthFeature)Marshal.PtrToStructure(ptrF, typeof(BDDepthFeature));
                Console.WriteLine("feaList[index].size is:{0}", feaList[index].size);

                // 获取的feature特征值，256个float浮点值
                for (int k = 0; k < feaList[index].size; k++)
                {
                   Console.WriteLine("feature is{0}:", feaList[index].data[k]);
                }

                info[index] = (BDFaceBBox)Marshal.PtrToStructure(ptrB, typeof(BDFaceBBox));

                // 索引值
                Console.WriteLine("detect score is:{0}", info[index].index);
                // 置信度
                Console.WriteLine("detect score is:{0}", info[index].score);
                // 角度
                Console.WriteLine("detect mAngle is:{0}", info[index].angle);
                // 人脸宽度
                Console.WriteLine("detect mWidth is:{0}", info[index].width);
                // 中心点X,Y坐标
                Console.WriteLine("detect mCenter_x is:{0}", info[index].center_x);
                Console.WriteLine("detect mCenter_y is:{0}", info[index].center_y);
            }
            // 绘制人脸框
            FaceDraw.draw_rects(ref mat_rgb, faceNum, info);
            mat_rgb.ImWrite("detect.jpg");
            return feaList;
        }

    }
}
