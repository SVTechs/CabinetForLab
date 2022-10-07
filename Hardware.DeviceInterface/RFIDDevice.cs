using GDotnet.Reader.Api.DAL;
using GDotnet.Reader.Api.Protocol.Gx;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hardware.DeviceInterface
{

    //以后本文件废弃不用

    public class RFIDDevice2
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        GClient clientConn = null;
       
        //public List<string> OldTagList = new List<string>();
        public List<string> NewTagList = new List<string>(); //改成借还操作完成需确认后，用此存读到的RFID标签

        //public List<string> rfidList1 = new List<string>();
        //public List<string> rfidList2 = new List<string>();
        int subCabinetNo; //副柜号
        /// <summary>
        /// RFID读取的周期，单位为毫秒
        /// </summary>
        //private int _rfidReadCycle;
        private string _readerName;
        //private  int _toolCount;

        //Queue<List<string>> rfidListQueue = new Queue<List<string>>();

        /// <summary>
        /// 工具状态列表
        /// </summary>
        //public CabinetCallback.ToolStatus[] ToolStatusList = new CabinetCallback.ToolStatus[256];

        private int Connect(string readerName)
        {
            eConnectionAttemptEventStatusType status;
            clientConn = new GClient();
            if (clientConn.OpenTcp(readerName, 3000, out status))
            {
                // subscribe to event
                clientConn.OnEncapedTagEpcLog += new delegateEncapedTagEpcLog(OnEncapedTagEpcLog);
                //clientConn.OnEncapedTagEpcOver += new delegateEncapedTagEpcOver(OnEncapedTagEpcOver);
                clientConn.OnTcpDisconnected += new delegateTcpDisconnected(OnTcpDisconnected);

                // stop 
                MsgBaseStop msgBaseStop = new MsgBaseStop();
                clientConn.SendSynMsg(msgBaseStop);
                if (0 == msgBaseStop.RtCode)
                {
                    //Console.WriteLine("Stop successful.");
                    Logger.Info("Stop successful.");
                }
                else
                {
                    //Console.WriteLine("Stop error.");
                    Logger.Info("Stop error. RtCode: " + msgBaseStop.RtCode.ToString());
                    clientConn.Close();
                    clientConn = null;
                    return 2;
                }
            }
            else
            {
                //Console.WriteLine("Connect failure.");
                //Logger.Info("Connect failure. Status: "+status.ToString()); 失败时，status状态看不出来什么，值为OK
                Logger.Info("Connect failure.");
                clientConn.Close();
                clientConn = null;
                return 1;
            }
            return 0;
        }


        /// <summary>
        /// Init RFID Devides
        /// </summary>
        /// <param name="rfidReadCycle">RFID读取的周期，单位为毫秒</param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns>0：成功</returns>
        public int InitRFIDDevides(int rfidReadCycle, string ip, int port, int subCabinetNo, List<string> oldTagList)
        {
            //_toolCount = toolCount;
            //for (int i = 0; i < _toolCount; i++)
            //{
            //    ToolStatusList[i] = new CabinetCallback.ToolStatus();
            //    ToolStatusList[i].Status = toolStatusArray[i];//初始时，从数据库获取工具的在位状态
            //}

            //_rfidReadCycle = rfidReadCycle;
            //OldTagList 初始值从数据库中获取
            //OldTagList = oldTagList;

            //rfidList1.AddRange(oldTagList);

            this.subCabinetNo = subCabinetNo;
            this._readerName = ip + ":" + port;

            eConnectionAttemptEventStatusType status;
            clientConn = new GClient();
            if (clientConn.OpenTcp(_readerName, 3000, out status))
            {
                // subscribe to event
                clientConn.OnEncapedTagEpcLog += new delegateEncapedTagEpcLog(OnEncapedTagEpcLog);
                //clientConn.OnEncapedTagEpcOver += new delegateEncapedTagEpcOver(OnEncapedTagEpcOver);
                clientConn.OnTcpDisconnected += new delegateTcpDisconnected(OnTcpDisconnected);

                // stop 
                MsgBaseStop msgBaseStop = new MsgBaseStop();
                clientConn.SendSynMsg(msgBaseStop);
                if (0 == msgBaseStop.RtCode)
                {
                    //Console.WriteLine("Stop successful.");
                    Logger.Info("Stop successful.");
                }
                else
                {
                    //Console.WriteLine("Stop error.");
                    Logger.Info("Stop error. RtCode: " + msgBaseStop.RtCode.ToString());
                    clientConn.Close();
                    clientConn = null;
                    return 2;
                }

                //Thread t = new Thread(ReadRFID);
                //t.Start();

                //Thread t2 = new Thread(ProcessRFIDList);
                //t2.Start();
            }
            else
            {
                //Console.WriteLine("Connect failure.");
                //Logger.Info("Connect failure. Status: "+status.ToString()); 失败时，status状态看不出来什么，值为OK
                Logger.Info("Connect failure.");
                clientConn.Close();
                clientConn = null;
                return 1;
            }
            return 0;
        }

        //private void ProcessRFIDList()
        //{
        //    while (true)
        //    {
        //        if (rfidListQueue.Count > 0)
        //        {
        //            rfidList2 = new List<string>();
        //            rfidList2.AddRange(rfidListQueue.Dequeue());

        //            ProcessBorrowReturn(rfidList1, rfidList2);
        //            rfidList1.Clear();
        //            rfidList1.AddRange(rfidList2);
        //        }
        //        Thread.Sleep(200);
        //    }
        //}
        /// <summary>
        /// 读RFID到NewTagList
        /// </summary>
        /// <returns>0 正常</returns>
        public int ReadRFID()
        {
            if (clientConn == null)
            {
                int n = Connect(_readerName);
                if (n != 0)
                {
                    return n;
                }
            }

            NewTagList.Clear();

            // 4 antenna read Inventory, EPC & TID
            MsgBaseInventoryEpc msgBaseInventoryEpc = new MsgBaseInventoryEpc();
            msgBaseInventoryEpc.AntennaEnable = (uint)(eAntennaNo._1 | eAntennaNo._2 | eAntennaNo._3 | eAntennaNo._4 | eAntennaNo._5 | eAntennaNo._6 | eAntennaNo._7 | eAntennaNo._8
                | eAntennaNo._9 | eAntennaNo._10 | eAntennaNo._11 | eAntennaNo._12 | eAntennaNo._12 | eAntennaNo._14 | eAntennaNo._15 | eAntennaNo._16);
            msgBaseInventoryEpc.InventoryMode = (byte)eInventoryMode.Inventory;
            msgBaseInventoryEpc.ReadTid = new ParamEpcReadTid();                // tid Param
            msgBaseInventoryEpc.ReadTid.Mode = (byte)eParamTidMode.Auto;
            msgBaseInventoryEpc.ReadTid.Len = 6;

            clientConn.SendSynMsg(msgBaseInventoryEpc);
            if (0 == msgBaseInventoryEpc.RtCode)
            {
                //Console.WriteLine("Inventory epc successful.");
                //Logger.Info("Inventory epc successful.");
            }
            else
            {
                //Console.WriteLine("Inventory epc error.");
                Logger.Info("Inventory epc error. RtCode: " + msgBaseInventoryEpc.RtCode.ToString() + ",RtMsg:" + msgBaseInventoryEpc.RtMsg);
                return 3;
            }
            //Console.WriteLine("Reading....");
            //Console.WriteLine("按任意键停止循环读卡(Enter any character to stop).");
            //Console.ReadKey();

            //Thread.Sleep(_rfidReadCycle);
            return 0;
        }

        public int StopReading()
        {
            MsgBaseStop msgBaseStop = new MsgBaseStop();
            clientConn.SendSynMsg(msgBaseStop);
            if (0 == msgBaseStop.RtCode)
            {
                //Console.WriteLine("Stop successful.");
                Logger.Info("Stop successful.");
                return 0;
            }
            else
            {
                //Console.WriteLine("Stop error.");
                Logger.Info("Stop error. RtCode: " + msgBaseStop.RtCode.ToString());
                return 1;
            }
        }

        public void OnEncapedTagEpcLog(EncapedLogBaseEpcInfo msg)
        {
            // Any blocking inside the callback will affect the normal use of the API !
            // 回调里面的任何阻塞或者效率过低，都会影响API的正常使用 !
            if (null != msg && 0 == msg.logBaseEpcInfo.Result)
            {
                //Console.WriteLine(msg.reader + ":ant[" + msg.logBaseEpcInfo.AntId + "]" + msg.logBaseEpcInfo.Epc + "|" + msg.logBaseEpcInfo.Tid);
                //string s = msg.reader + ":ant[" + msg.logBaseEpcInfo.AntId + "]" + msg.logBaseEpcInfo.Epc + "|" + msg.logBaseEpcInfo.Tid;
                //Logger.Info(s);

                //向RFID标签列表中加标签
                if (NewTagList.IndexOf(msg.logBaseEpcInfo.Tid) < 0) //以后需改成读epc的
                {
                    NewTagList.Add(msg.logBaseEpcInfo.Tid);
                }
            }
        }

        public void OnTcpDisconnected(string readerName)
        {
            Logger.Info("Disconnected:" + readerName);
            if (clientConn != null)
            {
                clientConn.Close();
                clientConn = null;
            }

        }

        //public void OnEncapedTagEpcOver(EncapedLogBaseEpcOver msg)
        //{
        //    List<string> rfidList = new List<string>();
        //    rfidList.AddRange(NewTagList);

        //    rfidListQueue.Enqueue(rfidList);
        //    NewTagList.Clear();

        //    //RFID标签列表中的标签已经确定
        //    //比较OldTagList与TagList确定是借还是还操作
        //    //ProcessBorrowReturn(OldTagList, NewTagList);


        //    ////NewTagList复制到OldTagList
        //    //OldTagList.Clear();
        //    //OldTagList.AddRange(NewTagList);

        //    ////NewTagList标签列表清空
        //    //NewTagList.Clear();


        //    //if (null != msg)
        //    //{
        //    //    //Console.WriteLine("Epc log over.");
        //    //    //Logger.Info("Epc log over.");
        //    //}
        //}

        /// <summary>
        /// 判断借还，并处理
        /// </summary>
        /// <param name="OldTagList"></param>
        /// <param name="NewTagList"></param>
        //public void ProcessBorrowReturn(List<string> OldTagList, List<string> NewTagList)
        //{
        //    //Test
        //    //string sOldRFIDs = "";
        //    //foreach (string oldRFID in OldTagList)
        //    //{
        //    //    sOldRFIDs += oldRFID+",";
        //    //}

        //    //string sNewRFIDs = "";
        //    //foreach (string newRFID in NewTagList)
        //    //{
        //    //    sNewRFIDs += newRFID + ",";
        //    //}
        //    //Logger.Info("\r\n"+"OldRFIDs: "+sOldRFIDs+"\r\n"+"NewRFIDs:"+sNewRFIDs);

        //    foreach (string oldRFID in OldTagList)
        //    {
        //        int index = NewTagList.IndexOf(oldRFID);
        //        if(index<0) //在新列表中不存在，为借操作
        //        {
                    
        //            CabinetCallback.OnToolTaken?.Invoke(oldRFID,subCabinetNo);
        //        }
        //    }

        //    //foreach (string newRFID in NewTagList)
        //    //{
        //    //    int index = OldTagList.IndexOf(newRFID);
        //    //    if (index < 0) //在新旧表中不存在，为还操作
        //    //    {

        //    //        CabinetCallback.OnToolReturn?.Invoke(newRFID, subCabinetNo, NewTagList);
        //    //    }
        //    //}
        //    CabinetCallback.OnToolReturn?.Invoke(subCabinetNo, OldTagList,NewTagList);
        //}

        //public CabinetCallback.ToolStatus[] GetToolStatus()
        //{
        //    return ToolStatusList;
        //}
    }
}
