using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PInteliCabinetSrv;

namespace Hardware.DeviceInterface
{
    public class CabinetSrvCallback
    {
        public delegate void OnBoardStatusReceivedDelegate(int lockStatus, int lampStatus);
        public static OnBoardStatusReceivedDelegate OnBoardStatusReceived = null;

        public delegate void OnBoardDio16StatusReceivedDelegate(sbyte boardAddr, int din, int dout);
        public static OnBoardDio16StatusReceivedDelegate OnBoardDio16StatusReceived = null;

        public delegate void OnBoardDio32StatusReceivedDelegate(sbyte boardAddr, int din, int dout);
        public static OnBoardDio32StatusReceivedDelegate OnBoardDio32StatusReceived = null;

        public delegate void OnBoardWeightReceivedDelegate(sbyte boardAddr, sbyte sensorAddr, int value);
        public static OnBoardWeightReceivedDelegate OnBoardWeightReceived = null;

        public delegate void OnListReceivedDelegate(ValueList list);
        public static OnListReceivedDelegate OnListReceived = null;

        public delegate void OnCardReceivedDelegate(sbyte card_type, int card_num);
        public static OnCardReceivedDelegate OnCardReceived = null;

        public delegate void DoorClosedDelegate(int moduleOrder, int doorNum);
        public static DoorClosedDelegate DoorClosed = null;

        public delegate void WeightChangedDelegate(int moduleOrder, int doorNum, int loseWeight, int weight);
        public static WeightChangedDelegate WeightChanged = null;

        public delegate void OnInitDoneDelegate(string result);
        public static OnInitDoneDelegate OnInitDone = null;

    }
}
