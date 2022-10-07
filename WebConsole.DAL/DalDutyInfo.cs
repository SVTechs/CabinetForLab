using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Criterion;
using NLog;
using Utilities.Data;
using Utilities.DbHelper;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalDutyInfo : FlexNhBase<DutyInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static int GetDutyCount(out Exception exception)
        {
            return GetItemCount<DutyInfo>(null, out exception);
        }

        public static IList<DutyInfo> SearchDutyInfo(out Exception exception)
        {
            List<Order> orderList = new List<Order>
            {
                Order.Asc("TreeLevel"),
                Order.Asc("DutyOrder")
            };
            return SearchItem<DutyInfo>(null, orderList, 0, -1, out exception);
        }

        public static IList<DutyInfo> SearchDutyInfoForComp(string[] departIds, out Exception exception)
        {
            exception = null;
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(DutyInfo))
                        .Add(Restrictions.In("Id", departIds))
                        .AddOrder(Order.Asc("TreeLevel"));
                    IList<DutyInfo> resultList = pQuery.List<DutyInfo>();
                    if (!SqlDataHelper.IsDataValid(resultList))
                    {
                        return null;
                    }
                    if (resultList[0].TreeLevel == 0)
                    {
                        return resultList;
                    }
                    DutyInfo treeTop = GetTopDuty(resultList[0].Id, out exception);
                    IList<DutyInfo> newList = new List<DutyInfo>();
                    newList.Add(treeTop);
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        newList.Add(resultList[i]);
                    }
                    return newList;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                logger.Error(ex);
            }
            return null;
        }

        public static DutyInfo GetTopDuty(string deptId, out Exception exception)
        {
            exception = null;
            try
            {
                IList<DutyInfo> deptList = SearchDutyInfo(out exception);
                if (!SqlDataHelper.IsDataValid(deptList)) return null;
                Hashtable parentTable = new Hashtable();
                for (int i = 0; i < deptList.Count; i++)
                {
                    parentTable[deptList[i].Id] = deptList[i].TreeParent;
                }
                while (parentTable[deptId] != null && !parentTable[deptId].ToString().StartsWith("root"))
                {
                    deptId = (string)parentTable[deptId];
                }
                return GetDutyInfo(deptId, out exception);
            }
            catch (Exception ex)
            {
                exception = ex;
                logger.Error(ex);
            }
            return null;
        }

        public static IList<DutyInfo> SearchChildDutyEx(string departId)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(DutyInfo))
                        .AddOrder(Order.Asc("TreeLevel"));
                    IList<DutyInfo> departList = pQuery.List<DutyInfo>();
                    if (SqlDataHelper.IsDataValid(departList))
                    {
                        Hashtable chainTable = new Hashtable();
                        IList<DutyInfo> outputList = new List<DutyInfo>();
                        for (int i = 0; i < departList.Count; i++)
                        {
                            if (departList[i].TreeParent != null && chainTable[departList[i].TreeParent] != null || 
                                departList[i].Id == departId || departList[i].TreeParent == departId)
                            {
                                chainTable[departList[i].Id] = 1;
                                outputList.Add(departList[i]);
                            }
                        }
                        return outputList;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return null;
        }

        public static DutyInfo GetDutyInfo(string id, out Exception exception)
        {
            return GetItemInfo<DutyInfo>("Id", id, out exception);
        }

        public static int AddDutyInfo(string departName, int departLevel, string departParent,
            int departOrder, string dutyDesp, int isEnabled, UserInfo adminInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            DutyInfo riRecord = new DutyInfo
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                DutyName = departName,
                TreeLevel = departLevel,
                TreeParent = departParent,
                DutyOrder = departOrder,
                DutyDesp = dutyDesp,
                IsEnabled = isEnabled,
                LastChanged = DateTime.Now
            };
            taskList.Add(new TaskInfo(OperationType.Add, riRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateAddEntity(riRecord,
                "职务信息", adminInfo.Id, adminInfo.RealName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }

        public static int ModifyDutyInfo(string departId, string departName, int departOrder,
           string dutyDesp, int isEnabled, UserInfo adminInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            DutyInfo idRecord = GetDutyInfo(departId, out exception);
            if (idRecord == null) return 0;
            var originRecord = idRecord.DeepCopy();
            idRecord.DutyName = departName;
            idRecord.DutyOrder = departOrder;
            idRecord.DutyDesp = dutyDesp;
            idRecord.IsEnabled = isEnabled;
            idRecord.LastChanged = DateTime.Now;
            taskList.Add(new TaskInfo(OperationType.Update, idRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateEditEntity(originRecord,
                idRecord, "职务信息", adminInfo.Id, adminInfo.RealName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }

        public static int DeleteDutyInfo(string id, string operateUser, string operateUserName, out Exception exception)
        {
            try
            {
                IList<DutyInfo> departList = SearchDutyInfo(out exception);
                IList delList = new ArrayList(), queueList = new ArrayList();
                //删除指定部门
                for (int i = 0; i < departList.Count; i++)
                {
                    if (departList[i].Id == id)
                    {
                        delList.Add(departList[i]);
                    }
                    if (departList[i].TreeParent == id)
                    {
                        delList.Add(departList[i]);
                        queueList.Add(departList[i].Id);
                    }
                }
                //删除所有子级关联菜单
                while (queueList.Count > 0)
                {
                    string parentId = (string)queueList[0];
                    for (int i = 0; i < departList.Count; i++)
                    {
                        if (departList[i].TreeParent == parentId)
                        {
                            delList.Add(departList[i]);
                            queueList.Add(departList[i].Id);
                        }
                    }
                    queueList.RemoveAt(0);
                }

                DutyInfo di = GetDutyInfo(id, out exception);
                SysDataHistory historyRecord = DalSysDataHistory.GenerateDelEntity(di,
                    "职务信息", operateUser, operateUserName);
                SaveItem(historyRecord, out exception);

                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        for (int i = 0; i < delList.Count; i++)
                        {
                            DutyInfo idRecord = (DutyInfo)delList[i];
                            session.Delete(idRecord);
                        }
                        transaction.Commit();
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                logger.Error(ex);
            }
            return -200;
        }
    }
}
