using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllGenericTree
    {
        public static IList<GenericTree> SearchGenericTree(string treeGroup, int orderType, out Exception exception)
        {
            return DalGenericTree.SearchGenericTree(treeGroup, orderType, out exception);
        }

        public static int GetGenericTreeCount(out Exception exception)
        {
            return DalGenericTree.GetGenericTreeCount(out exception);
        }

        public static GenericTree GetGenericTree(string id, out Exception exception)
        {
            return DalGenericTree.GetGenericTree(id, out exception);
        }

        public static GenericTree GetGenericTreeByNodeName(string treeGroup, string nodeName, out Exception exception)
        {
            return DalGenericTree.GetGenericTreeByNodeName(treeGroup, nodeName, out exception);
        }

        public static int AddGenericTree(string treeGroup, string nodeName, int treeLevel, string treeParent,
            int nodeOrder, string nodeDesp, UserInfo adminInfo, out Exception exception)
        {
            return DalGenericTree.AddGenericTree(treeGroup, nodeName, treeLevel, treeParent, nodeOrder,
                nodeDesp, adminInfo, out exception);
        }

        public static int ModifyGenericTree(string id, string nodeName,
            int nodeOrder, string nodeDesp, UserInfo adminInfo, out Exception exception)
        {
            return DalGenericTree.ModifyGenericTree(id, nodeName,
                nodeOrder, nodeDesp, adminInfo, out exception);
        }

        public static int UpdateGenericTree(GenericTree genericTree, out Exception exception)
        {
            return DalGenericTree.UpdateGenericTree(genericTree, out exception);
        }

        public static int BatchUpdate(List<GenericTree> genericTree, out Exception exception)
        {
            return DalGenericTree.BatchUpdate(genericTree, out exception);
        }

        public static int DeleteGenericTree(string id, string treeGroup, UserInfo adminInfo, out Exception exception)
        {
            return DalGenericTree.DeleteGenericTree(id, treeGroup, adminInfo, out exception);
        }
    }
}
