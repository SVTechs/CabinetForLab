using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using FluentNHibernate.Utils;
using NHibernate.Criterion;
using NLog;
using Utilities.Data;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalRoleInfo : FlexNhBase<RoleInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static int GetRoleCount(string roleName, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(roleName))
            {
                criterionList.Add(Restrictions.Like("RoleName", roleName, MatchMode.Anywhere));
            }
            return GetItemCount<RoleInfo>(criterionList, out exception);
        }

        public static IList<RoleInfo> SearchRoleInfo(string roleName, int dataStart, int dataCount, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            if (!string.IsNullOrEmpty(roleName))
            {
                criterionList.Add(Restrictions.Like("RoleName", roleName, MatchMode.Anywhere));
            }
            List<Order> orderList = new List<Order>
            {
                Order.Asc("TreeLevel"),
                Order.Asc("RoleOrder")
            };
            return SearchItem<RoleInfo>(criterionList, orderList, dataStart, dataCount, out exception);
        }

        public static RoleInfo GetRoleInfo(string roleId, out Exception exception)
        {
            return GetItemInfo<RoleInfo>("Id", roleId, out exception);
        }

        public static int AddRoleInfo(string roleName, int roleLevel, string roleParent, int roleOrder, string roleDesp, int isEnabled,
            UserInfo userInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            RoleInfo riRecord = new RoleInfo
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                RoleName = roleName,
                TreeLevel = roleLevel,
                TreeParent = roleParent,
                RoleOrder = roleOrder,
                RoleDesp = roleDesp,
                IsEnabled = isEnabled,
                LastChanged = DateTime.Now
            };
            taskList.Add(new TaskInfo(OperationType.Add, riRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateAddEntity(riRecord,
                "角色信息", userInfo.Id, userInfo.RealName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }

        public static int ModifyRoleInfo(string roleId, string roleName, int roleOrder, string roleDesp, int isEnabled,
            UserInfo userInfo, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            RoleInfo idRecord = GetRoleInfo(roleId, out exception);
            if (idRecord == null) return 0;
            var originRecord = idRecord.DeepCopy();
            idRecord.RoleName = roleName;
            idRecord.RoleOrder = roleOrder;
            idRecord.RoleDesp = roleDesp;
            idRecord.IsEnabled = isEnabled;
            taskList.Add(new TaskInfo(OperationType.Update, idRecord));
            SysDataHistory historyRecord = DalSysDataHistory.GenerateEditEntity(originRecord,
                idRecord, "角色信息", userInfo.Id, userInfo.RealName);
            taskList.Add(new TaskInfo(OperationType.Add, historyRecord));
            return ExecBatchTask(taskList, out exception);
        }

        public static int DeleteRoleInfo(string roleId, string operateUser, string operateUserName, out Exception exception)
        {
            exception = null;
            try
            {
                IList<RoleInfo> roleList = SearchRoleInfo(null, 0, -1, out exception);
                IList<RoleInfo> delList = new List<RoleInfo>();
                Hashtable queueTable = new Hashtable();
                queueTable[roleId] = 1;
                //生成删除ID列表
                for (int i = 0; i < roleList.Count; i++)
                {
                    if (roleList[i].TreeParent != null && queueTable[roleList[i].TreeParent] != null)
                    {
                        queueTable[roleList[i].Id] = 1;
                    }
                }
                //生成删除实体列表
                for (int i = 0; i < roleList.Count; i++)
                {
                    if (queueTable[roleList[i].Id] != null)
                    {
                        delList.Add(roleList[i]);
                    }
                }
                RoleInfo itemRecord = GetRoleInfo(roleId, out exception);
                SysDataHistory historyRecord = DalSysDataHistory.GenerateDelEntity(itemRecord,
                    "角色信息", operateUser, operateUserName);
                SaveItem(historyRecord, out exception);
                return DeleteItem(delList, out exception);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return -200;
        }
    }
}
