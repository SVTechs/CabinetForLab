using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WebConsole.DAL;
using Domain.Server.Domain;

namespace WebConsole.BLL
{
    public class BllSysDictInfo
    {
        public static IList<SysDictInfo> SearchSysDictInfo(string dataGroup, int dataStart, int dataCount, out Exception exception)
        {
            return DalSysDictInfo.SearchSysDictInfo(dataGroup, dataStart, dataCount, out exception);
        }

        public static IList<SysDictInfo> SearchSysDictInfoByKey(string dataGroup, string dataKey, string dataSubKey,
            out Exception exception)
        {
            return DalSysDictInfo.SearchSysDictInfoByKey(dataGroup, dataKey, dataSubKey, out exception);
        }

        public static int GetSysDictInfoCount(string dataGroup, out Exception exception)
        {
            return DalSysDictInfo.GetSysDictInfoCount(dataGroup, out exception);
        }

        public static SysDictInfo GetSysDictInfo(long id, out Exception exception)
        {
            return DalSysDictInfo.GetSysDictInfo(id, out exception);
        }

        public static SysDictInfo GetSysDictInfo(string entityName, object entityValue, out Exception exception)
        {
            return DalSysDictInfo.GetSysDictInfo(entityName, entityValue, out exception);
        }

        public static int AddSysDictInfo(string dataGroup, string dataKey, string dataSubKey, string dataId, int dataOrder,
            string dataValue1, string dataValue2, string dataValue3, string dataValue4, string dataValue5, string dataValue6,
            string comment, UserInfo adminInfo, out Exception exception)
        {
            return DalSysDictInfo.AddSysDictInfo(dataGroup, dataKey, dataSubKey, dataId, dataOrder,
                dataValue1, dataValue2, dataValue3, dataValue4, dataValue5, dataValue6, comment, adminInfo, out exception);
        }

        public static int ModifySysDictInfo(long id, string dataKey, string dataSubKey, string dataId, int dataOrder,
            string dataValue1, string dataValue2, string dataValue3, string dataValue4, string dataValue5, string dataValue6,
            string comment, UserInfo adminInfo, out Exception exception)
        {
            return DalSysDictInfo.ModifySysDictInfo(id, dataKey, dataSubKey, dataId, dataOrder,
                dataValue1, dataValue2, dataValue3, dataValue4, dataValue5, dataValue6,
                comment, adminInfo, out exception);
        }

        public static int SaveSysDictInfo(SysDictInfo sysDictInfo, out Exception exception)
        {
            return DalSysDictInfo.SaveSysDictInfo(sysDictInfo, out exception);
        }

        public static int UpdateSysDictInfo(SysDictInfo sysDictInfo, out Exception exception)
        {
            return DalSysDictInfo.UpdateSysDictInfo(sysDictInfo, out exception);
        }

        public static int DeleteSysDictInfo(long id, UserInfo adminInfo, out Exception exception)
        {
            return DalSysDictInfo.DeleteSysDictInfo(id, adminInfo, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalSysDictInfo.ExecSqlQuery(queryCmd, paraList, out exception);
        }
    }
}
