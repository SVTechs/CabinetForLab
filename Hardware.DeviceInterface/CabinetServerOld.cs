using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Json;

namespace Hardware.DeviceInterface
{
    public class CabinetServerOld
    {
        private static int _serverPort;
        private static string _serverIP, _canIP;
        private static bool _initDone = false;
        public static MyServerOld Server;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static string openStr = $"{{\"cmd\":\"ctrl_one\",\"msgid\":\"string\",\"id\":_id,\"nch\":_nch}}";
        private static StringBuilder sbReceived = new StringBuilder();
        private static object strLock = new object();
        private static readonly List<DoorInfo> DoorList = new List<DoorInfo>();
        private static AppSession canSession;

        public static void Init(string serverIP, int serverPort, string canIP)
        {
            _serverPort = serverPort;
            _serverIP = serverIP;
            _canIP = canIP;
            try
            {
                Server = new MyServerOld();
                var serverConfig = new ServerConfig();
                serverConfig.MaxRequestLength = 102400;
                serverConfig.Port = _serverPort;
                serverConfig.Ip = _serverIP;
                if (!Server.Setup(serverConfig))
                {
                    CabinetServerCallback.OnInitDone?.Invoke($"Socket端口占用"); return;
                }
                if (!Server.Start())
                {
                    CabinetServerCallback.OnInitDone?.Invoke($"Socket启动失败"); return;
                }
                BindEvents();
                Thread tParser = new Thread(JsonStrParser) { IsBackground = true };
                tParser.Start();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                CabinetServerCallback.OnInitDone?.Invoke($"Socket监听失败 {ex.Message}");
                return;
            }
        }

        private static void JsonStrParser()
        {
            try
            {
                while (true)
                {
                    lock (strLock)
                    {
                        string receivedStr = sbReceived.ToString();

                        int checkIdx = receivedStr.IndexOf($"check");

                        int sensorIdx = receivedStr.IndexOf($"sensor");

                        if (checkIdx < sensorIdx && checkIdx > 0)
                        {
                            int tmpCIdx = receivedStr.IndexOf($"}}]}}");
                            var strC = receivedStr.Substring(0, tmpCIdx + 3);
                            //CabinetServerCallback.JsonStrParsed?.Invoke(strC);
                            var c = ConvertJson.JsonToObject<CheckJObject>(strC);
                            UpdateCheck(c);
                            sbReceived.Remove(0, tmpCIdx + 3);
                            continue;
                        }

                        if (sensorIdx < checkIdx && sensorIdx > 0)
                        {
                            int tmpSIdx = receivedStr.IndexOf($"}}");
                            var strS = receivedStr.Substring(0, tmpSIdx + 2);
                            //CabinetServerCallback.JsonStrParsed?.Invoke(strS);
                            var s = ConvertJson.JsonToObject<StatusJObject>(strS);
                            UpdateStatus(s);
                            sbReceived.Remove(0, tmpSIdx + 2);
                            continue;
                        }

                    }
                    Thread.Sleep(1000);
                }

            }
            catch (Exception ex)
            {

            }
        }

        public static IList<DoorInfo> GetDoorList()
        {
            return DoorList;
        }

        private static void UpdateCheck(CheckJObject c)
        {
            if (_initDone) return;
            foreach (CheckChild child in c.ChildList)
            {
                var id = child.Id;
                for (int i = 1; i <= child.Nch; i++)
                {
                    DoorList.Add(new DoorInfo() { Id = id, Nch = i, IsClosed = false });
                }
            }
            _initDone = true;
            CabinetServerCallback.OnInitDone?.Invoke("成功");
        }

        private static void UpdateStatus(StatusJObject s)
        {
            if (!_initDone) return;
            bool _isChanged = false;
            //var canControl = controllers.FirstOrDefault(x => x.Id == s.Id);
            foreach (JProperty property in s.ChildList as JToken)
            {
                int doorIdx = int.Parse(property.Name.Replace("bit", ""));
                var door = DoorList.FirstOrDefault(x => x.Id == s.Id && x.Nch == doorIdx);
                if (door == null) continue;
                var currentDoorState = (int)property.Value == 1;
                if (door.IsClosed != currentDoorState) CabinetServerCallback.DoorStatusChange?.Invoke(s.Id, doorIdx);
                door.IsClosed = currentDoorState;
            }
        }

        private static void BindEvents()
        {
            Server.NewSessionConnected += appServer_NewSessionConnected;
            Server.NewRequestReceived += appServer_NewRequestReceived;
            Server.SessionClosed += appServer_SessionClosed;
        }

        private static void appServer_NewSessionConnected(AppSession session)
        {
            if (session.RemoteEndPoint.Address.ToString() == _canIP) canSession = session;
            CabinetServerCallback.NewSessionConnected?.Invoke(session);
        }

        private static void appServer_NewRequestReceived(AppSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            if(session == canSession)
            {
                string receivedStr = requestInfo.Key;
                lock (strLock)
                {
                    sbReceived.Append(receivedStr + $"}}");
                }
            }
            else
            {
                string receivedCmd = requestInfo.Body + "}";
                string cmd = receivedCmd.Substring(receivedCmd.IndexOf('{'));
                CabinetServerCallback.BorrowReturnCmd?.Invoke(session, cmd);
            }
            
        }

        private static void appServer_SessionClosed(AppSession session, CloseReason reason)
        {
            CabinetServerCallback.SessionClosed?.Invoke(session, reason);
        }

        public static void Stop()
        {
            Server?.Stop();
        }

        public static void Send(string sendStr, AppSession session)
        {
            session.Send(sendStr);
        }

        public static void OpenDoors(Dictionary<int, List<int>> openDic)
        {
            foreach (int id in openDic.Keys)
            {
                List<int> doorNch = openDic[id];
                foreach (int nch in doorNch)
                {
                    string cmd = string.Format(openStr, id, nch);
                    Send(cmd, canSession);
                    Thread.Sleep(100);
                }
            }

        }

        public static void OpenDoors(int id, int nch)
        {
            string cmd = openStr.Replace("_id", id.ToString()).Replace("_nch", nch.ToString());
            Send(cmd, canSession);


        }

    }


    public class MyServerOld : AppServer
    {
        public MyServerOld()
            : base(new TerminatorReceiveFilterFactory("}"))
        {

        }
    }



}
