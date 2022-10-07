using Domain.Main.Domain;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Hardware.DeviceInterface
{
    public class DoorStatus
    {
        /// <summary>
        /// 0正常 1报警
        /// </summary>
        public int AlertStatus;

        /// <summary>
        /// 0真正关  1真正开 2门磁状态门闭合,但锁舌没锁
        /// </summary>
        public int OpenStatus
        {
            get
            {
                if (DoorMagnetismStatus==0) //真正开门
                {
                    return 1;
                }
                else if(DoorMagnetismStatus==1 && SpringBoltStatus==0) //真正关门
                {
                    return 0;
                }
                else //DoorMagnetismStatus=1(门磁状态门闭合) SpringBoltStatus==1(锁舌没锁)
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// 上一次解锁(开门)时间
        /// </summary>
        public DateTime LastDoorUnlock;

        /// <summary>
        /// 第一次关门时将值改为true，工具柜关门事件同步完数据后改为false
        /// </summary>
        public bool IsFirstClose = false;

        /// <summary>
        /// 锁舌状态 0:锁舌(无动作)伸出  1:锁舌(动作)缩回
        /// </summary>
        public int SpringBoltStatus=0;

        /// <summary>
        /// 门磁状态 0:门被拉开 1:门被闭合
        /// </summary>
        public int DoorMagnetismStatus = 1;

        public DoorStatus()
        {
            AlertStatus = 0;
            //OpenStatus = 0;
        }

        public void SetDoorOpen()
        {
            //OpenStatus = 1;
            LastDoorUnlock = DateTime.Now;
        }

        public void SetDoorClose()
        {
            //OpenStatus = 0;
        }
    }

    public class AllDevices
    {
        public static RFIDDevice[] RFIDDeviceArray = new RFIDDevice[50];

        public static DoorStatus[] doorStatusArray = new DoorStatus[50];

        public static int SubCabinetCount = 0;

        /// <summary>
        /// 量值所有门是否是第1次全关
        /// </summary>
        public static bool IsLZAllDoorFirstClose = false;

        /// <summary>
        /// 锁数量
        /// </summary>
        public static int LockCount = 0;

        /// <summary>
        /// 所有门是否全关，是true  否false
        /// </summary>
        /// <returns></returns>
        public static bool IsAllDoorClose()
        {
            for (int i = 0; i < LockCount; i++)
            {
                if (doorStatusArray[i].OpenStatus == 1 || doorStatusArray[i].OpenStatus == 2)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class RFIDDevice
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private Reader.ReaderMethod reader;

        private ReaderSetting m_curSetting = new ReaderSetting();
        public InventoryBuffer m_curInventoryBuffer = new InventoryBuffer();

        //盘存操作前，需要先设置工作天线，用于标识当前是否在执行盘存操作
        public bool m_bInventory = false;

        //实时盘存次数
        private int m_nTotal = 0;

        private volatile bool m_nSessionPhaseOpened = false;

        public int subCabinetNo; //副柜号
        List<string> toolCheckerAntList;

        public RFIDDevice()
        {
        }

        /// <summary>
        /// 获取单个副柜的RFID
        /// </summary>
        /// <param name="rFIDReadCycle">RFID读取时长</param>
        /// <param name="toolList">用于存储获取到的RFID</param>
        public void GetRfid(int rFIDReadCycle, ref List<ToolInfo> toolList)
        {
            RFIDDevice rfidDevice = AllDevices.RFIDDeviceArray[subCabinetNo - 1];

            rfidDevice.btRealTimeInventory_Click();

            TimeSpan timeSpan;
            DateTime dtStart = DateTime.Now;
            do
            {
                DateTime dtEndTime = DateTime.Now;
                timeSpan = dtEndTime - dtStart;
                if (timeSpan.TotalMilliseconds > rFIDReadCycle)
                {
                    rfidDevice.m_bInventory = false;
                    rfidDevice.m_curInventoryBuffer.bLoopInventory = false;
                    //btRealTimeInventory.Text = "开始盘存";

                    for (int i = 0; i < rfidDevice.m_curInventoryBuffer.dtTagTable.Rows.Count; i++)
                    {
                        DataRow row = rfidDevice.m_curInventoryBuffer.dtTagTable.Rows[i];
                        var tool = new ToolInfo();
                        tool.RFID = row[2].ToString().Replace(" ", "");
                        tool.SubCabinetNo = subCabinetNo;
                        toolList.Add(tool);
                    }
                }
            } while (timeSpan.TotalMilliseconds <= rFIDReadCycle);
        }

        /// <summary>
        /// 量值检修获取单个副柜的RFID
        /// </summary>
        /// <param name="rFIDReadCycle">RFID读取时长</param>
        /// <param name="toolList">用于存储获取到的RFID</param>
        public void GetRfidLZ(int rFIDReadCycle, ref List<CabinetDomain.Domain.ToolInfo> toolList)
        {
            RFIDDevice rfidDevice = AllDevices.RFIDDeviceArray[subCabinetNo - 1];

            rfidDevice.btRealTimeInventory_Click();

            TimeSpan timeSpan;
            DateTime dtStart = DateTime.Now;
            do
            {
                DateTime dtEndTime = DateTime.Now;
                timeSpan = dtEndTime - dtStart;
                if (timeSpan.TotalMilliseconds > rFIDReadCycle)
                {
                    rfidDevice.m_bInventory = false;
                    rfidDevice.m_curInventoryBuffer.bLoopInventory = false;
                    //btRealTimeInventory.Text = "开始盘存";

                    for (int i = 0; i < rfidDevice.m_curInventoryBuffer.dtTagTable.Rows.Count; i++)
                    {
                        DataRow row = rfidDevice.m_curInventoryBuffer.dtTagTable.Rows[i];
                        var tool = new CabinetDomain.Domain.ToolInfo();
                        tool.RFID = row[2].ToString().Replace(" ", "");
                        tool.SubCabinetNo = subCabinetNo;
                        toolList.Add(tool);
                    }
                }
            } while (timeSpan.TotalMilliseconds <= rFIDReadCycle);
        }

        public void R2000UartDemo_Load()
        {
            //初始化访问读写器实例
            reader = new Reader.ReaderMethod();

            //回调函数
            reader.AnalyCallback = AnalyData;
            reader.ReceiveCallback = ReceiveData;
            reader.SendCallback = SendData;
        }

        private void ReceiveData(byte[] btAryReceiveData)
        {
            //if (m_bDisplayLog)
            //{
            //    string strLog = CCommondMethod.ByteArrayToString(btAryReceiveData, 0, btAryReceiveData.Length);

            //    WriteLog(lrtxtDataTran, strLog, 1);
            //}            
        }

        private void SendData(byte[] btArySendData)
        {
            //if (m_bDisplayLog)
            //{
            //    string strLog = CCommondMethod.ByteArrayToString(btArySendData, 0, btArySendData.Length);

            //    WriteLog(lrtxtDataTran, strLog, 0);
            //}            
        }

        private void AnalyData(Reader.MessageTran msgTran)
        {
            //m_nReceiveFlag = 0;
            if (msgTran.PacketType != 0xA0)
            {
                return;
            }
            switch (msgTran.Cmd)
            {

                case 0x74:
                    ProcessSetWorkAntenna(msgTran);
                    break;


                case 0x89:
                case 0x8B:
                    ProcessInventoryReal(msgTran);
                    break;
                case 0x6c:
                    ProcessSetReaderAntGroup(msgTran);
                    break;
                default:
                    break;
            }
        }

        private void ProcessSetReaderAntGroup(Reader.MessageTran msgTran)
        {
            string strCmd = "设置天线组";
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    //WriteLog(lrtxtLog, strCmd, 0);
                    switch (m_curSetting.OpType)
                    {
                        case 7:
                            byte btWorkAntenna = m_curInventoryBuffer.lAntenna[m_curInventoryBuffer.nIndexAntenna];
                            reader.SetWorkAntenna(m_curSetting.btReadId, btWorkAntenna);
                            m_curSetting.btWorkAntenna = btWorkAntenna;
                            break;

                        default:
                            break;
                    }

                    return;
                }
                else
                {
                    strErrorCode = CCommondMethod.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = "未知错误";
            }

            string strLog = strCmd + "失败，失败原因： " + strErrorCode;
            //WriteLog(lrtxtLog, strLog, 1);
        }

        private void RunLoopInventroy()
        {
            m_curInventoryBuffer.bLoopInventory = false;
            //    btRealTimeInventory.Text = "开始盘存";

            //校验盘存是否所有天线均完成
            if (m_curInventoryBuffer.nIndexAntenna < m_curInventoryBuffer.lAntenna.Count - 1 || m_curInventoryBuffer.nCommond == 0)
            {
                if (m_curInventoryBuffer.nCommond == 0)
                {
                    m_curInventoryBuffer.nCommond = 1;

                    if (m_curInventoryBuffer.bLoopInventoryReal)
                    {
                        //m_bLockTab = true;
                        //btnInventory.Enabled = false;
                        //if (m_curInventoryBuffer.bLoopCustomizedSession)//自定义Session和Inventoried Flag 
                        //{
                        //    //reader.CustomizedInventory(m_curSetting.btReadId, m_curInventoryBuffer.btSession, m_curInventoryBuffer.btTarget, m_curInventoryBuffer.btRepeat); 
                        //    reader.CustomizedInventoryV2(m_curSetting.btReadId, m_curInventoryBuffer.CustomizeSessionParameters.ToArray());
                        //}
                        //else //实时盘存
                        //{
                        reader.InventoryReal(m_curSetting.btReadId, m_curInventoryBuffer.btRepeat);

                        //}
                    }
                    else
                    {
                        if (m_curInventoryBuffer.bLoopInventory)
                            reader.Inventory(m_curSetting.btReadId, m_curInventoryBuffer.btRepeat);
                    }
                }
                else
                {
                    m_curInventoryBuffer.nCommond = 0;
                    m_curInventoryBuffer.nIndexAntenna++;

                    byte btWorkAntenna = m_curInventoryBuffer.lAntenna[m_curInventoryBuffer.nIndexAntenna];
                    reader.SetWorkAntenna(m_curSetting.btReadId, btWorkAntenna);
                    m_curSetting.btWorkAntenna = btWorkAntenna;
                }
            }
            else if (m_curSetting.btAntGroup == 0 && m_curInventoryBuffer.hAntenna.Count != 0)
            {
                m_curInventoryBuffer.nIndexAntenna = 0;
                m_curInventoryBuffer.nCommond = 0;
                m_curSetting.btAntGroup = 1;

                List<byte> tmp = new List<byte>();
                tmp.AddRange(m_curInventoryBuffer.lAntenna);
                m_curInventoryBuffer.lAntenna.Clear();
                m_curInventoryBuffer.lAntenna.AddRange(m_curInventoryBuffer.hAntenna);
                m_curInventoryBuffer.hAntenna.Clear();
                m_curInventoryBuffer.hAntenna.AddRange(tmp);

                reader.SetReaderAntGroup(m_curSetting.btReadId, m_curSetting.btAntGroup);

            }

            //校验是否循环盘存
            else if (m_curInventoryBuffer.bLoopInventory)
            {
                m_curInventoryBuffer.nIndexAntenna = 0;
                m_curInventoryBuffer.nCommond = 0;
                if (m_curInventoryBuffer.hAntenna.Count == 0 && m_curSetting.btAntGroup == 1)
                {
                    reader.SetReaderAntGroup(m_curSetting.btReadId, 1);
                    return;
                }

                if (m_curInventoryBuffer.hAntenna.Count == 0)
                {
                    reader.SetReaderAntGroup(m_curSetting.btReadId, 0);
                    return;
                }

                m_curSetting.btAntGroup = 0;


                List<byte> tmp = new List<byte>();
                tmp.AddRange(m_curInventoryBuffer.lAntenna);
                m_curInventoryBuffer.lAntenna.Clear();
                m_curInventoryBuffer.lAntenna.AddRange(m_curInventoryBuffer.hAntenna);
                m_curInventoryBuffer.hAntenna.Clear();
                m_curInventoryBuffer.hAntenna.AddRange(tmp);

                reader.SetReaderAntGroup(m_curSetting.btReadId, m_curSetting.btAntGroup);

            }
        }

        public int Connect(string ip, int port)
        {
            //return 0;
            try
            {
                //处理Tcp连接读写器
                string strException = string.Empty;
                IPAddress ipAddress = IPAddress.Parse(ip);

                int nRet = reader.ConnectServer(ipAddress, port, out strException);
                if (nRet != 0)
                {
                    string strLog = "连接读写器失败，失败原因： " + strException;
                    Logger.Info(strLog);

                    return nRet;
                }
                else
                {
                    string strLog = "连接读写器 " + ip + "@" + port.ToString();
                    Logger.Info(strLog);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return -1;
            }
        }

        /// <summary>
        /// 设置天线
        /// </summary>
        public void SetAnts()
        {
            foreach (string ant in toolCheckerAntList)
            {
                switch (ant)
                {
                    case "1":
                        m_curInventoryBuffer.lAntenna.Add(0x00);
                        break;
                    case "2":
                        m_curInventoryBuffer.lAntenna.Add(0x01);
                        break;
                    case "3":
                        m_curInventoryBuffer.lAntenna.Add(0x02);
                        break;
                    case "4":
                        m_curInventoryBuffer.lAntenna.Add(0x03);
                        break;
                    case "5":
                        m_curInventoryBuffer.lAntenna.Add(0x04);
                        break;
                    case "6":
                        m_curInventoryBuffer.lAntenna.Add(0x05);
                        break;
                    case "7":
                        m_curInventoryBuffer.lAntenna.Add(0x06);
                        break;
                    case "8":
                        m_curInventoryBuffer.lAntenna.Add(0x07);
                        break;

                    case "9":
                        m_curInventoryBuffer.hAntenna.Add(0x00);
                        break;
                    case "10":
                        m_curInventoryBuffer.hAntenna.Add(0x01);
                        break;
                    case "11":
                        m_curInventoryBuffer.hAntenna.Add(0x02);
                        break;
                    case "12":
                        m_curInventoryBuffer.hAntenna.Add(0x03);
                        break;
                    case "13":
                        m_curInventoryBuffer.hAntenna.Add(0x04);
                        break;
                    case "14":
                        m_curInventoryBuffer.hAntenna.Add(0x05);
                        break;
                    case "15":
                        m_curInventoryBuffer.hAntenna.Add(0x06);
                        break;
                    case "16":
                        m_curInventoryBuffer.hAntenna.Add(0x07);
                        break;
                }
            }
        }

        /// <summary>
        /// Init RFID Devides
        /// </summary>
        /// <param name="rfidReadCycle">RFID读取的周期，单位为毫秒</param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns>0：成功</returns>
        public int InitRFIDDevides(string ip, int port, int subCabinetNo, List<string> toolCheckerAntList)
        {
            R2000UartDemo_Load();

            this.subCabinetNo = subCabinetNo;
            this.toolCheckerAntList = toolCheckerAntList;

            //RFID设备初始化，无设备时在此处理加注释
            if (Connect(ip, port) == 0)
            {
            }
            else
            {
                Logger.Info("Connect failure.");
                return 1;
            }
            return 0;
        }

        public void btRealTimeInventory_Click()
        {
            try
            {
                m_curInventoryBuffer.ClearInventoryPar();
                m_curInventoryBuffer.btRepeat = Convert.ToByte("1");
                //m_curInventoryBuffer.bLoopCustomizedSession = false;

                //m_curInventoryBuffer.lAntenna.Add(0x00);
                //m_curInventoryBuffer.hAntenna.Add(0x00);
                SetAnts();

                m_bInventory = true;
                m_curInventoryBuffer.bLoopInventory = true;

                //btRealTimeInventory.Text = "停止盘存";

                m_curInventoryBuffer.bLoopInventoryReal = true;

                m_curInventoryBuffer.ClearInventoryRealResult();

                m_nTotal = 0;

                m_curSetting.btAntGroup = 0;
                m_curSetting.OpType = 7;
                if (m_curInventoryBuffer.lAntenna.Count == 0)
                {
                    m_curSetting.btAntGroup = 1;
                    List<byte> tmp = new List<byte>();
                    tmp.AddRange(m_curInventoryBuffer.lAntenna);
                    m_curInventoryBuffer.lAntenna.Clear();
                    m_curInventoryBuffer.lAntenna.AddRange(m_curInventoryBuffer.hAntenna);
                    m_curInventoryBuffer.hAntenna.Clear();
                    m_curInventoryBuffer.hAntenna.AddRange(tmp);
                }

                int n = reader.SetReaderAntGroup(m_curSetting.btReadId, m_curSetting.btAntGroup);
            }
            catch (System.Exception ex)
            {
                Logger.Error(ex);
            }
        }
        private void ProcessSetWorkAntenna(Reader.MessageTran msgTran)
        {
            int intCurrentAnt = 0;
            intCurrentAnt = m_curSetting.btWorkAntenna + 1 + m_curSetting.btAntGroup * 8;
            string strCmd = "设置工作天线成功,当前工作天线: 天线" + intCurrentAnt.ToString();

            //Logger.Info(strCmd);

            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x10)
                {
                    m_curSetting.btReadId = msgTran.ReadId;
                    //WriteLog(lrtxtLog, strCmd, 0);

                    //校验是否盘存操作
                    if (m_bInventory)
                    {
                        RunLoopInventroy();
                    }
                    return;
                }
                else
                {
                    strErrorCode = CCommondMethod.FormatErrorCode(msgTran.AryData[0]);
                }
            }
            else
            {
                strErrorCode = "未知错误";
            }

            string strLog = strCmd + "失败，失败原因： " + strErrorCode;
            Logger.Info(strLog);

            if (m_bInventory)
            {
                m_curInventoryBuffer.nCommond = 1;
                m_curInventoryBuffer.dtEndInventory = DateTime.Now;
                RunLoopInventroy();
            }
        }

        private void ProcessInventoryReal(Reader.MessageTran msgTran)
        {
            string strCmd = "";
            if (msgTran.Cmd == 0x89)
            {
                strCmd = "实时盘存";
            }
            if (msgTran.Cmd == 0x8B)
            {
                strCmd = "自定义Session和Inventoried Flag盘存";
            }
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = CCommondMethod.FormatErrorCode(msgTran.AryData[0]);
                string strLog = strCmd + "失败，失败原因： " + strErrorCode;
                Logger.Info(strLog);

                m_curInventoryBuffer.dtEndInventory = DateTime.Now;

                RunLoopInventroy();
            }
            else if (msgTran.AryData.Length == 7)
            {
                m_curInventoryBuffer.nReadRate = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                m_curInventoryBuffer.nDataCount = Convert.ToInt32(msgTran.AryData[3]) * 256 * 256 * 256 + Convert.ToInt32(msgTran.AryData[4]) * 256 * 256 + Convert.ToInt32(msgTran.AryData[5]) * 256 + Convert.ToInt32(msgTran.AryData[6]);

                m_curInventoryBuffer.dtEndInventory = DateTime.Now;

                //Logger.Info(strCmd); Test
                RunLoopInventroy();
            }
            else
            {
                m_nTotal++;
                int nLength = msgTran.AryData.Length;

                int nEpcLength = nLength - 4;
                if (m_nSessionPhaseOpened)
                {
                    nEpcLength = nLength - 6;
                }

                //Add inventory list
                string strEPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, nEpcLength);
                string strPC = CCommondMethod.ByteArrayToString(msgTran.AryData, 1, 2);
                string strRSSI = string.Empty;

                if (m_nSessionPhaseOpened)
                {
                    //SetMaxMinRSSI(Convert.ToInt32(msgTran.AryData[nLength - 3] & 0x7F));
                    strRSSI = (msgTran.AryData[nLength - 3] & 0x7F).ToString();
                }
                else
                {
                    //SetMaxMinRSSI(Convert.ToInt32(msgTran.AryData[nLength - 1] & 0x7F));
                    strRSSI = (msgTran.AryData[nLength - 1] & 0x7F).ToString();
                }

                byte btTemp = msgTran.AryData[0];
                byte btAntId = (byte)((btTemp & 0x03) + 1);
                string strPhase = string.Empty;
                if (m_nSessionPhaseOpened)
                {
                    if ((msgTran.AryData[nLength - 3] & 0x80) != 0) btAntId += 4;
                    strPhase = CCommondMethod.ByteArrayToString(msgTran.AryData, nLength - 2, 2);
                }
                else
                {
                    if ((msgTran.AryData[nLength - 1] & 0x80) != 0) btAntId += 4;//ly//RSSI最高位是1,天线号>=4
                }


                btAntId = (byte)(btAntId + m_curSetting.btAntGroup * 8);
                m_curInventoryBuffer.nCurrentAnt = (int)btAntId;
                string strAntId = btAntId.ToString();
                byte btFreq = (byte)(btTemp >> 2);

                //string strFreq = GetFreqString(btFreq);

                //下面写法，为了处理一个异常，DataTable 内部索引已损坏:“5”
                DataView myDV;
                lock (m_curInventoryBuffer.dtTagTable)
                {
                    myDV = new DataView(m_curInventoryBuffer.dtTagTable, string.Format("COLEPC = '{0}'", strEPC),"", DataViewRowState.CurrentRows);
                }

                //DataRow[] drs = m_curInventoryBuffer.dtTagTable.Select(string.Format("COLEPC = '{0}'", strEPC));
                //if (drs.Length == 0)
                if  (myDV ==null||myDV.Count==0)
                {
                    DataRow row1 = m_curInventoryBuffer.dtTagTable.NewRow();
                    row1[0] = strPC;
                    row1[2] = strEPC;
                    row1[4] = strRSSI;
                    row1[5] = "1";
                    //row1[6] = strFreq;
                    row1[7] = "0";
                    row1[8] = "0";
                    row1[9] = "0";
                    row1[10] = "0";
                    row1[11] = "0";
                    row1[12] = "0";
                    row1[13] = "0";
                    row1[14] = "0";
                    row1[15] = "0";
                    row1[16] = "0";
                    row1[17] = "0";
                    row1[18] = "0";
                    row1[19] = "0";
                    row1[20] = "0";
                    row1[21] = "0";
                    row1[22] = "0";
                    row1[23] = strPhase;
                    switch (btAntId)
                    {
                        case 0x01:
                            {
                                row1[7] = "1";
                            }
                            break;
                        case 0x02:
                            {
                                row1[8] = "1";
                            }
                            break;
                        case 0x03:
                            {
                                row1[9] = "1";
                            }
                            break;
                        case 0x04:
                            {
                                row1[10] = "1";
                            }
                            break;
                        case 0x05:
                            {
                                row1[11] = "1";
                            }
                            break;
                        case 0x06:
                            {
                                row1[12] = "1";
                            }
                            break;
                        case 0x07:
                            {
                                row1[13] = "1";
                            }
                            break;
                        case 0x08:
                            {
                                row1[14] = "1";
                            }
                            break;
                        case 0x09:
                            {
                                row1[15] = "1";
                            }
                            break;
                        case 0x0A:
                            {
                                row1[16] = "1";
                            }
                            break;
                        case 0x0B:
                            {
                                row1[17] = "1";
                            }
                            break;
                        case 0x0C:
                            {
                                row1[18] = "1";
                            }
                            break;
                        case 0x0D:
                            {
                                row1[19] = "1";
                            }
                            break;
                        case 0x0E:
                            {
                                row1[20] = "1";
                            }
                            break;
                        case 0x0F:
                            {
                                row1[21] = "1";
                            }
                            break;
                        case 0x10:
                            {
                                row1[22] = "1";
                            }
                            break;
                        default:
                            break;
                    }

                    m_curInventoryBuffer.dtTagTable.Rows.Add(row1);
                    m_curInventoryBuffer.dtTagTable.AcceptChanges();
                }
                /*else
                {
                    foreach (DataRow dr in drs)
                    {
                        dr.BeginEdit();
                        int nTemp = 0;

                        dr[4] = strRSSI;
                        //dr[5] = (Convert.ToInt32(dr[5]) + 1).ToString();
                        nTemp = Convert.ToInt32(dr[5]);
                        dr[5] = (nTemp + 1).ToString();
                        //dr[6] = strFreq;
                        dr[23] = strPhase;
                        switch (btAntId)
                        {
                            case 0x01:
                                {
                                    //dr[7] = (Convert.ToInt32(dr[7]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[7]);
                                    dr[7] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x02:
                                {
                                    //dr[8] = (Convert.ToInt32(dr[8]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[8]);
                                    dr[8] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x03:
                                {
                                    //dr[9] = (Convert.ToInt32(dr[9]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[9]);
                                    dr[9] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x04:
                                {
                                    //dr[10] = (Convert.ToInt32(dr[10]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[10]);
                                    dr[10] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x05:
                                {
                                    //dr[7] = (Convert.ToInt32(dr[7]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[11]);
                                    dr[11] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x06:
                                {
                                    //dr[8] = (Convert.ToInt32(dr[8]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[12]);
                                    dr[12] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x07:
                                {
                                    //dr[9] = (Convert.ToInt32(dr[9]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[13]);
                                    dr[13] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x08:
                                {
                                    //dr[10] = (Convert.ToInt32(dr[10]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[14]);
                                    dr[14] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x09:
                                {
                                    //dr[7] = (Convert.ToInt32(dr[7]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[15]);
                                    dr[15] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x0A:
                                {
                                    //dr[8] = (Convert.ToInt32(dr[8]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[16]);
                                    dr[16] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x0B:
                                {
                                    //dr[9] = (Convert.ToInt32(dr[9]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[17]);
                                    dr[17] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x0C:
                                {
                                    //dr[10] = (Convert.ToInt32(dr[10]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[18]);
                                    dr[18] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x0D:
                                {
                                    //dr[7] = (Convert.ToInt32(dr[7]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[19]);
                                    dr[19] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x0E:
                                {
                                    //dr[8] = (Convert.ToInt32(dr[8]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[20]);
                                    dr[20] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x0F:
                                {
                                    //dr[9] = (Convert.ToInt32(dr[9]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[21]);
                                    dr[21] = (nTemp + 1).ToString();
                                }
                                break;
                            case 0x10:
                                {
                                    //dr[10] = (Convert.ToInt32(dr[10]) + 1).ToString();
                                    nTemp = Convert.ToInt32(dr[22]);
                                    dr[22] = (nTemp + 1).ToString();
                                }
                                break;
                            default:
                                break;
                        }

                        dr.EndEdit();
                    }
                    m_curInventoryBuffer.dtTagTable.AcceptChanges();
                }*/

                m_curInventoryBuffer.dtEndInventory = DateTime.Now;
                //RefreshInventoryReal(0x89);
            }
        }
    }
}

