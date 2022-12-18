using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.DeviceInterface
{
    public class DriveOpration
    {
        #region  错误类型

        public static int PS_OK = 0x00;
        public static int PS_COMM_ERR = 0x01;
        public static int PS_NO_FINGER = 0x02;
        public static int PS_GET_IMG_ERR = 0x03;
        public static int PS_FP_TOO_DRY = 0x04;
        public static int PS_FP_TOO_WET = 0x05;
        public static int PS_FP_DISORDER = 0x06;
        public static int PS_LITTLE_FEATURE = 0x07;
        public static int PS_NOT_MATCH = 0x08;
        public static int PS_NOT_SEARCHED = 0x09;
        public static int PS_MERGE_ERR = 0x0a;
        public static int PS_ADDRESS_OVER = 0x0b;
        public static int PS_READ_ERR = 0x0c;
        public static int PS_UP_TEMP_ERR = 0x0d;
        public static int PS_RECV_ERR = 0x0e;
        public static int PS_UP_IMG_ERR = 0x0f;
        public static int PS_DEL_TEMP_ERR = 0x10;
        public static int PS_CLEAR_TEMP_ERR = 0x11;
        public static int PS_SLEEP_ERR = 0x12;
        public static int PS_INVALID_PASSWORD = 0x13;
        public static int PS_RESET_ERR = 0x14;
        public static int PS_INVALID_IMAGE = 0x15;
        public static int PS_HANGOVER_UNREMOVE = 0X17;

        #endregion

        #region  设备类型

        public static int DEVICE_USB = 0;
        public static int DEVICE_COM = 1;
        public static int DEVICE_UDisk = 2;

        #endregion

        #region 串口号

        public static int COM1 = 0x01;
        public static int COM2 = 0x02;
        public static int COM3 = 0x03;
        public static int COM4 = 0x04;
        public static int COM5 = 0x05;

        #endregion

        #region  默认波特率

        public static int BAUD_RATE_9600 = 0x01;
        public static int BAUD_RATE_19200 = 0x02;
        public static int BAUD_RATE_38400 = 0x04;
        public static int BAUD_RATE_57600 = 0x06;  //default 
        public static int BAUD_RATE_115200 = 0x0C;

        #endregion

        #region  Function

        //
        //[OUT] 
        //[IN] 设备类型，DEVICE_USB、DEVICE_COM、DEVICE_ UDisk
        //[IN] 串口号 1~16
        //[IN] 波特率 1~n，其值*9600=实际波特率值
        //[IN] 数据包大小，实际数据包大小= 32*(0x01<<nPackageSize)
        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <param name="nDeviceType">设备类型，DEVICE_USB、DEVICE_COM、DEVICE_ UDisk</param>
        /// <param name="iCom">串口号 1~16</param>
        /// <param name="iBaud">波特率 1~n，其值*9600=实际波特率值</param>
        /// <param name="nPackageSize">数据包大小，实际数据包大小= 32*(0x01<<nPackageSize)</param>
        /// <param name="iDevNum">设备号，0~n</param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSOpenDeviceEx", CallingConvention = CallingConvention.Winapi)]
        public extern static int PSOpenDeviceEx(ref IntPtr pHandle, int nDeviceType, int iCom = 1, int iBaud = 1, int nPackageSize = 2, int iDevNum = 0);

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSCloseDeviceEx", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSCloseDeviceEx(IntPtr pHandle);

        /// <summary>
        /// 检测手指并录取图像 
        /// </summary>
        /// <param name="pHandle"> 设备句柄 </param>
        /// <param name="nAddr"> 设备地址 </param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSGetImage", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSGetImage(IntPtr pHandle, UInt32 nAddr);

        /// <summary>
        /// 检测手指并录取图像；光学特殊命令，注册时使用。 命令码 0x29 
        /// </summary>
        /// <param name="pHandle"> 设备句柄 </param>
        /// <param name="nAddr"> 设备地址 </param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSGetImage_Enroll", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSGetImage_Enroll(IntPtr pHandle, int nAddr);

        //自动注册 采集一次指纹注册模板，在指纹库中搜索空位并存储，返回存储ID
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSEnroll", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSGenChar(IntPtr pHandle, UInt32 nAddr, ref int nID);

        /// <summary>
        /// 生成指纹特征
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <param name="nAddr">设备地址0xFFFFFFFF</param>
        /// <param name="iBufferID">BufferID 号。1，2，3，4</param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSGenChar", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSGenChar(IntPtr pHandle, UInt32 nAddr, int iBufferID);

        /// <summary>
        /// 将 CharBufferA 与 CharBufferB 中的特征文件合并生成模板存于 ModelBuffer
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <param name="nAddr">设备地址0xFFFFFFFF</param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSRegModule", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSRegModule(IntPtr pHandle, UInt32 nAddr);

        /// <summary>
        /// 将 ModelBuffer 中的文件储存到 flash 指纹库中。 
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <param name="nAddr">设备地址0xFFFFFFFF</param>
        /// <param name="iBufferID">BufferID 号。1，2，3，4 </param>
        /// <param name="iPageID">指纹库地址</param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSStoreChar", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSStoreChar(IntPtr pHandle, UInt32 nAddr, int iBufferID, int iPageID);


        /// <summary>
        /// 清空 flash 指纹库 
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <param name="nAddr">设备地址0xFFFFFFFF</param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSEmpty", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSEmpty(IntPtr pHandle, UInt32 nAddr);

        /// <summary>
        /// 从 flash 指纹库中读取一个模板到 ModelBuffer。 返回值： 成功-PS_OK；
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <param name="nAddr">设备地址0xFFFFFFFF</param>
        /// <param name="iBufferID">BufferID 号。1，2，3，4 </param>
        /// <param name="iPageID">指纹库地址</param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSLoadChar", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSLoadChar(IntPtr hHandle, UInt32 nAddr, int iBufferID, int iPageID);

        /// <summary>
        /// 将特征缓冲区中的文件上传给上位机。 
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <param name="nAddr">设备地址0xFFFFFFFF</param>
        /// <param name="iBufferID">BufferID 号。1，2，3，4 </param>
        /// <param name="pTemplet">指纹特征</param>
        /// <param name="iTempletLength">特征大小</param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSUpChar", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSUpChar(IntPtr pHandle, UInt32 nAddr, int iBufferID, byte[] pTemplet, ref UInt16 iTempletLength);

        //PC下载特征到设备
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSDownChar", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSDownChar(IntPtr pHandle, int nAddr, int iBufferID, byte[] pTemplet, int iTempletLength);

        [DllImport("SynoAPIEx.dll", EntryPoint = "PSSearch", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSSearch(IntPtr hHandle, int nAddr, int iBufferID, int iStartPage, int iPageNum, ref int iMbAddress, ref int iscore);


        //比对特征
        /// <summary>
        /// 精确比对 CharBufferA 与 CharBufferB 中的特征文件
        /// </summary>
        /// <param name="pHandle">设备句柄</param>
        /// <param name="nAddr">设备地址0xFFFFFFFF</param>
        /// <param name="iScore">]比对分值，值越大越相似，一般阀值为 50 </param>
        /// <returns></returns>
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSMatch", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSMatch(IntPtr pHandle, int nAddr, ref int iScore);

        //上传原始图像到PC
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSUpImage", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSUpImage(IntPtr pHandle, int nAddr, byte[] pImageData, ref UInt16 iImageLength);

        //将图像数据存储为 BMP 图片 
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSImgData2BMP", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSImgData2BMP(byte[] pImgData, string pImageFile);

        //从 BMP 图片读取图像数据
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSGetImgDataFromBMP", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSGetImgDataFromBMP(IntPtr hHandle, string pImageFile, byte[] pImageData, ref UInt16 pnImageLen);

        //验证设备握手口令
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSSetPwd", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSSetPwd(IntPtr pHandle, int nAddr, IntPtr pPassword);

        //根据错误码获取错误信息   -1:发送数据包失败  1：数据包接收错误  0：执行成功、///
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSErr2Str", CallingConvention = CallingConvention.StdCall)]
        public extern static IntPtr PSErr2Str(int nErrCode);

        //删除Gen 
        [DllImport("SynoAPIEx.dll", EntryPoint = "PSDelChar", CallingConvention = CallingConvention.StdCall)]
        public extern static int PSDelChar(IntPtr pHandle, int nAddr, int iStartPage, int nDelPageNum);

        #endregion 
    }
}
