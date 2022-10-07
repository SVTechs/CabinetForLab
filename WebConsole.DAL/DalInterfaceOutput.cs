using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate.Criterion;
using NLog;
using Utilities.DbHelper;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalInterfaceOutput : FlexNhBase<InterfaceOutput>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<InterfaceOutput> SearchInterfaceOutput(int dataStart, int dataCount,
            out Exception exception)
        {
            return SearchItem<InterfaceOutput>(null, null, dataStart, dataCount, out exception);
        }

        public static int GetInterfaceOutputCount(out Exception exception)
        {
            return GetItemCount<InterfaceOutput>(null, out exception);
        }

        public static InterfaceOutput GetInterfaceOutput(long id, out Exception exception)
        {
            return GetItemInfo<InterfaceOutput>("Id", id, out exception);
        }

        public static IList<InterfaceOutput> SearchInterfaceOutput(string roleId, string domainName,
            out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>()
            {
                Restrictions.Eq("RoleId", roleId),
                Restrictions.Eq("DomainName", domainName)
            };
            return SearchItem<InterfaceOutput>(critList, null, 0, -1, out exception);
        }

        public static int AddInterfaceOutput(string roleId, string domainName, string entityName, int displayOrder,
            out Exception exception)
        {
            InterfaceOutput itemRecord = new InterfaceOutput
            {
                RoleId = roleId,
                DomainName = domainName,
                EntityName = entityName,
                DisplayOrder = displayOrder,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyInterfaceOutput(long id, string roleId, string domainName, string entityName,
            int displayOrder, out Exception exception)
        {
            InterfaceOutput itemRecord = GetInterfaceOutput(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.RoleId = roleId;
            itemRecord.DomainName = domainName;
            itemRecord.EntityName = entityName;
            itemRecord.DisplayOrder = displayOrder;
            return UpdateItem(itemRecord, out exception);
        }

        public static int UpdateInterfaceOutput(InterfaceOutput interfaceOutput, out Exception exception)
        {
            return UpdateItem(interfaceOutput, out exception);
        }

        public static int DeleteInterfaceOutput(long id, out Exception exception)
        {
            return DeleteItem<InterfaceOutput>("Id", id, out exception);
        }

        public static int ClearInterfaceOutput(string roleId, string domainName, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>()
            {
                Restrictions.Eq("RoleId", roleId),
                Restrictions.Eq("DomainName", domainName)
            };
            return DeleteItem<InterfaceOutput>(critList, out exception);
        }

        public static int SetInterfaceOutput(string roleId, string domainName, List<string> entityList, out Exception exception)
        {
            IList<InterfaceOutput> existInfo = SearchInterfaceOutput(roleId, domainName, out exception);
            if (exception != null) return -200;
            List<TaskInfo> taskList = new List<TaskInfo>();
            if (SqlDataHelper.IsDataValid(existInfo))
            {
                for (int i = 0; i < existInfo.Count; i++)
                {
                    taskList.Add(new TaskInfo(OperationType.Delete, existInfo[i]));
                }
            }
            for (int i = 0; i < entityList.Count; i++)
            {
                InterfaceOutput itemRecord = new InterfaceOutput
                {
                    RoleId = roleId,
                    DomainName = domainName,
                    EntityName = entityList[i],
                    DisplayOrder = i
                };
                taskList.Add(new TaskInfo(OperationType.Add, itemRecord));
            }
            return ExecBatchTask(taskList, out exception);
        }
    }
}
