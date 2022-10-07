using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using PInteliCabinetSrv;

namespace Hardware.DeviceInterface
{

    public class CabinetSrv
    {
        private static string _portNum;
        private static string _sensorMapping;
        private static string _doorCounts;
        private static string _errorMsg;
        public static CoInteliCabinetSrv Instance = new CoInteliCabinetSrv();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static List<CabinetModule> ModuleList = new List<CabinetModule>();
        private static int[] doorCountArray;
        public static bool _initDone = false;
        private static ManualResetEvent initResetEvent = new ManualResetEvent(false);

        #region InitFunc

        public static void Init()
        {
            bool isSuccess = false;
            try
            {
                bool init = InitCommPort(_portNum, out _errorMsg);
                Logger.Info(_errorMsg);
                if (!init) { CabinetSrvCallback.OnInitDone?.Invoke($"工具柜连接失败{_errorMsg}"); return; }
                Logger.Info("AddModuleDoorCounts");
                AddModuleDoorCounts(_doorCounts);
                Logger.Info("BindEvent");
                BindEvent();
                Logger.Info("boardb_list_resync");
                Instance.boardb_list_resync();
                Thread.Sleep(5000);
                Instance.boardb_list_query();
                initResetEvent.WaitOne();
                foreach (CabinetModule cm in ModuleList)
                {
                    string moduleAddr = cm.ModuleAddr.ToString();
                    foreach (CabinetDoorStatus cds in cm.DoorList)
                    {
                        if (cds.SensorAddr != -1)
                        {
                            Thread.Sleep(200);
                            Logger.Info($"Query{moduleAddr},{cds.SensorAddr}");
                            Instance.boardb_query_weight(Convert.ToSByte(moduleAddr), Convert.ToSByte(cds.SensorAddr));
                        }
                    }
                }
                Thread.Sleep(8000);
                _initDone = true;
                isSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                CabinetSrvCallback.OnInitDone?.Invoke($"工具柜连接失败{ex.Message}");
                return;
            }
            if (isSuccess)
            {
                CabinetSrvCallback.OnInitDone?.Invoke("成功");
            }

        }

        public static void InitDevice(string portNum, string sensorMapping, string doorCounts)
        {
            _portNum = portNum;
            _sensorMapping = sensorMapping;
            _doorCounts = doorCounts;
            Thread initThread = new Thread(Init) { IsBackground = true };
            initThread.Start();
        }

        private static void AddModuleDoorCounts(string doorCounts)
        {
            string[] countArray = doorCounts.Split('|');
            doorCountArray = new int[countArray.Length];
            for (int i = 0; i < doorCountArray.Length; i++)
            {
                if(string.IsNullOrEmpty(countArray[i])) continue;
                int count = int.Parse(countArray[i]);
                doorCountArray[i] = count;
            }
        }

        public static void AddModuleAddress(string _sensorMapping)
        {
            string[] _sensorArray = _sensorMapping.Split('|');
            for (int i = 0; i < _sensorArray.Length; i++)
            {
                string sensorStr = _sensorArray[i];
                if (string.IsNullOrEmpty(sensorStr)) continue;
                string[] sensorProp = sensorStr.Split(',');
                int moduleIdx = int.Parse(sensorProp[0]);
                int doorAddr = int.Parse(sensorProp[1]);
                int sensorAddr = int.Parse(sensorProp[2]);
                string sensorType = sensorProp[3] == "" ? "AutoMinus" : sensorProp[3];
                CabinetModule cm = ModuleList[moduleIdx];
                CabinetDoorStatus cds = cm.DoorList.FirstOrDefault(p => p.DoorAddr == doorAddr);
                cds.SensorAddr = sensorAddr;
                cds.SensorType = sensorType;
            }
        }



        public static void BindEvent()
        {
            Instance.on_boarda_status += BoardStatusReceived;
            Instance.on_boardb_dio16_status += Dio16StatusReceived;
            Instance.on_boardb_dio32_status += Dio32StatusReceived;
            Instance.on_boardb_receive_weight += WeightReceived;
            Instance.on_receive_boardb_list += ListReceived;
            Instance.on_receive_cardno += CardReceived;
        }

        public static void BindModule()
        {
            //Thread bindThread = new Thread(QueryBindModule){IsBackground = true};
            //bindThread.Start();
        }

        public static void AddMapping(string sensorMapping)
        {
            //string[] sensorArray = sensorMapping.Split('|');
            //foreach (string sensor in sensorArray)
            //{
            //    if (string.IsNullOrEmpty(sensor)) continue;
            //    SensorMapping.Add(sensor.Split(',')[0], sensor.Split(',')[1]);
            //}
        }

