namespace Hardware.DeviceInterface
{
    //已经换成肃宁中的代码，2021-4-13
    public class MeasuringCallback
    {
        /// <summary>
        /// 串口数据回调
        /// </summary>
        /// <param name="usageInfo"></param>
        public delegate void OnMeasuringDataReceivedDelegate(MeasuringDevice.UsageInfo usageInfo);
        public static OnMeasuringDataReceivedDelegate OnMeasuringDataReceived = null;
    }
}
