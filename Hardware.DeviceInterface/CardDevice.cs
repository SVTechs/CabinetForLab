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

        public const byte BLOCK0_EN = 0x01;//操作第0块
        public const byte BLOCK1_EN = 0x02;//操作第1块
        public const byte BLOCK2_EN = 0x04;//操作第2块
        public const byte NEEDSERIAL = 0x08;//仅对指定序列号的卡操作
        public const byte EXTERNKEY = 0x10;
        public const byte NEEDHALT = 0x20;//读卡或写卡后顺便休眠该卡，休眠后，卡必须拿离开感应区，再放回感应区，才能进行第二次操作。

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        //外部函数声明：让设备发出声响
        [DllImport("OUR_MIFARE.dll", EntryPoint = "pcdbeep", CallingConvention = CallingConvention.StdCall)]
        static extern byte pcdbeep(UInt32 xms);//xms单位为毫秒 


        //------------------------------------------------------------------------------------------------------------------------------------------------------    
        //只读卡号
        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccrequest", CallingConvention = CallingConvention.StdCall)]
        public static extern byte piccrequest(byte[] serial);//devicenumber用于返回编号 



        public static byte PcdDeep(UInt32 xms)
        {
            return pcdbeep(xms);
        }

        public static string PiccRequest()
        {
            string cardstr;
            byte status;//Store the return value
            byte[] mypiccserial = new byte[4];//card serial
            Int64 cardnumdec;
            status = piccrequest(mypiccserial);
            if (status == 0)
            {
                cardnumdec = mypiccserial[3];
                cardnumdec = cardnumdec * 256;
                cardnumdec = cardnumdec + mypiccserial[2];
                cardnumdec = cardnumdec * 256;
                cardnumdec = cardnumdec + mypiccserial[1];
                cardnumdec = cardnumdec * 256;
                cardnumdec = cardnumdec + mypiccserial[0];
                cardstr = Convert.ToString(cardnumdec);
                pcdbeep(38);
                return cardstr;
                
            }
            return "";
        }

    }
}
