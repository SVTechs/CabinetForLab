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

namespace CabinetMgr.BLL
{
    public class BllInfo
    {
        public static IList<Info> SearchInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalInfo.SearchInfo(dataStart, dataCount, orderList, out exception);
        }

        public static int GetInfoCount(out Exception exception)
        {
            return DalInfo.GetInfoCount(out exception);
        }

        public static Info GetInfo(string id, out Exception exception)
        {
            return DalInfo.GetInfo(id, out exception);
        }

        public static Info GetInfo(string entityName, object entityValue, out Exception exception)
        {
            return DalInfo.GetInfo(entityName, entityValue, out exception);
        }

        public static int AddInfo(string infoContent, int infoType, int isTop, DateTime createTime, out Exception exception)
        {
            return DalInfo.AddInfo(infoContent, infoType, isTop, createTime, out exception);
        }

        public static int ModifyInfo(string id, string infoContent, int infoType, int isTop, DateTime createTime, out Exception exception)
        {
            return DalInfo.ModifyInfo(id, infoContent, infoType, isTop, createTime, out exception);
        }

        public static int SaveInfo(Info info, out Exception exception)
        {
            return DalInfo.SaveInfo(info, out exception);
        }

        public static int UpdateInfo(Info info, out Exception exception)
        {
            return DalInfo.UpdateInfo(info, out exception);
        }

        public static int DeleteInfo(string id, out Exception exception)
        {
            return DalInfo.DeleteInfo(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalInfo.ExecSqlQuery(queryCmd, paraList, out exception);
        }
    }
}
