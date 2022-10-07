using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Utilities.Net
{
    public class ValidateHelper
    {
        private static int letterWidth = 16;//单个字体的宽度范围
        private static int letterHeight = 22;//单个字体的高度范围
        //private static int letterCount = 4;//验证码位数
        private static char[] chars = "0123456789".ToCharArray();
        private static string[] fonts = { "Arial", "Georgia" };

        /// <summary>
        /// 产生波形滤镜效果
        /// </summary>
        private const double Pi = 3.1415926535897932384626433832795;
        private const double Pi2 = 6.283185307179586476925286766559;

        public static MemoryStream CreateValidateImageStream(string checkCode)
        {
            int intImageWidth = checkCode.Length * letterWidth;
            Random newRandom = new Random();
            Bitmap image = new Bitmap(intImageWidth, letterHeight);
            Graphics g = Graphics.FromImage(image);
            //生成随机生成器
            Random random = new Random();
            //白色背景
            g.Clear(Color.White);
            //画图片的背景噪音线
            for (int i = 0; i < 10; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            //画图片的前景噪音点
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //随机字体和颜色的验证码字符
            for (int intIndex = 0; intIndex < checkCode.Length; intIndex++)
            {
                var findex = newRandom.Next(fonts.Length - 1);
                string strChar = checkCode.Substring(intIndex, 1);
                Brush newBrush = new SolidBrush(GetRandomColor());
                Point thePos = new Point(intIndex * letterWidth + 1 + newRandom.Next(3), 1 + newRandom.Next(3));//5+1+a+s+p+x
                g.DrawString(strChar, new Font(fonts[findex], 12, FontStyle.Bold), newBrush, thePos);
            }
            //灰色边框
            g.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, intImageWidth - 1, (letterHeight - 1));
            //图片扭曲
            image = TwistImage(image, true, 3, 4);
            //将生成的图片发回客户端
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public static byte[] CreateValidateImage(string checkCode)
        {
            MemoryStream ms = CreateValidateImageStream(checkCode);
            var result = ms.ToArray();
            ms.Close();
            return result;
        }

        /// <summary>
            /// 正弦曲线Wave扭曲图片
            /// </summary>
            /// <param name="srcBmp">图片路径</param>
            /// <param name="bXDir">如果扭曲则选择为True</param>
            /// <param name="dMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
            /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
            /// <returns></returns>
            public static Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            // 将位图背景填充为白色
            var graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();
            double dBaseAxisLen = bXDir ? destBmp.Height : destBmp.Width;
            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    var dx = bXDir ? (Pi2 * j) / dBaseAxisLen : (Pi2 * i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);
                    // 取得当前点的颜色
                    var nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    var nOldY = bXDir ? j : j + (int)(dy * dMultValue);
                    Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }

        public static Color GetRandomColor()
        {
            Random randomNumFirst = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(randomNumFirst.Next(50));
            Random randomNumSecond = new Random((int)DateTime.Now.Ticks);
            int intRed = randomNumFirst.Next(210);
            int intGreen = randomNumSecond.Next(180);
            int intBlue = (intRed + intGreen > 300) ? 0 : 400 - intRed - intGreen;
            intBlue = (intBlue > 255) ? 255 : intBlue;
            return Color.FromArgb(intRed, intGreen, intBlue);// 5+1+a+s+p+x
        }

        // 生成随机数字字符串
        public static string GetRandomNumberString(int intNumberLength)
        {
            Random random = new Random();
            string validateCode = string.Empty;
            for (int i = 0; i < intNumberLength; i++)
                validateCode += chars[random.Next(0, chars.Length)].ToString();
            return validateCode;
        }
    }
}
