using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections;
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
    public class CabinetServer
    {
        private static int _serverPort;
        private static string _serverIP, _canIP;
        //private static bool _initDone = false;
        public static MyServer Server;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static string openStr = $"{{\"cmd\":\"ctrl_one\",\"msgid\":\"_msgId\",\"id\":_id,\"nch\":_nch}}";
        private static readonly List<DoorInfo> DoorList = new List<DoorInfo>();
        private static AppSession canSession;
        private static Hashtable ht = new Hashtable();
        private static Queue<string> canQueue = new Queue<string>();


        public static void Init(string serverIP, int serverPort, string canIP)
        {
            _serverPort = serverPort;
            _serverIP = serverIP;
            _canIP = canIP;
            try
            {
                Server = new MyServer();
                var serverConfig = new ServerConfig();
                serverConfig.MaxRequestLength = 102400;
                serverConfig.Port = _serverPort;
                serverConfig.Ip = _serverIP;
                serverConfig.ReceiveBufferSize = 43690;
                if (!Server.Setup(serverConfig))
                {
                    CabinetServerCallback.OnInitDone?.Invoke($"Socket端口占用"); return;
                }
                if (!Server.Start())
                {
                    CabinetServerCallback.OnInitDone?.Invoke($"Socket启动失败"); return;
                }
                BindEvents();
                CabinetServerCallback.MsgReceived?.Invoke($"Server Start");
                Thread tParser = new Thread(StrParser) { IsBackground = true };
                tParser.Start();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                CabinetServerCallback.OnInitDone?.Invoke($"Socket监听失败 {ex.Message}");
                return;
            }
        }

        private static void StrParser()
        {
            while (true)
            {
                try
                {
                    if (canQueue.Count > 100) canQueue.Clear();
                    if (canQueue.Count == 0) continue;
                    string canStr = canQueue.Dequeue();
                    if (string.IsNullOrEmpty(canStr)) continue;
                    StatusJObject s = ConvertJson.JsonToObject<StatusJObject>(canStr);
                    if (!ht.ContainsKey(s.Id)) 
                    {
                        ht.Add(s.Id, canStr);
                        UpdateStatus(s);
                        continue; 
                    }
                    if (ht[s.Id] as string == canStr) continue;
                    ht[s.Id] = canStr;
                    UpdateStatus(s);
                }
                catch(Exception ex)
                {
                    Logger.Error(ex);
                }
            }
        }


        public static IList<DoorInfo> GetDoorList()
        {
            return DoorList;
        }

        private static void UpdateCheck(CheckJObject c)
        {
            //CabinetServerCallback.MsgReceived?.Invoke("UpdateCheck");
            //if (_initDone) return;
            //foreach (CheckChild child in c.ChildList)
            //{
            //    var id = child.Id;
            //    for (int i = 1; i <= child.Nch; i++)
            //    {
            //        DoorList.Add(new DoorInfo() { Id = id, Nch = i, IsClosed = false });
            //    }
            //}
            //_initDone = true;
            //CabinetServerCallback.OnInitDone?.Invoke("成功");
        }

        private static void UpdateStatus(StatusJObject s)
        {
            //if (!_initDone) return;
            try
            {
                foreach (JProperty property in s.ChildList as JToken)
                {
                    int doorIdx = int.Parse(property.Name.Replace("bit", ""));
                    var currentDoorState = (int)property.Value == 1;
                    var door = DoorList.FirstOrDefault(x => x.Id == s.Id && x.Nch == doorIdx);
                    if (door == null)
                    {
                        DoorList.Add(new DoorInfo() { Id = s.Id, Nch = doorIdx, IsClosed = currentDoorState });
                        continue;
                    }
                    if (door.IsClosed != currentDoorState) CabinetServerCallback.DoorStatusChange?.Invoke(s.Id, doorIdx);
                    door.IsClosed = currentDoorState;
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
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
            CabinetServerCallback.MsgReceived?.Invoke($"New Session Incoming {session.RemoteEndPoint.Address}");
            if (session.RemoteEndPoint.Address.ToString() == _canIP)
            {
                canSession = session;
                CabinetServerCallback.MsgReceived?.Invoke($"Can Session Catched");
                CabinetServerCallback.OnInitDone?.Invoke("成功");
            }
            CabinetServerCallback.NewSessionConnected?.Invoke(session);
        }

        private static void appServer_NewRequestReceived(AppSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            if (session.RemoteEndPoint.Address.ToString() == _canIP)
            {
                string receivedStr = requestInfo.Key;


                //int checkIdx = receivedStr.IndexOf($"check");

                int sensorIdx = receivedStr.IndexOf($"sensor");
                if (sensorIdx < 0) return;
                canQueue.Enqueue(receivedStr);
                //if (checkIdx > 0)
                //{
                //    var c = ConvertJson.JsonToObject<CheckJObject>(receivedStr);
                //    UpdateCheck(c);
                //}
                //else if (sensorIdx > 0)
                //{
                //    var s = ConvertJson.JsonToObject<StatusJObject>(receivedStr);
                //    UpdateStatus(s);
                //}
            }
            else
            {
                string receivedCmd = requestInfo.Body;
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
            canSession?.Close();
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
            string cmd = openStr.Replace("_id", id.ToString()).Replace("_msgId",Guid.NewGuid().ToString()).Replace("_nch", nch.ToString());
            Send(cmd, canSession);
        }

    }


    public class MyServer : AppServer
    {
        public MyServer()
            : base(new TerminatorReceiveFilterFactory("\n"))
        {

        }
    }

    public class DoorInfo
    {
        public int Id { get; set; }

        public int Nch { get; set; }

        public bool IsClosed { get; set; }

    }


    #region JsonParseClass

    public class CheckJObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("node")]
        public IList<CheckChild> ChildList { get; set; }
    }

    public class CheckChild
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nch")]
        public int Nch { get; set; }
    }

    public class StatusJObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nch")]
        public JObject ChildList { get; set; }
    }

    #endregion




}
