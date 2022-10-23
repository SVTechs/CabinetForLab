using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware.DeviceInterface
{
    public class CabinetServerCallback
    {
        public delegate void OnInitDoneDelegate(string result);
        public static OnInitDoneDelegate OnInitDone = null;

        public delegate void NewSessionConnectedDelegate(AppSession session);
        public static NewSessionConnectedDelegate NewSessionConnected = null;

        public delegate void NewRequestReceivedDelegate(AppSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo);
        public static NewRequestReceivedDelegate NewRequestReceived = null;

        public delegate void SessionClosedDelegate(AppSession session, CloseReason reason);
        public static SessionClosedDelegate SessionClosed = null;

        public delegate void JsonStrParsedDelegate(string session);
        public static JsonStrParsedDelegate JsonStrParsed = null;

        public delegate void DoorStatusChangeDelegate(int id, int nch);
        public static DoorStatusChangeDelegate DoorStatusChange = null;

        public delegate void BorrowReturnCmdDelegate(AppSession session, string cmd);
        public static BorrowReturnCmdDelegate BorrowReturnCmd = null;
    }
}
