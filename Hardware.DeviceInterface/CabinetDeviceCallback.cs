using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//copy from Suning MeasuringCallback
namespace Hardware.DeviceInterface
{
    public class CabinetDeviceCallback
    {
        /// <summary>
        /// 串口数据回调
        /// </summary>
        /// <param name="usageInfo"></param>
        //public delegate void OnMeasuringDataReceivedDelegate(string usageInfo);
        //public static OnMeasuringDataReceivedDelegate OnMeasuringDataReceived = null;

          
        public delegate void OnICCardReceivedDelegate(string carid);
        /// <summary>
        /// 串口收到IC卡数据回调
        /// </summary>
        public static OnICCardReceivedDelegate OnICCardReceived = null;
    }
}
