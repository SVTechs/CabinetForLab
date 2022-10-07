using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using NLog;
//已经换成肃宁中的代码，2021-4-13
namespace Hardware.DeviceInterface
{
    public class MeasuringDevice
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static SerialPort _serialCtrl;
        private static List<byte> buffer = new List<byte>();
        public class UsageInfo
        {
            public string ToolId;
            public float RealValue;

            public UsageInfo(string toolId, float realValue)
            {
                ToolId = toolId;
                RealValue = realValue;
            }
        }

        public static int Init(int serialPort)
        {
            try
            {
                if (_serialCtrl == null || !_serialCtrl.IsOpen)
                {
                    _serialCtrl = new SerialPort("COM" + serialPort);
                    _serialCtrl.BaudRate = 9600;
                    _serialCtrl.Parity = Parity.None;
                    _serialCtrl.DataBits = 8;
                    _serialCtrl.StopBits = StopBits.One;
                    _serialCtrl.Encoding = Encoding.Default;

                    try
                    {
                        _serialCtrl.DataReceived += DataReceived;
                        _serialCtrl.Open();
                        return 1;
                    }
                    catch
                    {
                        return -1;
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int Close()
        {
            if (_serialCtrl.IsOpen)
            {
                try
                {
                    _serialCtrl.Close();
                    return 1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            return -10;
        }

        public static void GenerateTestData(string toolName, float dataBase)
        {
            Random rd = new Random();
            UsageInfo uInfo = new UsageInfo(toolName, dataBase + (float)rd.Next(1, 10) / 100);//182631  E25005 373635  E10054
            MeasuringCallback.OnMeasuringDataReceived?.Invoke(uInfo);
        }

        private static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //LogHelper.WriteLog("量具DataReceived", "步骤1");
                int datalength = _serialCtrl.BytesToRead;
                //char[] dataBuffer = new char[datalength];
                //_serialCtrl.Read(dataBuffer, 0, datalength);
                byte[] buf = new byte[datalength];//创建n个字节的缓存,   改用字节接收能解决以前的丢失数据的问题， 以后要考虑连接多个量具的问题。
                //一个Com口，接收多个量具的数据时需要测试。如果测试时数据接收发生混乱，就只能一个com口，一个接收器，一个量具这样对应的
                //测试了一个Com口,接3个量具，同时发数据的情况，数据不会交叉(一个量具的数据会穿插进另一个量具数据中)，会出现前一个包有前部分数据，后一个包有后部分数据的情况（2019-4-10）
                //还要看一台电脑接几个接收器，接多个接收器时，应该就不能用静态方法了(2019-3-1)
                _serialCtrl.Read(buf, 0, datalength);//读到在数据存储到buf
                buffer.AddRange(buf);
                while (buffer.IndexOf(13) > -1)
                {
                    int n = buffer.IndexOf(13);
                    byte[] array = new byte[n + 1];
                    buffer.GetRange(0, n + 1).CopyTo(array);
                    buffer.RemoveRange(0, n + 1);

                    string serialData = "";
                    for (int i = 0; i <= n; i++)
                    {
                        char c = (char)array[i];
                        serialData += c;
                    }
                    string[] dataArray = serialData.Replace("\r", "").Replace("#", "").Split(',');
                    if (dataArray.Length != 2)
                    {
                        return;
                    }

                    UsageInfo uInfo = new UsageInfo(dataArray[0], float.Parse(dataArray[1]));
                    MeasuringCallback.OnMeasuringDataReceived?.Invoke(uInfo);
                    //LogHelper.WriteLog("量具DataReceived", "步骤2");
                }

            }
            catch// (Exception ex)
            {
                //LogHelper.WriteException("QfcErr", ex);
                // ignored
            }
        }
    }
}
