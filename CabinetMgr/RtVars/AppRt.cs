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

        private static UserInfo curInfo = null;

        public static UserInfo CurUser
        {
            get { return curInfo; }
            set
            {
                curInfo = value;
                if (curInfo != null)
                {

                    //LatticeList = BllCaPageMenus.GetCabinet(curInfo.ID);
                    IList<RoleSettings> roleList = BllRoleSettings.GetUserRoleSettings(curInfo.ID, out _);
                    string[] roleAry = roleList.Select(x => x.RoleId).ToArray();
                    //RoleList = new List<RoleInfo>();
                    //foreach (RoleSettings rs in roleList)
                    //{
                    //    RoleInfo ri = BllRoleInfo.GetRoleInfo(rs.RoleId, out Exception ex);
                    //    RoleList.Add(ri);
                    //}
                    long[] latticePermissionList = BllLatticePermissionSettings.GetLatticePermissionList(curInfo.ID, roleAry, out Exception ex);
                    LatticeList = BllLatticeInfo.GetLatticeInfoList(latticePermissionList, out _);
                }

                else
                {
                    LatticeList = null;
                    RoleList = null;
                }

            }
        }

        public static DateTime gUserLoginTime;
        public static DateTime gDoorOpenTime;

        /// <summary>
        /// 获取有权限的储物格
        /// </summary>
        public static IList<LatticeInfo> LatticeList = null;

        public static IList<RoleInfo> RoleList = null;

        public static bool IsInit = true;


        /// <summary>
        /// 用户未关门，未退出时是否需要报警
        /// </summary>
        public static bool IsNeedAlarm = true;

        public static bool IsAlarmed = false;

        public static VideoCapture VideoCaptureDevice;

        public static Size ScreenSize;

        public static FormMain fm;

        //public static bool CollectFace = false;

        //public static List<CaPageMenus> stockInList = new List<CaPageMenus>();

        //public static Dictionary<string, string> DestinyList = new Dictionary<string, string>();

        //public static CabinetInfo currentCabinet;
    }
}
