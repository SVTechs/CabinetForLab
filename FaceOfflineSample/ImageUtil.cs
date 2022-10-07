using System;
using System.IO;
using OpenCvSharp;
using System.Drawing;


namespace testface
{
    class ImageUtil
    {
        // 图片文件转bytes
        public static byte[] img2byte(System.Drawing.Image img)
        {
            //将Image转换成流数据，并保存为byte[]
            MemoryStream mstream = new MemoryStream();
            img.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }
        // 图片文件转bytes
        public static byte[] get_img_data(string img_path)
        {
            //根据图片文件的路径使用文件流打开，并保存为byte[]   
            FileStream fs = new FileStream(img_path, FileMode.Open);//可以是其他重载方法 
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            fs.Close();
            return byData;
        }
        // bytes转图片文件
        public static void byte2img(byte[] b, int len, string file_name)
        {
            MemoryStream ms = new MemoryStream(b);
            ms.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            img.Save(file_name);
            ms.Close();
        }
        // 二进制byte图片流转mat示例
        public static Mat image2mat(string img_path)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(img_path);
            byte[] img_bytes = ImageUtil.img2byte(img);
            Mat mat = Cv2.ImDecode(img_bytes, ImreadModes.Color);
            return mat;
        }
    }
}
