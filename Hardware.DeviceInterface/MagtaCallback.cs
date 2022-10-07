using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hardware.DeviceInterface
{
    public class MagtaCallback
    {
        /// <summary>
        /// 串口数据回调
        /// </summary>
        /// <param name="usageInfo"></param>
        public delegate void OnMagtaDataReceivedDelegate(MagtaDevice.UsageInfo usageInfo);
        public static OnMagtaDataReceivedDelegate OnMagtaDataReceived = null;
    }
}
