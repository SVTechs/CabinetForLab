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
    public class DalDepartInfo : FlexNhBase<DepartInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static int GetDepartCount(out Exception exception)
        {
            return GetItemCount<DepartInfo>(null, out exception);
        }

        public static IList<DepartInfo> SearchDepartInfo(out Exception exception)
        {
            List<Order> orderList = new List<Order>
            {
                Order.Asc("TreeLevel"),
                Order.Asc("DepartOrder")
            };
            return SearchItem<DepartInfo>(null, orderList, 0, -1, out exception);
        }

        public static IList<DepartInfo> SearchDepartInfoForComp(string[] departIds, out Exception exception)
        {
            exception = null;
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(DepartInfo))
                        .Add(Restrictions.In("Id", departIds))
                        .AddOrder(Order.Asc("TreeLevel"));
                    IList<DepartInfo> resultList = pQuery.List<DepartInfo>();
                    if (!SqlDataHelper.IsDataValid(resultList))
                    {
                        return null;
                    }
                    if (resultList[0].TreeLevel == 0)
                    {
                        return resultList;
                    }
                    DepartInfo treeTop = GetTopDepart(resultList[0].Id, out exception);
                    IList<DepartInfo> newList = new List<DepartInfo>();
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

        public static DepartInfo GetTopDepart(string deptId, out Exception exception)
        {
            exception = null;
            try
            {
                IList<DepartInfo> deptList = SearchDepartInfo(out exception);
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
                return GetDepartInfo(deptId, out exception);
            }
            catch (Exception ex)
            {
                exception = ex;
                logger.Error(ex);
            }
            return null;
        }

        public static IList<DepartInfo> SearchChildDepartEx(string departId)
        {
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    ICriteria pQuery = session.CreateCriteria(typeof(DepartInfo))
                        .AddOrder(Order.Asc("TreeLevel"));
                    IList<DepartInfo> departList = pQuery.List<DepartInfo>();
                    if (SqlDataHelper.IsDataValid(departList))
                    {
                        Hashtable chainTable = new Hashtable();
                        IList<DepartInfo> outputList = new List<DepartInfo>();
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

        public static DepartInfo GetDepartInfo(string id, out Exception exception)
        {
            return GetItemInfo<DepartInfo>("Id", id, out exception);
        }

        public static int AddDepartInfo(string departName, int departLevel, string departParent,
            int departOrder, int isEnabled, string departDesp, UserInfo adminInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            DepartInfo riRecord = new DepartInfo
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                DepartName = departName,
                TreeLevel = departLevel,
                TreeParent = departParent,
                DepartOrder = departOrder,
                IsEnabled = isEnabled,
                DepartDesp = departDesp,
                LastChanged = DateTime.Now
            };
            taskList.Add(new TaskInfo(OperationType.Add, riRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateAddEntity(riRecord,
                "部门信息", adminInfo.Id, adminInfo.RealName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }

        public static int ModifyDepartInfo(string departId, string departName, int departOrder, int isEnabled, string departDesp,
            UserInfo adminInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            DepartInfo idRecord = GetDepartInfo(departId, out exception);
            if (idRecord == null) return 0;
            var originRecord = idRecord.DeepCopy();
            idRecord.DepartName = departName;
            idRecord.DepartOrder = departOrder;
            idRecord.DepartDesp = departDesp;
            idRecord.IsEnabled = isEnabled;
            idRecord.LastChanged = DateTime.Now;
            taskList.Add(new TaskInfo(OperationType.Update, idRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateEditEntity(originRecord,
                idRecord, "部门信息", adminInfo.Id, adminInfo.RealName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }

        public static int DeleteDepartInfo(string id, UserInfo adminInfo, out Exception exception)
        {
            try
            {
                IList<DepartInfo> departList = SearchDepartInfo(out exception);
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

                DepartInfo di = GetDepartInfo(id, out exception);
                SysDataHistory historyRecord = DalSysDataHistory.GenerateDelEntity(di,
                    "部门信息", adminInfo.Id, adminInfo.RealName);
                SaveItem(historyRecord, out exception);

                var sessionFactory = NhControl.CreateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        for (int i = 0; i < delList.Count; i++)
                        {
                            DepartInfo idRecord = (DepartInfo)delList[i];
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
