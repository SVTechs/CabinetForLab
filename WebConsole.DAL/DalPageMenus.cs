using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate.Criterion;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalPageMenus : FlexNhBase<PageMenus>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static PageMenus GetPageMenu(string menuId, out Exception exception)
        {
            return GetItemInfo<PageMenus>("Id", menuId, out exception);
        }

        public static PageMenus GetPageMenuByUrl(string menuUrl, out Exception exception)
        {
            return GetItemInfo<PageMenus>("MenuUrl", menuUrl, out exception);
        }

        public static IList<PageMenus> GetWebMenus(out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>()
            {
                Restrictions.Not(Restrictions.Eq("MenuType", 3))
            };
            List<Order> orderList = new List<Order>
            {
                Order.Asc("TreeLevel"),
                Order.Asc("MenuOrder")
            };
            return SearchItem<PageMenus>(critList, orderList, 0, -1, out exception);
        }

        public static IList<PageMenus> GetAllMenus(out Exception exception)
        {
            List<Order> orderList = new List<Order>
            {
                Order.Asc("TreeLevel"),
                Order.Asc("MenuOrder")
            };
            return SearchItem<PageMenus>(null, orderList, 0, -1, out exception);
        }

        public static int SavePageMenus(PageMenus pageMenu, out Exception exception)
        {
            return SaveItem(pageMenu, out exception);
        }

        public static int AddPageMenu(string menuName, int menuLevel, string menuParent, int menuOrder,
            int menuType, string menuUrl, string menuIcon, int isVisible, string menuDesp, UserInfo userInfo, out Exception exception)
        {
            PageMenus piRecord = new PageMenus
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                MenuName = menuName,
                TreeLevel = menuLevel,
                TreeParent = menuParent,
                MenuOrder = menuOrder,
                MenuType = menuType,
                MenuUrl = menuUrl,
                MenuIcon = menuIcon,
                IsVisible = isVisible,
                MenuDesp = menuDesp
            };
            return SaveItem(piRecord, out exception);
        }

        public static int ModifyPageMenu(string menuId, string menuName, int menuOrder,
            int menuType, string menuUrl, string menuIcon, int isVisible, string menuDesp, UserInfo userInfo, out Exception exception)
        {
            PageMenus idRecord = GetPageMenu(menuId, out exception);
            if (idRecord == null) return 0;
            idRecord.MenuName = menuName;
            idRecord.MenuOrder = menuOrder;
            idRecord.MenuType = menuType;
            idRecord.MenuUrl = menuUrl;
            idRecord.MenuIcon = menuIcon;
            idRecord.IsVisible = isVisible;
            idRecord.MenuDesp = menuDesp;
            return UpdateItem(idRecord, out exception);
        }

        public static int UpdatePageMenu(PageMenus menuInfo, out Exception exception)
        {
            return UpdateItem(menuInfo, out exception);
        }

        public static int DeletePageMenu(string menuId, UserInfo userInfo, out Exception exception)
        {
            exception = null;
            try
            {
                IList<PageMenus> pageMenus = GetAllMenus(out exception);
                IList<PageMenus> delList = new List<PageMenus>();
                Hashtable queueTable = new Hashtable();
                queueTable[menuId] = 1;
                //生成删除ID列表
                for (int i = 0; i < pageMenus.Count; i++)
                {
                    if (pageMenus[i].TreeParent != null && queueTable[pageMenus[i].TreeParent] != null)
                    {
                        queueTable[pageMenus[i].Id] = 1;
                    }
                }
                //生成删除实体列表
                for (int i = 0; i < pageMenus.Count; i++)
                {
                    if (queueTable[pageMenus[i].Id] != null)
                    {
                        delList.Add(pageMenus[i]);
                    }
                }
                List<TaskInfo> taskList = new List<TaskInfo>();
                for (int i = 0; i < delList.Count; i++)
                {
                    taskList.Add(new TaskInfo(OperationType.Delete, delList[i]));
                    if (delList[i].MenuType == 1)
                    {
                        IList<PageFunctions> funcList = DalPageFunctions.GetMenuFunctions(delList[i].Id, out exception);
                        if (exception != null) return -210;
                        for (int j = 0; j < funcList.Count; j++)
                        {
                            taskList.Add(new TaskInfo(OperationType.Delete, funcList[j]));
                        }
                    }
                }
                return ExecBatchTask(taskList, out exception);
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            return -200;
        }
    }
}
