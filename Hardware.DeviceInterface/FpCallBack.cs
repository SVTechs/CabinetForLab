using System.Drawing;

namespace Hardware.DeviceInterface
{
    public class FpCallBack
    {

        /// <summary>
        /// 指纹识别回调
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="method">登录方式1:人脸 2：指纹 3：IC卡 4.工号</param>
        public delegate void OnUserRecognisedDelegate(long templateId, int method);
        public static OnUserRecognisedDelegate OnUserRecognised = null;

       
    }
}
