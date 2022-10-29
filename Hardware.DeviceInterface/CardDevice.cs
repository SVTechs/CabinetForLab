using NLog;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.DeviceInterface
{
    public class CardDevice
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static SerialPort _serialCtrl;

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
    }
}
