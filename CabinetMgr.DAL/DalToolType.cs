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
    public class DalToolType : FlexNhBase<ToolType>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<ToolType> SearchToolType(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder = DbOrder.ToOrderList(orderList);
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetToolTypeCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static ToolType GetToolType(long id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static ToolType GetToolType(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddToolType(string typeName, DateTime createTime, out Exception exception)
        {
            ToolType itemRecord = new ToolType
            {
                TypeName = typeName,
                CreateTime = createTime,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyToolType(long id, string typeName, DateTime createTime, out Exception exception)
        {
            ToolType itemRecord = GetToolType(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.TypeName = typeName;
            itemRecord.CreateTime = createTime;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveToolType(ToolType toolType, out Exception exception)
        {
            return SaveItem(toolType, out exception);
        }

        public static int UpdateToolType(ToolType toolType, out Exception exception)
        {
            return UpdateItem(toolType, out exception);
        }

        public static int DeleteToolType(long id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }
    }
}
