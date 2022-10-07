using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using NHibernate.Criterion;
using WebConsole.DAL.NhUtils;
using Domain.Server.Domain;
using Utilities.DbHelper;
using NLog;

namespace WebConsole.DAL
{
    public class DalSysDataHistory : FlexNhBase<SysDataHistory>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<SysDataHistory> SearchSysDataHistory(string userName, int dataStart, int dataCount, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(userName))
            {
                critList.Add(Restrictions.Like("OperateUserName", userName, MatchMode.Anywhere));
            }
            List<Order> orderList = new List<Order>
            {
                Order.Desc("OperateTime")
            };
            return SearchItem(critList, orderList, dataStart, dataCount, out exception);
        }

        public static int GetSysDataHistoryCount(string userName, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(userName))
            {
                Restrictions.Eq("OperateUserName", userName);
            }
            return GetItemCount(critList, out exception);
        }

        public static SysDataHistory GetSysDataHistory(long id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static SysDataHistory GetSysDataHistory(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static SysDataHistory GenerateAddEntity(object item, string dataType, string operateUser, string operateUserName)
        {
            SysDataHistory itemRecord = new SysDataHistory
            {
                OperateType = "新增信息",
                DataType = dataType,
                OperateDesp = CompareHelper.GetEntityInfo(item),
                OperateUser = operateUser,
                OperateUserName = operateUserName,
                OperateTime = DateTime.Now,
            };
            return itemRecord;
        }

        public static SysDataHistory GenerateEditEntity(object item1, object item2, string dataType, string operateUser, string operateUserName)
        {
            SysDataHistory itemRecord = new SysDataHistory
            {
                OperateType = "修改信息",
                DataType = dataType,
                OperateDesp = CompareHelper.CompareEntity(item1, item2),
                OperateUser = operateUser,
                OperateUserName = operateUserName,
                OperateTime = DateTime.Now,
            };
            return itemRecord;
        }

        public static SysDataHistory GenerateDelEntity(object item, string dataType, string operateUser, string operateUserName)
        {
            SysDataHistory itemRecord = new SysDataHistory
            {
                OperateType = "删除信息",
                DataType = dataType,
                OperateDesp = CompareHelper.GetEntityInfo(item),
                OperateUser = operateUser,
                OperateUserName = operateUserName,
                OperateTime = DateTime.Now,
            };
            return itemRecord;
        }

        public static int SaveSysDataHistory(SysDataHistory sysDataHistory, out Exception exception)
        {
            return SaveItem(sysDataHistory, out exception);
        }

        public static int UpdateSysDataHistory(SysDataHistory sysDataHistory, out Exception exception)
        {
            return UpdateItem(sysDataHistory, out exception);
        }

        public static int DeleteSysDataHistory(long id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }
    }
}
