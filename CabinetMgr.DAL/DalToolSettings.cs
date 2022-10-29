using CabinetMgr.DAL.NhUtils;
using Domain.Main.Domain;
using Domain.Main.Types;
using NHibernate.Criterion;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMgr.DAL
{
    public class DalToolSettings : FlexNhBase<ToolSettings>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<ToolSettings> SearchToolSettings(string toolId, int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            criterionList.Add(Restrictions.Eq("ToolId", toolId));
            criterionList.Add(Restrictions.Eq("OwnerType", "Role"));
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetToolSettingsCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static ToolSettings GetToolSettings(string id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static ToolSettings GetToolSettings(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddToolSettings(string ownerType, string ownerId, string toolId, DateTime addTime, out Exception exception)
        {
            ToolSettings itemRecord = new ToolSettings
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                OwnerType = ownerType,
                OwnerId = ownerId,
                ToolId = toolId,
                AddTime = addTime,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyToolSettings(string id, string ownerType, string ownerId, string toolId, DateTime addTime, out Exception exception)
        {
            ToolSettings itemRecord = GetToolSettings(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.OwnerType = ownerType;
            itemRecord.OwnerId = ownerId;
            itemRecord.ToolId = toolId;
            itemRecord.AddTime = addTime;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveToolSettings(ToolSettings toolSettings, out Exception exception)
        {
            return SaveItem(toolSettings, out exception);
        }

        public static int UpdateToolSettings(ToolSettings toolSettings, out Exception exception)
        {
            return UpdateItem(toolSettings, out exception);
        }

        public static int DeleteToolSettings(string id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }

        public static int BatchSaveToolSettings(string toolId, IList<ToolSettings> list, out Exception exception)
        {
            List<TaskInfo> taskList = new List<TaskInfo>();
            IList<ToolSettings> currentList = SearchToolSettings(toolId, 0, -1, null, out exception);
            foreach (ToolSettings toolSettings in currentList)
            {
                taskList.Add(new TaskInfo(OperationType.Delete, toolSettings));
            }
            foreach (ToolSettings info in list)
            {
                taskList.Add(new TaskInfo(OperationType.Add, info));
            }
            return ExecBatchTask(taskList, out exception);
        }

        public static IList<ToolSettings> GetToolSettings(string[] roleAry, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            criterionList.Add(Restrictions.In("OwnerId", roleAry));
            criterionList.Add(Restrictions.Eq("OwnerType", "Role"));
            return SearchItem(criterionList, null, 0, -1, out exception);
        }
    }
}
