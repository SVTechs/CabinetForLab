using NLog;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
//串口IC卡设备
//copy from Suning MeasuringDevice
//copy from CabinetDevice.cs
namespace Hardware.DeviceInterface
{
    public class ICComDevice
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static SerialPort _serialCtrl;
        private static List<byte> buffer = new List<byte>();
        public static string CardId = "";

        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 将16进制的字符串转为byte[]
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] StrToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
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
                    catch (Exception ex)
                    {
                        Logger.Error(ex);
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
        /// <summary>  
        /// 是否处于打开状态  
        /// </summary>  
        public static bool IsOpen
        {
            get { return _serialCtrl != null && _serialCtrl.IsOpen; }
        }


        /// <summary>  
        /// 打开串口  
        /// </summary>  
        /// <returns></returns>  
        public static bool Open()
        {
            try
            {
                if (_serialCtrl == null)
                    return IsOpen;

                if (_serialCtrl.IsOpen)
                    Close();
                _serialCtrl.Open();
            }
            catch (Exception e)
            {
                Logger.Error(e);
                _serialCtrl.Close();
            }
            return IsOpen;
        }


        /// <summary>  
        /// 向串口内写入  
        /// </summary>  
        /// <param name="send">写入数据</param>  
        /// <param name="offSet">偏移量</param>  
        /// <param name="count">写入数量</param>  
        public static void Write(byte[] send, int offSet, int count)
        {
            if (IsOpen)
            {
                //Logger.Info("串口状态：打开");
                try
                {
                    //Logger.Info("写串口前");
                    _serialCtrl.Write(send, offSet, count);
                    //Logger.Info("写串口后");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }
            else
            {
                Logger.Info("串口状态：关闭");
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
        private static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(100);
                int datalength = _serialCtrl.BytesToRead;
                byte[] buf = new byte[datalength];//创建n个字节的缓存,   改用字节接收能解决以前的丢失数据的问题
                _serialCtrl.Read(buf, 0, datalength);//读到在数据存储到buf
                buffer.AddRange(buf);
                string byteTo = byteToHexStr(buf);
                while (buffer.IndexOf(125) > -1)
                {
                    int n = buffer.IndexOf(125);
                    byte[] array = new byte[n + 1];
                    buffer.GetRange(0, n + 1).CopyTo(array);
                    buffer.RemoveRange(0, n + 1);
                    string arr = FpComDevice.byteToHexStr(array);
                    ProcessMsg(arr);
                }
                buffer.Clear();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// 处理接收到的报文
        /// </summary>
        public static void ProcessMsg(string msg)
        {
            string commandType = msg.Substring(6, 2);

            //解析
            //86H例子：  7B 0B F4 86 B7 03 B1 00 F0 7D
            //IC卡上报
            if (commandType == "86")
            {
                CardId = msg.Substring(8, msg.Length - 12);
            }
        }
    }
}
