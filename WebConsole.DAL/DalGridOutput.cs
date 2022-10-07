using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate.Criterion;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalGridOutput : FlexNhBase<GridOutput>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<GridOutput> SearchGridOutput(string funcGroup, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("FuncGroup", funcGroup)
            };
            List<Order> orderList = new List<Order>
            {
                Order.Asc("DisplayOrder")
            };
            return SearchItem<GridOutput>(critList, orderList, 0, -1, out exception);
        }

        public static int GetGridOutputCount(out Exception exception)
        {
            return GetItemCount<GridOutput>(null, out exception);
        }

        public static GridOutput GetGridOutput(long id, out Exception exception)
        {
            return GetItemInfo<GridOutput>("Id", id, out exception);
        }

        public static int AddGridOutput(string funcGroup, string entityName, string entityDisplayName, int displayOrder, out Exception exception)
        {
            GridOutput itemRecord = new GridOutput
            {
                FuncGroup = funcGroup,
                EntityName = entityName,
                EntityDisplayName = entityDisplayName,
                Flex = 1,
                DisplayOrder = displayOrder,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyGridOutput(long id, string funcGroup, string entityName, string entityDisplayName, int displayOrder, out Exception exception)
        {
            GridOutput itemRecord = GetGridOutput(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.FuncGroup = funcGroup;
            itemRecord.EntityName = entityName;
            itemRecord.EntityDisplayName = entityDisplayName;
            itemRecord.DisplayOrder = displayOrder;
            return UpdateItem(itemRecord, out exception);
        }

        public static int UpdateGridOutput(GridOutput gridOutput, out Exception exception)
        {
            return UpdateItem(gridOutput, out exception);
        }

        public static int DeleteGridOutput(long id, out Exception exception)
        {
            return DeleteItem<GridOutput>("Id", id, out exception);
        }

        public static int ClearGridOutput(string funcGroup, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>()
            {
                Restrictions.Eq("FuncGroup", funcGroup)
            };
            return DeleteItem<GridOutput>(critList, out exception);
        }
    }
}
