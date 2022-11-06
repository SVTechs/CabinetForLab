using NLog;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.DeviceInterface
{
    public class CardDevice
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public const byte BLOCK0_EN = 0x01;//Operating 0 blocks
        public const byte BLOCK1_EN = 0x02;//Operating 1 blocks
        public const byte BLOCK2_EN = 0x04;//Operating 2 blocks
        public const byte NEEDSERIAL = 0x08;//Only the specified serial number card operation
        public const byte EXTERNKEY = 0x10;
        public const byte NEEDHALT = 0x20;//Read or write CARDS after dormancy card, by the way, after dormancy, leave induction card must take, return to active area, to carry out the second operation。

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //外部函数声明：让设备发出声响
        [DllImport("OUR_MIFARE.dll", EntryPoint = "pcdbeep", CallingConvention = CallingConvention.StdCall)]
        static extern byte pcdbeep(UInt32 xms);//xms  milliseconds 

        //------------------------------------------------------------------------------------------------------------------------------------------------------    
        //Read card Serial Number only 
        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccrequest_ul", CallingConvention = CallingConvention.StdCall)]
        public static extern byte piccrequest_ul(byte[] serial);// Serial Number 



        public static byte PcdDeep(UInt32 xms)
        {
            return pcdbeep(xms);
        }

        public static byte PiccRequest(byte[] piccserial)
        {
            return piccrequest_ul(piccserial);
        }

    }
}
