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
    public class BllGridOutput
    {
        public static IList<GridItem> SearchGridItem(Type classType)
        {
            PropertyInfo[] piList = classType.GetProperties();
            IList<GridItem> itemList = new List<GridItem>();
            for (int i = 0; i < piList.Length; i++)
            {
                string hbComment = SqlDataHelper.GetHbComment(piList[i]);
                if (!string.IsNullOrEmpty(hbComment))
                {
                    GridItem itemInfo = new GridItem(piList[i].Name, hbComment);
                    itemList.Add(itemInfo);
                }
            }

            return itemList;
        }

        public static IList<GridOutput> SearchGridOutput(string funcGroup, out Exception exception)
        {
            return DalGridOutput.SearchGridOutput(funcGroup, out exception);
        }

        public static int GetGridOutputCount(out Exception exception)
        {
            return DalGridOutput.GetGridOutputCount(out exception);
        }

        public static GridOutput GetGridOutput(long id, out Exception exception)
        {
            return DalGridOutput.GetGridOutput(id, out exception);
        }

        public static int AddGridOutput(string funcGroup, string entityName, string entityDisplayName, int displayOrder,
            out Exception exception)
        {
            return DalGridOutput.AddGridOutput(funcGroup, entityName, entityDisplayName, displayOrder, out exception);
        }

        public static int ModifyGridOutput(long id, string funcGroup, string entityName, string entityDisplayName,
            int displayOrder, out Exception exception)
        {
            return DalGridOutput.ModifyGridOutput(id, funcGroup, entityName, entityDisplayName, displayOrder,
                out exception);
        }

        public static int UpdateGridOutput(GridOutput gridOutput, out Exception exception)
        {
            return DalGridOutput.UpdateGridOutput(gridOutput, out exception);
        }

        public static int DeleteGridOutput(long id, out Exception exception)
        {
            return DalGridOutput.DeleteGridOutput(id, out exception);
        }

        public static int ClearGridOutput(string funcGroup, out Exception exception)
        {
            return DalGridOutput.ClearGridOutput(funcGroup, out exception);
        }
    }
}
