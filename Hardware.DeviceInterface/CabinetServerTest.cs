using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Json;

namespace Hardware.DeviceInterface
{
    public class CabinetServerTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static string openStr = $"{{\"cmd\":\"ctrl_one\",\"msgid\":\"string\",\"id\":_id,\"nch\":_nch}}";
        private static readonly List<DoorInfo> DoorList = new List<DoorInfo>();

        private static TcpListener _server;
        private static int _serverPort;
        private static string _serverIP, _canIP;
        private static bool _initDone = false, _debugMode = false;
        private static StreamWriter canWriteStream;
        private static StringBuilder sb = new StringBuilder();
        private static Queue<SocketCmd> cmdQueue = new Queue<SocketCmd>();

        public static void Init(string serverIP, int serverPort, string canIP, bool debugMode = false)
        {
            _serverPort = serverPort;
            _serverIP = serverIP;
            _canIP = canIP;
            _debugMode = debugMode;
            try
            {
                _server = new TcpListener(IPAddress.Parse(_serverIP), _serverPort);
                _server.Start();
                _initDone = true;
                LoopClients();
                //CabinetServerCallback.MsgReceived?.Invoke($"ServerStart");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                //CabinetServerCallback.OnInitDone?.Invoke($"Socket监听失败 {ex.Message}");
                return;
            }
        }

        public static void LoopClients()
        {
            while (_initDone)
            {
                //CabinetServerCallback.MsgReceived?.Invoke($"StartListening");
                Logger.Info($"StartListening");
                TcpClient newClient = _server.AcceptTcpClient();
                //if ((newClient.Client.RemoteEndPoint as IPEndPoint).Address.ToString() == _canIP)
                //{
                //    canClient = newClient;
                //    CabinetServerCallback.MsgReceived?.Invoke($"Can Session Catched");
                CabinetServerCallback.OnInitDone?.Invoke("成功");
                //}
                //CabinetServerCallback.MsgReceived?.Invoke("NewClient:" + newClient.Client.RemoteEndPoint);
                Logger.Info("NewClient:" + newClient.Client.RemoteEndPoint);
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public static void HandleClient(object obj)
        {
            try
            {
                TcpClient client = (TcpClient)obj;
                StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
                if ((client.Client.RemoteEndPoint as IPEndPoint).Address.ToString() == _canIP)
                {
                    canWriteStream = new StreamWriter(client.GetStream(), Encoding.ASCII);
                }
                Boolean bClientConnected = true;
                String sData = null;

                while (bClientConnected)
                {
                    //if (_debugMode) CabinetServerCallback.MsgReceived?.Invoke("CanValue");
                    char[] data = new char[256];
                    int length = sReader.Read(data, 0, 256);
                    //sb.Append(data, 0, data.Length);
                    Logger.Info(new string(data));
                    //sb.Clear();
                }


                //if (client == canClient)
                //{
                //    while (bClientConnected)
                //    {
                //        //if (_debugMode) CabinetServerCallback.MsgReceived?.Invoke("CanValue");
                //        char[] data = new char[256];
                //        int length = sReader.Read(data, 0, 256);
                //        sb.Append(data, 0, data.Length);
                //        CabinetServerCallback.MsgReceived?.Invoke(sb.ToString());
                //        string receivedStr = sb.ToString();
                //        int endIdx = receivedStr.IndexOf("\n");
                //        if (endIdx < 0) continue;
                //        string currentStr = receivedStr.Substring(0, endIdx);
                //        CabinetServerCallback.MsgReceived?.Invoke(currentStr);
                //        int checkIdx = currentStr.IndexOf($"check");
                //        int sensorIdx = currentStr.IndexOf($"sensor");
                //        if (checkIdx > 0)
                //        {
                //            var c = ConvertJson.JsonToObject<CheckJObject>(receivedStr);
                //            UpdateCheck(c);
                //        }
                //        else if (sensorIdx > 0)
                //        {
                //            var s = ConvertJson.JsonToObject<StatusJObject>(receivedStr);
                //            UpdateStatus(s);
                //        }
                //        sb.Remove(0, endIdx);
                //    }
                //}
                //else
                //{
                //    while (bClientConnected)
                //    {
                //        if(_debugMode) CabinetServerCallback.MsgReceived?.Invoke("OtherValue");
                //        sData = sReader.ReadLine();
                //        if(sData.IndexOf("{") < 0)
                //        {
                //            if (_debugMode) CabinetServerCallback.MsgReceived?.Invoke("ErrorValue");
                //            return;
                //        }
                //        string cmd = sData.Substring(sData.IndexOf('{'));
                //        CabinetServerCallback.MsgReceived?.Invoke(cmd);
                //        if (_debugMode) Logger.Info(cmd);
                //        CabinetServerCallback.BorrowReturnCmd?.Invoke(cmd);
                //    }
                //}

            }

            catch(Exception ex)
            {
                Logger.Error(ex);
            }
         
        }

        public static void HandleSocketCmd()
        {
            while (true)
            {
                if (!_initDone) continue;
                if (cmdQueue.Count == 0) continue;

                SocketCmd sc = cmdQueue.Dequeue();

                if(sc.Ip == _canIP)
                {

                }
                else
                {

                }



            }
            
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

        public static void OpenDoors(int id, int nch)
        {
            char[] cmd = openStr.Replace("_id", id.ToString()).Replace("_nch", nch.ToString()).ToCharArray();
            canWriteStream.Write(cmd, 0, cmd.Length);
            canWriteStream.Flush();
        }

        public static List<DoorInfo> GetDoorList()
        {
            return DoorList;
        }

        public static void Stop()
        {
            _server?.Stop();
        }
    }

    public class DoorInfo
    {
        public int Id { get; set; }

        public int Nch { get; set; }

        public bool IsClosed { get; set; }

    }

    public class SocketCmd
    {
        public string Ip { get; set; }

        public string CmdStr { get; set; }
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
