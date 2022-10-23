using CabinetMgr.BLL;
using Domain.Main.Domain;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Size = System.Drawing.Size;

namespace CabinetMgr.RtVars
{
    public class AppRt
    {
        //public static List<RedisUserInfo> UserList = null;

        public static UserInfo CurUser;

        public static DateTime gUserLoginTime;
        public static DateTime gDoorOpenTime;

        public static IList<LatticeInfo> LatticeList = null;

        public static IList<RoleInfo> RoleList = null;

        public static IList<RoleSettings> RoleSettings = null;

        public static bool IsInit = true;

        public static bool IsFpCollect = false;

        //public static bool IsNeedAlarm = true;

        //public static bool IsAlarmed = false;

        public static VideoCapture VideoCaptureDevice;

        public static bool FpDeviceInit;

        public static Size ScreenSize;

        public static FormLog FormLog;

        public static void ResetUserInfo()
        {
            CurUser = null;
            LatticeList = null;
            RoleList = null;
            RoleSettings = null;
        }
    }
}
