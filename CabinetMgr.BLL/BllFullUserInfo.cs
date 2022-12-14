using CabinetMgr.DAL;
using Domain.Main.Domain;
using Domain.Main.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Encryption;

namespace CabinetMgr.BLL
{
    public class BllFullUserInfo
    {
        public static IList<FullUserInfo> SearchFullUserInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalFullUserInfo.SearchFullUserInfo(dataStart, dataCount, orderList, out exception);
        }

        public static int SaveFullUserInfo(FullUserInfo userInfo, out Exception exception)
        {
            return DalFullUserInfo.SaveFullUserInfo(userInfo, out exception);
        }

        public static int UpdateFullUserInfo(FullUserInfo userInfo, out Exception exception)
        {
            return DalFullUserInfo.UpdateFullUserInfo(userInfo, out exception);
        }

        public static int DeleteFullUserInfo(string iD, out Exception exception)
        {
            return DalFullUserInfo.DeleteUserInfo(iD, out exception);
        }

        public static FullUserInfo GetFullUserInfoByUserName(string userName, out Exception exception)
        {
            return DalFullUserInfo.GetFullUserInfoByUserName(userName, out exception);
        }

        public static FullUserInfo GetFullUserInfo(string iD, out Exception exception)
        {
            return DalFullUserInfo.GetFullUserInfo(iD, out exception);
        }
    }
}