        //public static void InitWeight()
        //{
        //    Thread bindThread = new Thread(QueryWeight) { IsBackground = true };
        //    bindThread.Start();
        //}

        //private static void QueryWeight()
        //{
        //    initResetEvent.WaitOne();
        //    foreach (CabinetModule cm in ModuleList)
        //    {
        //        string moduleAddr = cm.ModuleAddr.ToString();
        //        foreach (CabinetDoorStatus cds in cm.DoorList)
        //        {
        //            if (cds.SensorAddr != -1)
        //            {
        //                Instance.boardb_query_weight(Convert.ToSByte(moduleAddr), Convert.ToSByte(cds.SensorAddr));
        //            }
        //        }
        //    }
        //    Thread.Sleep(10000);
        //    _initDone = true;
        //}
        
        //private static void QueryBindModule()
        //{

        //}

        #endregion

        public static void OpenDoor(int moduleAddr, int doorNum)
        {
            CabinetModule module = ModuleList.FirstOrDefault(p => p.ModuleAddr == moduleAddr);
            int doorCount = module.DoorList.Count;
            string bin = (1.ToString().PadRight(doorNum+1, '0')).PadLeft(doorCount, '0');
            uint value = Convert.ToUInt32(bin,2);
            Instance.boardb_dio32_seton(Convert.ToSByte(moduleAddr), value);
        }

        public static List<CabinetModule> GetModuleStatus()
        {
            return ModuleList;
        }

        #region InterfaceFunc

        public static bool InitCommPort(string portNum, out string errorMsg)
        {
            return Instance.init_commport("COM"+portNum, out errorMsg);
        }

        public static void LockerSetOff()
        {
            Instance.boarda_locker_setoff();
        }

        public static void LockerSetOn()
        {
            Instance.boarda_locker_seton();
        }

        public static void QueryStatus()
        {
            Instance.boarda_query_status();
        }

        public static void TripleLampSetOff(sbyte lamp)
        {
            Instance.boarda_triplelamp_setoff(lamp);
        }

        public static void TripleLampSetOn(sbyte lamp)
        {
            Instance.boarda_triplelamp_seton(lamp);
        }

        public static void Dio16Query(sbyte boardAddr)
        {
            Instance.boardb_dio16_query(boardAddr);
        }

        public static void Dio16SetOff(sbyte boardAddr, uint value)
        {
            Instance.boardb_dio16_setoff(boardAddr, value);
        }

        public static void Dio16SetOn(sbyte boardAddr, uint value)
        {
            Instance.boardb_dio16_seton(boardAddr, value);
        }

        public static void Dio32Query(sbyte boardAddr)
        {
            Instance.boardb_dio32_query(boardAddr);
        }

        public static void Dio32SetOff(sbyte boardAddr, uint value)
        {
            Instance.boardb_dio32_setoff(boardAddr, value);
        }

        public static void Dio32SetOn(sbyte boardAddr, uint value)
        {
            Instance.boardb_dio32_seton(boardAddr, value);
        }

        public static void LedArraySetColor(sbyte boardAddr, sbyte led_start_idx, sbyte led_count, string ledColor)
        {
            Instance.boardb_ledarray_setcolor(boardAddr, led_start_idx, led_count, ledColor);
        }

        public static void LedArraySetMode(sbyte boardAddr, sbyte value)
        {
            Instance.boardb_ledarray_setmode(boardAddr, value);
        }

        public static void ListResync()
        {
            Instance.boardb_list_resync();
        }

        public static void ListQuery()
        {
            Instance.boardb_list_query();
        }

        public static void WeightQuery(sbyte boardAddr, sbyte sensorAddr)
        {
            Instance.boardb_query_weight(boardAddr, sensorAddr);

        }


        #endregion

        #region EventHandlers

        private static string PatchBin(string origin)
        {
            while (origin.Length < 8) origin = "0" + origin;
            StringBuilder strBuild = new StringBuilder();
            for (int i = origin.Length - 1; i >= 0; i--)
            {
                strBuild.Append(origin[i]);
            }
            origin = strBuild.ToString();
            return origin;
        }

        public static void BoardStatusReceived(int locker_status, int triplelamp_status)
        {
            CabinetSrvCallback.OnBoardStatusReceived?.Invoke(locker_status, triplelamp_status);
        }

