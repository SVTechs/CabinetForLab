using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using WebConsole.DAL;
using Domain.Server.Domain;
using Domain.Server.Types;
using Utilities.DbHelper;

namespace WebConsole.BLL
{
    public class BllInterfaceOutput
    {
        public static IList<GridItem> SearchOutputItem(string assemblyName)
        {
            Assembly entityAssembly = Assembly.Load(assemblyName);
            Type[] types = entityAssembly.GetTypes();
            IList<GridItem> itemList = new List<GridItem>();
            for (int i = 0; i < types.Length; i++)
            {
                DomainAnnotations da = SqlDataHelper.GetDomainAnnotations(types[i]);
                if (da != null)
                {
                    GridItem itemInfo = new GridItem(types[i].Name, da.DomainName);
                    itemList.Add(itemInfo);
                }
            }

            return itemList;
        }

        public static IList<InterfaceOutput> SearchInterfaceOutput(int dataStart, int dataCount,
            out Exception exception)
        {
            return DalInterfaceOutput.SearchInterfaceOutput(dataStart, dataCount, out exception);
        }

        public static int GetInterfaceOutputCount(out Exception exception)
        {
            return DalInterfaceOutput.GetInterfaceOutputCount(out exception);
        }

        public static IList<InterfaceOutput> SearchInterfaceOutput(string roleId, string domainName,
            out Exception exception)
        {
            return DalInterfaceOutput.SearchInterfaceOutput(roleId, domainName, out exception);
        }

        public static InterfaceOutput GetInterfaceOutput(long id, out Exception exception)
        {
            return DalInterfaceOutput.GetInterfaceOutput(id, out exception);
        }

        public static int AddInterfaceOutput(string roleId, string domainName, string entityName, int displayOrder,
            out Exception exception)
        {
            return DalInterfaceOutput.AddInterfaceOutput(roleId, domainName, entityName, displayOrder, out exception);
        }

        public static int ModifyInterfaceOutput(long id, string roleId, string domainName, string entityName,
            int displayOrder, out Exception exception)
        {
            return DalInterfaceOutput.ModifyInterfaceOutput(id, roleId, domainName, entityName, displayOrder,
                out exception);
        }

        public static int UpdateInterfaceOutput(InterfaceOutput interfaceOutput, out Exception exception)
        {
            return DalInterfaceOutput.UpdateInterfaceOutput(interfaceOutput, out exception);
        }

        public static int DeleteInterfaceOutput(long id, out Exception exception)
        {
            return DalInterfaceOutput.DeleteInterfaceOutput(id, out exception);
        }

        public static int ClearInterfaceOutput(string roleId, string domainName, out Exception exception)
        {
            return DalInterfaceOutput.ClearInterfaceOutput(roleId, domainName, out exception);
        }

        public static int SetInterfaceOutput(string roleId, string domainName, List<string> entityList,
            out Exception exception)
        {
            return DalInterfaceOutput.SetInterfaceOutput(roleId, domainName, entityList, out exception);
        }
    }
}
