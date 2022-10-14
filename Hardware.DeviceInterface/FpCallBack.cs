using System.Drawing;

namespace Hardware.DeviceInterface
{
    public class FpCallBack
    {

        /// <summary>
        /// 指纹识别回调
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="method">登录方式1:指纹 2：人脸 3：IC卡</param>
        public delegate void OnUserRecognisedDelegate(string userName, int method);
        public static OnUserRecognisedDelegate OnUserRecognised = null;

       
    }
}
