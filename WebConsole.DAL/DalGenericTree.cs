using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate.Criterion;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalGenericTree : FlexNhBase<GenericTree>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<GenericTree> SearchGenericTree(string treeGroup, int orderType, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("TreeGroup", treeGroup)
            };
            List<Order> orderList = new List<Order>()
            {
                Order.Asc("TreeLevel")
            };
            if (orderType == 0)
            {
                orderList.Add(Order.Asc("NodeOrder"));
            }
            else if (orderType == 1)
            {
                orderList.Add(Order.Asc("NodeName"));
            }
            return SearchItem<GenericTree>(critList, orderList, 0, -1, out exception);
        }

        public static int GetGenericTreeCount(out Exception exception)
        {
            return GetItemCount<GenericTree>(null, out exception);
        }

        public static GenericTree GetGenericTree(string id, out Exception exception)
        {
            return GetItemInfo<GenericTree>("Id", id, out exception);
        }

        public static GenericTree GetGenericTreeByNodeName(string treeGroup, string nodeName, out Exception exception)
        {
            List<AbstractCriterion> critList = new List<AbstractCriterion>
            {
                Restrictions.Eq("TreeGroup", treeGroup),
                Restrictions.Eq("NodeName", nodeName)
            };
            return GetItemInfo<GenericTree>(critList, out exception);
        }

        public static int AddGenericTree(string treeGroup, string nodeName, int treeLevel, string treeParent,
            int nodeOrder, string nodeDesp, UserInfo adminInfo, out Exception exception)
        {
            GenericTree itemRecord = new GenericTree
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                TreeGroup = treeGroup,
                NodeName = nodeName,
                TreeLevel = treeLevel,
                TreeParent = treeParent,
                NodeOrder = nodeOrder,
                NodeDesp = nodeDesp,
                LastChanged = DateTime.Now,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyGenericTree(string id, string nodeName,
            int nodeOrder, string nodeDesp, UserInfo adminInfo, out Exception exception)
        {
            GenericTree itemRecord = GetGenericTree(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.NodeName = nodeName;
            itemRecord.NodeOrder = nodeOrder;
            itemRecord.NodeDesp = nodeDesp;
            itemRecord.LastChanged = DateTime.Now;
            return UpdateItem(itemRecord, out exception);
        }

        public static int UpdateGenericTree(GenericTree genericTree, out Exception exception)
        {
            return UpdateItem(genericTree, out exception);
        }

        public static int BatchUpdate(List<GenericTree> genericTree, out Exception exception)
        {
            /*
            List<TaskInfo> taskList = new List<TaskInfo>();
            for (int i = 0; i < genericTree.Count; i++)
            {
                if (genericTree[i].UpdateMode == 0)
                {
                    taskList.Add(new TaskInfo(OperationType.Add, genericTree[i]));
                }
                else
                {
                    taskList.Add(new TaskInfo(OperationType.Update, genericTree[i]));
                }
            }
            return ExecBatchTask(taskList, out exception);*/
            exception = null;
            return 0;
        }

        public static int DeleteGenericTree(string id, string treeGroup, UserInfo adminInfo, out Exception exception)
        {
            IList<GenericTree> departList = SearchGenericTree(treeGroup, 0, out exception);
            IList<GenericTree> delList = new List<GenericTree>();
            Hashtable queueTable = new Hashtable();
            queueTable[id] = 1;
            //生成删除ID列表
            for (int i = 0; i < departList.Count; i++)
            {
                if (departList[i].TreeParent != null && queueTable[departList[i].TreeParent] != null)
                {
                    queueTable[departList[i].Id] = 1;
                }
            }
            //生成删除实体列表
            for (int i = 0; i < departList.Count; i++)
            {
                if (queueTable[departList[i].Id] != null)
                {
                    delList.Add(departList[i]);
                }
            }
            return DeleteItem(delList, out exception);
        }
    }
}
