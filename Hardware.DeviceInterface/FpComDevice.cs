using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
//串口指纹仪
//copy from Suning MeasuringDevice
//copy from CabinetDevice.cs
namespace Hardware.DeviceInterface
{
    public class FpComDevice
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static SerialPort _serialCtrl;

        /// <summary>
        /// 指纹登录检测线程AutoEvent
        /// </summary>
        public static ManualResetEvent fpDetectManualEvent = new ManualResetEvent(true);

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialPort"></param>
        /// <returns>1:成功 -1:失败</returns>
        public static int Init(int serialPort)
        {
            try
            {
                if (_serialCtrl == null || !_serialCtrl.IsOpen)
                {
                    _serialCtrl = new SerialPort("COM" + serialPort);
                    _serialCtrl.BaudRate = 19200;
                    _serialCtrl.Parity = Parity.None;
                    _serialCtrl.DataBits = 8;
                    _serialCtrl.StopBits = StopBits.One;
                    _serialCtrl.Encoding = Encoding.Default;

                    try
                    {
                        //_serialCtrl.DataReceived += DataReceived;
                        _serialCtrl.Open();

                        //Thread t = new Thread(CompareFp);
                        //t.Start();

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

        public static void StartFpDetectThread()
        {
            Thread t = new Thread(CompareFp);
            t.Start();
        }

        public static void CompareFp()
        {
            while (true)
            {
                fpDetectManualEvent.WaitOne();

                int n = Compare1N();
                if (n == -5 || n == -8 || n == -1 || n == 0) //调试时发现n=0的情况
                {
                    //Logger.Info("进入CompareFp 循环,返回值："+n.ToString());
                    continue;

                }
                else
                {
                    FpCallBack.OnUserRecognised?.Invoke(n, 1);
                    Logger.Info("CompareFp FpCallBack.OnUserRecognised?.Invoke,指纹号:" + n.ToString());
                }

                Thread.Sleep(300);
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

        /// <summary>
        /// 取用户总数
        /// </summary>
        /// <returns></returns>
        public static int GetUserCount()
        {
            byte[] send = { 0xF5, 0x09, 0x00, 0x00, 0x00, 0x00, 0x09, 0xF5 };
            byte[] recvByteArray = ReadPort(send, 8);

            if (recvByteArray == null)
            {
                return -1; //串口无数据返回
            }
            //     0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16
            //收：F5 09 00 03 00 00 0A F5
            Logger.Info("取用户总数：" + byteToHexStr(recvByteArray));
            return recvByteArray[2] * 256 + recvByteArray[3];
        }
        /// <summary>
        /// 取已登录所有用户用户号及权限
        /// </summary>
        /// <returns></returns>
        public static string GetUserList()
        {
            //F5 2B 00 0B 00 00 20 F5   
            //F5 00 03 00 03 01 00 04 01 00 05 01 00 F5
            byte[] send = { 0xF5, 0x2B, 0x00, 0x00, 0x00, 0x00, 0x2B, 0xF5 };
            byte[] recvByteArray = ReadPortUserId(send);

            if (recvByteArray == null)
            {
                return "-1"; //串口无数据返回
            }
            byte[] UserId = recvByteArray.Skip(11).Take(recvByteArray.Length - 13).ToArray();
            string userlist = "";
            int usernum = 0;
            if (UserId.Length != 0)
            {
                for (int i = 0; i < UserId.Length; i = i + 3)
                {

                    usernum = UserId[i] * 0x100 + UserId[i + 1];
                    userlist += usernum + ",";
                }
                return userlist.Substring(0, userlist.Length - 1);

            }
            return "";
        }
        /// <summary>
        /// 提取特征值
        /// </summary>
        /// <param name="sendData"></param>
        /// <returns></returns>
        private static byte[] ReadPortUserId(byte[] sendData)
        {
            //打开连接
            if (!_serialCtrl.IsOpen) Open();

            //发送数据
            Write(sendData, 0, sendData.Length);
            List<byte> recList = new List<byte>();

            //读取返回数据
            DateTime dt = DateTime.Now;
            //Thread.Sleep(1000);
            //Logger.Info("ReadPort BytesToRead:" + _serialCtrl.BytesToRead.ToString());
            while (_serialCtrl.BytesToRead < 8)
            {
                //Logger.Info("BytesToRead:" + _serialCtrl.BytesToRead.ToString());
                Thread.Sleep(100);

                if (DateTime.Now.Subtract(dt).TotalMilliseconds > 5000) //如果5秒后仍然无数据返回，则视为超时
                {
                    //Logger.Info("主板无响应");
                    return null;
                }
            }

            byte[] recData = new byte[8];
            _serialCtrl.Read(recData, 0, 8);
            recList.AddRange(recData);
            while (_serialCtrl.BytesToRead < _serialCtrl.BytesToRead)
            {
                Thread.Sleep(100);

                if (DateTime.Now.Subtract(dt).TotalMilliseconds > 5000) //如果5秒后仍然无数据返回，则视为超时
                {
                    //Logger.Info("主板无响应");
                    return null;
                }
            }



            byte[] recData2 = new byte[_serialCtrl.BytesToRead];
            _serialCtrl.Read(recData2, 0, recData2.Length);
            recList.AddRange(recData2);

            return recList.ToArray();
        }
        public static string[] MySplit(string str, int count)
        {
            var list = new List<string>();
            int length = (int)Math.Ceiling((double)str.Length / count);

            for (int i = 0; i < length; i++)
            {
                int start = count * i;
                if (str.Length <= start)
                {
                    break;
                }
                if (str.Length < start + count)
                {
                    list.Add(str.Substring(start));
                }
                else
                {
                    list.Add(str.Substring(start, count));
                }
            }

            return list.ToArray();
        }
        /// <summary>
        /// 上传特征值并按指定用户号存入 DSP 模块数据库
        /// </summary>
        /// <param name="TemplateUserId"></param>
        /// <param name="FingerFeature"></param>
        /// <returns></returns>
        public static string AddFingerFeature(string TemplateUserId, string FingerFeature)
        {
            byte[] arr = GetVs(TemplateUserId);
            byte[] send = { 0xF5, 0x41, 0x00, 0xC4, 0x00, 0x00, 0x85, 0xF5 };
            byte[] notarray = new byte[5];
            // Write(send, 0, send.Length);
            //Thread.Sleep(100);
            byte[] by = StrToHexByte(FingerFeature);
            byte[] sendPack = { 0xF5, arr[0], arr[1], 0x01 };
            byte[] b = { 0x41, 0xF5 };
            byte[] b3 = new byte[by.Length + sendPack.Length + 2];
            Buffer.BlockCopy(sendPack, 0, b3, 0, sendPack.Length);//这种方法仅适用于字节数组
            Buffer.BlockCopy(by, 0, b3, sendPack.Length, by.Length);
            Buffer.BlockCopy(b, 0, b3, by.Length + sendPack.Length, b.Length);

            byte byXor = 0;
            for (int i = 1; i < b3.Length - 2; i++)
            {
                byXor ^= b3[i];
            }
            b3[b3.Length - 2] = byXor;
            byte[] b4 = new byte[b3.Length + send.Length];
            Buffer.BlockCopy(send, 0, b4, 0, send.Length);
            Buffer.BlockCopy(b3, 0, b4, send.Length, b3.Length);

            byte[] recvByteArray = ReadPort(b4, 8);
            if (recvByteArray == null)
            {
                return "-1"; //串口无数据返回
            }
            return recvByteArray[2] * 256 + recvByteArray[3].ToString();
        }
        /// <summary>
        /// 1:N比对
        /// </summary>
        /// <returns>-5:无此用户 -8:采集超时</returns>
        public static int Compare1N()
        {
            byte[] send = { 0xF5, 0x0C, 0x00, 0x00, 0x02, 0x00, 0x0E, 0xF5 };
            byte[] recvByteArray = ReadPort(send, 8);
            if (recvByteArray == null)
            {
                return -1; //串口无数据返回，表示没有用户刷指纹
            }
            //     0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16
            //收：F5 0C 01 02 02 00 0D F5
            //Logger.Info("1:N比对：" + byteToHexStr(recvByteArray));

            //ACK_NOUSER  0x05 //无此用户
            //ACK_TIMEOUT 0x08 //采集超时
            if (recvByteArray[4] == 0x05)
            {
                return -5;
            }
            else if (recvByteArray[4] == 0x08)
            {
                return -8;
            }
            else
            {
                return recvByteArray[2] * 256 + recvByteArray[3];
            }
        }

        /// <summary>
        /// 向串口发送数据，读取返回数据
        /// </summary>
        /// <param name="sendData">发送的数据</param>
        /// <param name="receivedBytesCount">应收到的字节数</param>
        /// <returns>返回的数据</returns>
        private static byte[] ReadPort(byte[] sendData, int receivedBytesCount)
        {
            //打开连接
            if (!_serialCtrl.IsOpen) Open();
            //发送数据
            Write(sendData, 0, sendData.Length);

            //读取返回数据
            DateTime dt = DateTime.Now;
            //Thread.Sleep(1000);
            //Logger.Info("ReadPort BytesToRead:" + _serialCtrl.BytesToRead.ToString());
            while (_serialCtrl.BytesToRead < receivedBytesCount)
            {
                //Logger.Info("BytesToRead:" + _serialCtrl.BytesToRead.ToString());
                Thread.Sleep(100);

                if (DateTime.Now.Subtract(dt).TotalMilliseconds > 5000) //如果5秒后仍然无数据返回，则视为超时
                {
                    //Logger.Info("主板无响应");
                    return null;
                }
            }

            List<byte> recList = new List<byte>();
            byte[] recData = new byte[_serialCtrl.BytesToRead];
            _serialCtrl.Read(recData, 0, recData.Length);
            recList.AddRange(recData);

            return recList.ToArray();
        }
        /// <summary>
        /// 提取特征值
        /// </summary>
        /// <param name="sendData"></param>
        /// <returns></returns>
        private static byte[] ReadPortData(byte[] sendData)
        {
            //打开连接
            if (!_serialCtrl.IsOpen) Open();

            //发送数据
            Write(sendData, 0, sendData.Length);
            List<byte> recList = new List<byte>();

            //读取返回数据
            DateTime dt = DateTime.Now;
            //Thread.Sleep(1000);
            //Logger.Info("ReadPort BytesToRead:" + _serialCtrl.BytesToRead.ToString());
            while (_serialCtrl.BytesToRead < 8)
            {
                //Logger.Info("BytesToRead:" + _serialCtrl.BytesToRead.ToString());
                Thread.Sleep(100);

                if (DateTime.Now.Subtract(dt).TotalMilliseconds > 5000) //如果5秒后仍然无数据返回，则视为超时
                {
                    //Logger.Info("主板无响应");
                    return null;
                }
            }

            byte[] recData = new byte[8];
            _serialCtrl.Read(recData, 0, 8);
            recList.AddRange(recData);
            while (_serialCtrl.BytesToRead < 199)
            {
                Thread.Sleep(100);

                if (DateTime.Now.Subtract(dt).TotalMilliseconds > 5000) //如果5秒后仍然无数据返回，则视为超时
                {
                    //Logger.Info("主板无响应");
                    return null;
                }
            }



            byte[] recData2 = new byte[_serialCtrl.BytesToRead];
            _serialCtrl.Read(recData2, 0, recData2.Length);
            recList.AddRange(recData2);

            return recList.ToArray();
        }
        //计算异或和
        public static byte checksum(byte[] b)
        {
            //03 00 03 01 00
            int i;
            byte x = 0;
            for (i = 1; i < b.Length - 2; i++)
            {
                x ^= b[i];
            }
            return x;
        }
        //10进制转16进制
        public static byte[] GetVs(string TemplateUserId)
        {
            int value = Convert.ToInt32(TemplateUserId);
            int hValue = (value >> 8) & 0xFF;
            int lValue = value & 0xFF;
            byte[] arr = new byte[] { (byte)hValue, (byte)lValue };
            return arr;
        }
        /// <summary>
        /// 添加指纹
        /// </summary>
        /// <param name="TemplateUserId"></param>
        /// <returns></returns>
        public static String GetFingerFeature(string TemplateUserId)
        {
            //DeleteUser(TemplateUserId);
            byte[] arr = GetVs(TemplateUserId);
            byte[] send = { 0xF5, 0x01, arr[0], arr[1], 0x01, 0x00, 0x03, 0xF5 };

            byte csum = checksum(send);//校验和，为第 2 字节到第 6 字节的异或值notarray = new byte[5];
            send[6] = csum;

            byte[] recvByteArray = ReadPort(send, 8);
            if (recvByteArray == null)
            {
                return "-1"; //串口无数据返回
            }
            else if (recvByteArray[4] == 1)
            {
                return "1";//操作失败
            }
            else if (recvByteArray[4] == 4)
            {
                return "4";//指纹数据库已满 
            }
            else if (recvByteArray[4] == 5)
            {
                return "5";//无此用户 
            }
            else if (recvByteArray[4] == 6)
            {
                return "6";//用户已存在 
            }
            else if (recvByteArray[4] == 7)
            {
                return "7";//指纹已存在 
            }
            else
            if (recvByteArray[4] == 0)//操作成功
            {
                byte[] sendOne = { 0xF5, 0x02, arr[0], arr[1], 0x01, 0x00, 0x02, 0xF5 };
                byte csun = checksum(sendOne);
                sendOne[6] = csun;
                
                byte[] recvByteArrayOne = ReadPort(sendOne,8);
                if (recvByteArrayOne == null)
                {
                    return "-1"; //串口无数据返回
                }
                else if (recvByteArrayOne[4] == 1)
                {
                    return "1";//操作失败
                }
                else if (recvByteArrayOne[4] == 4)
                {
                    return "4";//指纹数据库已满 
                }
                else if (recvByteArrayOne[4] == 5)
                {
                    return "5";//无此用户 
                }
                else if (recvByteArrayOne[4] == 6)
                {
                    return "6";//用户已存在 
                }
                else if (recvByteArrayOne[4] == 7)
                {
                    return "7";//指纹已存在 
                }
                else if (recvByteArrayOne[4] == 0)
                {
                    byte[] sendTo = { 0xF5, 0x06, arr[0], arr[1], 0x01, 0x00, 0x03, 0xF5 };
                    byte c = checksum(sendTo);//校验和，为第 2 字节到第 6 字节的异或值notarray = new byte[5];
                    sendTo[6] = c;
                    byte[] recvByteArrayTo = ReadPortData(sendTo);
                    if (recvByteArrayTo == null)
                    {
                        return "-1"; //串口无数据返回
                    }
                    else if (recvByteArrayTo[4] == 1)
                    {
                        return "1";//操作失败
                    }
                    else if (recvByteArrayTo[4] == 4)
                    {
                        return "4";//指纹数据库已满 
                    }
                    else if (recvByteArrayTo[4] == 5)
                    {
                        return "5";//无此用户 
                    }
                    else if (recvByteArrayTo[4] == 6)
                    {
                        return "6";//用户已存在 
                    }
                    else if (recvByteArrayTo[4] == 7)
                    {
                        return "7";//指纹已存在 
                    }
                    else if (recvByteArrayTo[4] == 0)
                    {
                        var EigenValue = recvByteArrayTo.Skip(12).Take(193).ToArray();
                        string result = "";
                        result = byteToHexStr(EigenValue);
                        AddFingerFeature(TemplateUserId, result);

                        return result;//操作成功
                    }
                }
            }
            return "-1";
        }
        /// <summary>
        /// 删除指定用户
        /// </summary>
        /// <param name="TemplateUserId"></param>
        /// <returns></returns>
        public static string DeleteUser(string TemplateUserId)
        {
            byte[] arr = GetVs(TemplateUserId);//计算高八位低八位
            byte[] send = { 0xF5, 0x04, arr[0], arr[1], 0x00, 0x00, 0x2B, 0xF5 };

            byte c = checksum(send);//校验和，为第 2 字节到第 6 字节的异或值
            send[6] = c;
            byte[] recvByteArray = ReadPort(send, 8);
            if (recvByteArray == null)
            {
                return "-1";//串口无数据返回
            }
            return byteToHexStr(recvByteArray);
        }

    }
}