        public static void Dio16StatusReceived(sbyte board_addr, int din_status, int dout_status)
        {
            CabinetSrvCallback.OnBoardDio16StatusReceived?.Invoke(board_addr, din_status, dout_status);
        }

        public static void Dio32StatusReceived(sbyte board_addr, int din_status, int dout_status)
        {
            int moduleAddr = int.Parse(board_addr.ToString());
            CabinetModule cm = ModuleList.FirstOrDefault(p => p.ModuleAddr == moduleAddr);
            if (cm == null) return;
            byte[] inBytes = BitConverter.GetBytes(din_status);
            byte[] outBytes = BitConverter.GetBytes(dout_status);
            string ds = "";
            foreach (Byte bt in inBytes)
            {
                ds += PatchBin(Convert.ToString(bt, 2));
            }
            if (cm.DoorList.Count == 0) return;
            for (int i = 0; i < cm.DoorList.Count; i++)
            {
                bool doorClosed = ds[i] == '0';
                CabinetDoorStatus status = cm.DoorList.FirstOrDefault(p => p.DoorAddr == i);
                if (status == null) continue;
                if (status.DoorClosed != doorClosed && doorClosed == true)
                {
                    Logger.Info($"Door{i} CLosed");
                    int moduleIndex = ModuleList.FindIndex(p => p.ModuleAddr == board_addr);
                    CabinetSrvCallback.DoorClosed?.Invoke(moduleIndex, i);
                    string sensorAddr = status.SensorAddr.ToString();
                    if (!string.IsNullOrEmpty(sensorAddr)) Instance.boardb_query_weight(board_addr, Convert.ToSByte(sensorAddr));
                }
                status.DoorClosed = doorClosed;
            }
            Logger.Info(ds);
            CabinetSrvCallback.OnBoardDio32StatusReceived?.Invoke(board_addr, din_status, dout_status);
        }

        public static void WeightReceived(sbyte board_addr, sbyte sensor_addr, int value)
        {
            CabinetModule cm = ModuleList.FirstOrDefault(p => p.ModuleAddr == board_addr);
            CabinetDoorStatus cds = cm.DoorList.FirstOrDefault(p => p.SensorAddr == Convert.ToInt32(sensor_addr));
            Logger.Info(board_addr + "|" + sensor_addr + "|" + value + "|" + cds.Weight);
            //CabinetDoorStatus status = cm.DoorList.FirstOrDefault(p => p.SensorAddr == sensor_addr);
            if (cds.Weight != value)
            {
                int moduleIndex = ModuleList.FindIndex(p => p.ModuleAddr == board_addr);
                int loseWeight = value - cds.Weight;
                cds.Weight = value;
                CabinetSrvCallback.WeightChanged?.Invoke(moduleIndex, cds.DoorAddr, loseWeight, value);
            }
            CabinetSrvCallback.OnBoardWeightReceived?.Invoke(board_addr, sensor_addr, value);
        }

        public static void ListReceived(ValueList list)
        {
            int moduleCount = list.count;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < moduleCount; i++)
            {
                CabinetModule cm = new CabinetModule(){ModuleAddr = list.Items[i],DoorList = new List<CabinetDoorStatus>()};
                int doorCount = doorCountArray[i];
                for (int j = 0; j < doorCount; j++)
                {
                    cm.DoorList.Add(new CabinetDoorStatus(){DoorClosed = true, DoorAddr = j, ModuleAddr = list.Items[i]});
                }
                ModuleList.Add(cm);
                sb.Append(list.Items[i] + ",");
            }
            AddModuleAddress(_sensorMapping);
            for (int i = 0; i< moduleCount; i++)
            {
                Instance.boardb_dio32_query(Convert.ToSByte(list.Items[i]));
            }
            CabinetSrvCallback.OnListReceived?.Invoke(list);
            initResetEvent.Set();
        }

        public static void CardReceived(sbyte card_type, int card_num)
        {
            CabinetSrvCallback.OnCardReceived?.Invoke(card_type, card_num);
        }

        #endregion

    }

    public class CabinetDoorStatus
    {
        public int ModuleAddr;
        public int SensorAddr;
        public int DoorAddr;
        public bool DoorClosed;
        public int Weight;
        public string SensorType;


        public CabinetDoorStatus()
        {
            Weight = -1;
            SensorAddr = -1;
        }
    }

    public class CabinetModule
    {
        public int ModuleAddr;
        public List<CabinetDoorStatus> DoorList;


        public CabinetModule()
        {
        }
    }

}
