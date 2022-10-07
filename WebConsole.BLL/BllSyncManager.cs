using System;
using System.Data;
using Domain.Server.Types;
using Utilities.DbHelper;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllSyncManager
    {
        /// <summary>
        /// 获取变化数据
        /// </summary>
        /// <param name="tableType"></param>
        /// <param name="lastId"></param>
        /// <param name="dbTarget"></param>
        /// <returns></returns>
        public static DataSet GetChangedData(Type tableType, long lastId, NhTypes.DbTarget dbTarget)
        {
            if (tableType == null)
            {
                return null;
            }
            return DalSyncManager.GetChangedData(tableType, lastId, dbTarget);
        }

        /// <summary>
        /// 保存数据于服务端
        /// </summary>
        /// <param name="tableType"></param>
        /// <param name="infoSet"></param>
        /// <param name="dataOwner"></param>
        /// <param name="dbTarget"></param>
        /// <returns></returns>
        public static int SaveData(Type tableType, DataSet infoSet, string dataOwner, NhTypes.DbTarget dbTarget)
        {
            if (!SqlDataHelper.IsDataValid(infoSet))
            {
                return -100;
            }
            return DalSyncManager.SaveData(tableType, infoSet, dataOwner, dbTarget);
        }
    }
}
