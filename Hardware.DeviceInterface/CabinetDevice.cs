using NLog;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
//copy from Suning MeasuringDevice
namespace Hardware.DeviceInterface
{
    public class CabinetDevice
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static SerialPort _serialCtrl;
        private static List<byte> buffer = new List<byte>();
        /// <summary>
        /// 各副柜/锁的地址List
        /// </summary>
        public static List<string> LockAddrList = new List<string>();
        public static byte light = 0;

        /// <summary>
        /// 上报的IC卡号是否用于IC卡录入 1：是 0：不是，而是用于登录
        /// </summary>
        public static int IsICCardInput = 0;

        /// <summary>
        /// 
        /// </summary>
        public static string globeCardId = string.Empty;
        /// <summary>
        /// 用户操作起始时间全局变量，用于用户登录无操作后一段时间后退出，及报警判断
        /// </summary>
        public static DateTime gUserLoginTime = DateTime.Now;

        public static ManualResetEvent subCabinetStatusChangeManualEvent = new ManualResetEvent(true);

        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string ByteToHexStr(byte[] bytes)
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
        
        public static void EmulateToolTaken(int toolPosition)
        {
            CabinetCallback.OnToolTaken?.Invoke(toolPosition);
        }

        public static void EmulateToolReturn(int toolPosition)
        {
            CabinetCallback.OnToolReturn?.Invoke(toolPosition);
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
            //For test
            //byte[] send = { 0x7B, 0x09, 0x01, 0x02, 0x00, 0x0E, 0x02, 0x1C, 0x7D };    
            //Logger.Info(byteToHexStr(send));

            try
            {
                if (_serialCtrl == null || !_serialCtrl.IsOpen)
                {
                    _serialCtrl = new SerialPort("COM" + serialPort)
                    {
                        BaudRate = 9600,
                        Parity = Parity.None,
                        DataBits = 8,
                        StopBits = StopBits.One,
                        Encoding = Encoding.Default
                    };

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

        public static void QueryAllSubCabinetState()
        {
            //先查询一遍副柜状态
            for (int i = 1; i <= LockAddrList.Count; i++)
            {
                CabinetDevice.SubCabinetState(i.ToString());
                Thread.Sleep(10);
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
                int datalength = _serialCtrl.BytesToRead;
                byte[] buf = new byte[datalength];//创建n个字节的缓存,   改用字节接收能解决以前的丢失数据的问题
                _serialCtrl.Read(buf, 0, datalength);//读数据存储到buf

                string rawMessage = FpComDevice.byteToHexStr(buf);
                Logger.Info("工具柜串口接收rawMessage：" + rawMessage);

                buffer.AddRange(buf);
                while (buffer.IndexOf(0x7D) > -1)
                {
                    int n = buffer.IndexOf(0x7D);
                    byte[] array = new byte[n + 1];
                    buffer.GetRange(0, n + 1).CopyTo(array);
                    buffer.RemoveRange(0, n + 1);
                    string arr = FpComDevice.byteToHexStr(array);
                    ProcessMsg(arr);                   
                }

            }
            catch(Exception ex)
            {
                Logger.Error(ex);
            }
        }

        /// <summary>
        /// 处理接收到的报文
        /// </summary>
        public static void ProcessMsg(string msg)
        {
            string cardId = "";

            string commandType = msg.Substring(6, 2);

            //解析
            //86H例子：  7B 0B F4 86 B7 03 B1 00 F0 7D
            //IC卡上报
            if (commandType == "86")
            {
                cardId = msg.Substring(8, msg.Length-12);
                if (IsICCardInput == 1)
                {
                    globeCardId = cardId;
                }
                else
                {
                    globeCardId = string.Empty;
                    CabinetDeviceCallback.OnICCardReceived.Invoke(cardId);
                }
            }
            //87H例子：  7B 09 F6 87 0E 30 31 F5 7D
            //副柜状态上报
            //根据地址找到副柜，解析出
            /*Bit5:锁舌状态
            0:锁舌(无动作)伸出
            1:锁舌(动作)缩回
            Bit4:门磁状态
            0:门被拉开
            1:门被闭合*/
            else if (commandType == "87")
            {
                subCabinetStatusChangeManualEvent.Reset();

                Logger.Info("查询副柜状态返回报文："+ msg);

                string addr = msg.Substring(8,2);
                int index = LockAddrList.IndexOf(addr);
                if(index<0)
                {
                    return;
                }
                
                byte b = Convert.ToByte(msg.Substring(12, 2), 16); //解析出副柜状态字节

                byte byte5 = 0b00100000;

                int openStatusOld = AllDevices.doorStatusArray[index].OpenStatus; //改下标

                if ((byte5 & b) == byte5)
                {
                    AllDevices.doorStatusArray[index].DoorMagnetismStatus = 1; //改下标
                }
                else
                {
                    AllDevices.doorStatusArray[index].DoorMagnetismStatus = 0;
                }

                byte byte4 = 0b00010000;
                if ((byte4 & b) == byte4)
                {
                    AllDevices.doorStatusArray[index].SpringBoltStatus = 1;
                }
                else
                {
                    AllDevices.doorStatusArray[index].SpringBoltStatus = 0;
                }

                int openStatusNew = AllDevices.doorStatusArray[index].OpenStatus;
                //门状态由开门变成关门，设置第1次关门变量, 有情况是从2变为0
                if ((openStatusOld == 1 && openStatusNew == 0)|| (openStatusOld == 2 && openStatusNew == 0))
                {
                    AllDevices.doorStatusArray[index].IsFirstClose = true; 
                }
                gUserLoginTime = DateTime.Now; //状态有变化了，肯定是用户有操作了
                subCabinetStatusChangeManualEvent.Set();
            }
            //其他, 不需处理
        }

        /// <summary>
        /// 开锁
        /// </summary>
        /// <param name="SubCabinetNo">副柜号</param>
        public static void Unlock(string SubCabinetNo)
        {
            //副柜地址
            byte bt = Convert.ToByte(LockAddrList[Convert.ToInt32(SubCabinetNo) - 1], 16);
            byte[] send = { 0x7B, 0x07, 0xF8, 0x04, bt, 0x00, 0x7D };

            byte[] notarray = new byte[4];
            Array.Copy(send, 1, notarray, 0, 4);

            byte c = Checksum(notarray);
            send[5] = c;

            string s = ByteToHexStr(send); //test

            if (_serialCtrl.IsOpen)
            {
                Write(send, 0, send.Length);
            }
        }

        /// <summary>
        /// 上锁
        /// </summary>
        public static void Locked(string SubCabinetNo)
        {
            //副柜地址
            byte bt = Convert.ToByte(LockAddrList[Convert.ToInt32(SubCabinetNo) - 1], 16);
            byte[] send = { 0x7B, 0x07, 0xF8, 0x05, bt, 0x00, 0x7D }; // 0x00 校验位，后来改值

            byte[] notarray = new byte[4];
            Array.Copy(send, 1, notarray, 0, 4);

            byte c= Checksum(notarray);
            send[5] = c;

            string s = ByteToHexStr(send); //test

            if (_serialCtrl.IsOpen)
            {
                Write(send, 0, send.Length);
            }
        }

        /// <summary>
        /// 查看副柜状态
        /// </summary>
        public static void SubCabinetState(string SubCabinetNo)
        {
            //副柜地址
            byte bt = Convert.ToByte(LockAddrList[Convert.ToInt32(SubCabinetNo) - 1], 16);
            byte[] send = { 0x7B, 0x07, 0xF8, 0x07, bt, 0x00, 0x7D }; // 0x00 校验位，后来改值

            byte[] notarray = new byte[4];
            Array.Copy(send, 1, notarray, 0, 4);

            byte c = Checksum(notarray);
            send[5] = c;

            if (_serialCtrl.IsOpen)
            {
                Write(send, 0, send.Length);
            }

            Logger.Info("查询副柜状态，副柜号：" + SubCabinetNo+"，报文："+ ByteToHexStr(send));
        }

        /// <summary>
        /// 开灯
        /// </summary>
        public static void OpenLamp(string SubCabinetNo, int ToolPositionType)
        {
            //副柜地址
            byte bt = Convert.ToByte(LockAddrList[Convert.ToInt32(SubCabinetNo) - 1], 16);
            //各层灯控制
            Switchlight(ToolPositionType);
            byte[] send = { 0x7B, 0x08, 0xF7, 0x02, bt, light, 0x12, 0x7D };
            byte[] notarray = new byte[5];
            Array.Copy(send, 1, notarray, 0, 5);
            byte c = Checksum(notarray);//校验和，为第 2 字节到第 6 字节的异或值
            send[6] = c;
            //byte[] send = { 0x7B, 0x08, 0xF7, 0x02, 0x01, 0x10, 0x12, 0x7D };

            if (_serialCtrl.IsOpen)
            {
                Write(send, 0, send.Length);
            }
        }
        /// <summary>
        /// 灯全开
        /// </summary>
        /// <param name="SubCabinetNo"></param>
        public static void OpenAllLamp(string SubCabinetNo)
        {
            //各层灯控制
            Switchlight(7);
            //副柜地址
            byte bt = Convert.ToByte(LockAddrList[Convert.ToInt32(SubCabinetNo) - 1], 16);
            byte[] send = { 0x7B, 0x08, 0xF7, 0x02, bt, 0xFF, 0x23, 0x7D };
            byte[] notarray = new byte[5];
            Array.Copy(send, 1, notarray, 0, 5);
            byte c = Checksum(notarray);//校验和，为第 2 字节到第 6 字节的异或值
            send[6] = c;

            if (_serialCtrl.IsOpen)
            {
                Write(send, 0, send.Length);
            }
        }
        /// <summary>
        /// 灯全关
        /// </summary>
        /// <param name="SubCabinetNo"></param>
        public static void TurnOffAllLight(string SubCabinetNo)
        {
            //各层灯控制
            Switchlight(7);
            //副柜地址
            byte bt = Convert.ToByte(LockAddrList[Convert.ToInt32(SubCabinetNo) - 1], 16);
            byte[] send = { 0x7B, 0x08, 0xF7, 0x03, bt, 0xFF, 0x23, 0x7D };
            byte[] notarray = new byte[5];
            Array.Copy(send, 1, notarray, 0, 5);
            byte c = Checksum(notarray);//校验和，为第 2 字节到第 6 字节的异或值
            send[6] = c;
            
            if (_serialCtrl.IsOpen)
            {
                Write(send, 0, send.Length);
            }
        }

        /// <summary>
        /// 对应层灯命令
        /// </summary>
        /// <param name="ToolPositionType"></param>
        public static void Switchlight(int ToolPositionType)
        {
            switch (ToolPositionType)
            {
                case 1:
                    light = 01;
                    break;
                case 2:
                    light = 02;
                    break;
                case 3:
                    light = 04;
                    break;
                case 4:
                    light = 08;
                    break;
                case 5:
                    light = 0x10;
                    break;
                default:
                    light = 00;
                    break;
            }
        }

        /// <summary>
        /// 关灯
        /// </summary>
        /// <param name="SubCabinetNo"></param>
        /// <param name="ToolPositionType"></param>
        public static void TurnLight(string SubCabinetNo, int ToolPositionType)
        {
            //副柜地址
            byte bt = Convert.ToByte(LockAddrList[Convert.ToInt32(SubCabinetNo) - 1], 16);
            //各层灯控制
            Switchlight(ToolPositionType);
            byte[] send = { 0x7B, 0x08, 0xF7, 0x03, bt, light, 0x12, 0x7D };
            byte[] notarray = new byte[5];
            Array.Copy(send, 1, notarray, 0, 5);
            byte c = Checksum(notarray);//校验和，为第 2 字节到第 6 字节的异或值
            send[6] = c;
            if (_serialCtrl.IsOpen)
            {
                Write(send, 0, send.Length);
            }
        }

        /// <summary>
        /// 累加和校验
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static byte Checksum(byte[] b)
        {
            int i;
            byte x;
            x = 0;
            for (i = 0; i < b.Length; i++)
            {
                x += b[i];
            }
            return x;
        }
    }
}
