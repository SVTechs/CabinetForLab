using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate.Criterion;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalPageFunctions : FlexNhBase<PageFunctions>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<PageFunctions> SearchPageFunctions(out Exception exception)
        {
            List<Order> orderList = new List<Order>
            {
                Order.Asc("FunctionParent"),
                Order.Asc("FunctionMenu"),
                Order.Asc("FunctionOrder")
            };
            return SearchItem<PageFunctions>(null, orderList, 0, -1, out exception);
        }

        public static IList<PageFunctions> SearchGroupFunctions(string funcGroup, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("FunctionParent", funcGroup)
            };
            return SearchItem<PageFunctions>(critList, null, 0, -1, out exception);
        }

        public static PageFunctions GetPageFunctions(string id, out Exception exception)
        {
            return GetItemInfo<PageFunctions>("Id", id, out exception);
        }

        public static int AddPageFunction(string funcName, int funcOrder, string funcMenu, string funcDesp,
            UserInfo userInfo, out Exception exception)
        {
            PageFunctions riRecord = new PageFunctions
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                FunctionName = funcName,
                FunctionOrder = funcOrder,
                FunctionMenu = funcMenu,
                FunctionDesp = funcDesp
            };
            return SaveItem(riRecord, out exception);
        }

        public static int AddSubFunction(string funcName, int funcOrder, string funcParent, string funcDesp,
            UserInfo userInfo, out Exception exception)
        {
            PageFunctions riRecord = new PageFunctions
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                FunctionName = funcName,
                FunctionOrder = funcOrder,
                FunctionParent = funcParent,
                FunctionDesp = funcDesp
            };
            return SaveItem(riRecord, out exception);
        }

        public static int ModifyPageFunction(string funcId, string funcName, int funcOrder, string funcDesp,
            UserInfo userInfo, out Exception exception)
        {
            PageFunctions idRecord = GetPageFunctions(funcId, out exception);
            if (idRecord == null) return 0;
            idRecord.FunctionName = funcName;
            idRecord.FunctionOrder = funcOrder;
            idRecord.FunctionDesp = funcDesp;
            return UpdateItem(idRecord, out exception);
        }

        public static int DeletePageFunctions(string id, UserInfo userInfo, out Exception exception)
        {
            return DeleteItem<PageFunctions>("Id", id, out exception);
        }

        public static IList<PageFunctions> GetMenuFunctions(string menuId, out Exception exception)
        {
            List<PageFunctions> resultList = new List<PageFunctions>();
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("FunctionMenu", menuId)
            };
            IList<PageFunctions> l1Menus = SearchItem<PageFunctions>(critList, null, 0, -1, out exception);
            if (l1Menus == null) return null;
            resultList.AddRange(l1Menus);
            for (int i = 0; i < l1Menus.Count; i++)
            {
                List<AbstractCriterion> subCritList = new List<AbstractCriterion>
                {
                    Restrictions.Eq("FunctionParent", l1Menus[i].Id)
                };
                IList<PageFunctions> subList = SearchItem<PageFunctions>(subCritList, null, 0, -1, out exception);
                resultList.AddRange(subList);
            }
            return resultList;
        }
    }
}
