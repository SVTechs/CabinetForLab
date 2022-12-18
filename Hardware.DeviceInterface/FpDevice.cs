using NLog;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.DeviceInterface
{
    public class FpDevice
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static SerialPort _serialCtrl;

        private static IntPtr DeviceHandle = IntPtr.Zero;
        private static UInt32 N_ADDR = 0XFFFFFFFF;//设备地址
        //StoreChar占用地址199

        public static int Init(int serialPort)
        {
            try
            {
                if (_serialCtrl == null || !_serialCtrl.IsOpen)
                {
                    _serialCtrl = new SerialPort("COM" + serialPort);
                    _serialCtrl.BaudRate = 57600;
                    _serialCtrl.Parity = Parity.None;
                    _serialCtrl.DataBits = 8;
                    _serialCtrl.StopBits = StopBits.Two;
                    _serialCtrl.Encoding = Encoding.Default;

                    try
                    {
                        _serialCtrl.Open();
                        _serialCtrl.Close();
                        int result = DriveOpration.PSOpenDeviceEx(ref DeviceHandle, DriveOpration.DEVICE_COM, serialPort, DriveOpration.BAUD_RATE_57600);
                        return result;
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

        public static int GetImage()
        {
            return DriveOpration.PSGetImage(DeviceHandle, N_ADDR);
        }

        public static int UpImage(out byte[] imageData, ref ushort templateLength)
        {
            imageData = new byte[256 * 288];
            return DriveOpration.PSUpImage(DeviceHandle, (int)N_ADDR, imageData, ref templateLength);
        }

        public static int GenChar(int bufferId)
        {

            return DriveOpration.PSGenChar(DeviceHandle, N_ADDR, bufferId);
        }

        public static int Match(ref int matchPoint)
        {
            return DriveOpration.PSMatch(DeviceHandle, (int)N_ADDR, ref matchPoint);
        }

        public static int RegModule()
        {
            return DriveOpration.PSRegModule(DeviceHandle, N_ADDR);
        }

        public static int StoreChar(int pageId)
        {
            return DriveOpration.PSStoreChar(DeviceHandle, N_ADDR, 1, pageId);
        }

        public static int UpChar(byte[] template, ref ushort templateLength)
        {
            return DriveOpration.PSUpChar(DeviceHandle, N_ADDR, 1, template, ref templateLength);
        }

        public static int DownChar(byte[] template)
        {
            return DriveOpration.PSDownChar(DeviceHandle, (int)N_ADDR, 1, template, template.Length);
        }

        public static int SearchFeature(ref int address, ref int score)
        {
            return DriveOpration.PSSearch(DeviceHandle, (int)N_ADDR, 1, 0, 200, ref address, ref score);
        }

        public static int DelFeature(int pageId)
        {
            return DriveOpration.PSDelChar(DeviceHandle, (int)N_ADDR, pageId, 1);
        }

        public static int CloseDeviceEx()
        {
            return DriveOpration.PSCloseDeviceEx(DeviceHandle);
        }

        public static void Close()
        {
            DriveOpration.PSCloseDeviceEx(DeviceHandle);
        }


    }
}
