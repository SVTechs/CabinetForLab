using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using Utilities.DbHelper;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllPageFunctions
    {
        public static IList<PageFunctions> SearchPageFunctions(out Exception exception)
        {
            return DalPageFunctions.SearchPageFunctions(out exception);
        }

        public static IList<PageFunctions> SearchGroupFunctions(string funcGroup, out Exception exception)
        {
            return DalPageFunctions.SearchGroupFunctions(funcGroup, out exception);
        }

        public static PageFunctions GetPageFunctions(string id, out Exception exception)
        {
            return DalPageFunctions.GetPageFunctions(id, out exception);
        }

        public static Hashtable GetFunctionTable(out Exception exception)
        {
            Hashtable funcTable = new Hashtable();
            IList<PageFunctions> funcList = SearchPageFunctions(out exception);
            if (SqlDataHelper.IsDataValid(funcList))
            {
                //功能预扫描及二级功能置入
                Hashtable functionL1 = new Hashtable();
                for (int i = 0; i < funcList.Count; i++)
                {
                    if (!string.IsNullOrEmpty(funcList[i].FunctionMenu))
                    {
                        functionL1[funcList[i].Id] = i;
                    }
                    else
                    {
                        int index = (int)functionL1[funcList[i].FunctionParent];
                        if (funcList[index].ChildFunction == null)
                            funcList[index].ChildFunction = new List<PageFunctions>();
                        funcList[index].ChildFunction.Add(funcList[i]);
                    }
                }
                //生成菜单功能表
                for (int i = 0; i < funcList.Count; i++)
                {
                    if (!string.IsNullOrEmpty(funcList[i].FunctionMenu))
                    {
                        if (funcTable[funcList[i].FunctionMenu] == null)
                        {
                            funcTable[funcList[i].FunctionMenu] = new ArrayList();
                        }
                        ((ArrayList)funcTable[funcList[i].FunctionMenu]).Add(funcList[i]);
                    }
                    else
                    {
                        //功能已排序，非一级功能终止执行
                        break;
                    }
                }
            }
            return funcTable;
        }

        public static int AddPageFunction(string funcName, int funcOrder, string funcMenu, string funcDesp,
            UserInfo userInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(funcName) || string.IsNullOrEmpty(funcMenu))
            {
                exception = null;
                return -100;
            }
            return DalPageFunctions.AddPageFunction(funcName, funcOrder, funcMenu, funcDesp, userInfo, out exception);
        }

        public static int AddSubFunction(string funcName, int funcOrder, string funcParent, string funcDesp,
            UserInfo userInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(funcName) || string.IsNullOrEmpty(funcParent))
            {
                exception = null;
                return -100;
            }
            return DalPageFunctions.AddSubFunction(funcName, funcOrder, funcParent, funcDesp, userInfo, out exception);
        }

        public static int ModifyPageFunction(string funcId, string funcName, int funcOrder, string funcDesp,
            UserInfo userInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(funcId) || string.IsNullOrEmpty(funcName))
            {
                exception = null;
                return -100;
            }
            return DalPageFunctions.ModifyPageFunction(funcId, funcName, funcOrder, funcDesp, userInfo, out exception);
        }

        public static int DeletePageFunctions(string id, UserInfo userInfo, out Exception exception)
        {
            return DalPageFunctions.DeletePageFunctions(id, userInfo, out exception);
        }
    }
}
