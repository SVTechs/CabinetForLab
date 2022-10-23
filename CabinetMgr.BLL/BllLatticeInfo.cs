using CabinetMgr.DAL;
using Domain.Main.Domain;
using Domain.Main.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMgr.BLL
{
    public class BllLatticeInfo
    {
        public static IList<LatticeInfo> SearchLatticeInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            return DalLatticeInfo.SearchLatticeInfo(dataStart, dataCount, orderList, out exception);
        }

        public static int GetLatticeInfoCount(out Exception exception)
        {
            return DalLatticeInfo.GetLatticeInfoCount(out exception);
        }

        public static LatticeInfo GetLatticeInfo(long id, out Exception exception)
        {
            return DalLatticeInfo.GetLatticeInfo(id, out exception);
        }

        public static LatticeInfo GetLatticeInfo(string entityName, object entityValue, out Exception exception)
        {
            return DalLatticeInfo.GetLatticeInfo(entityName, entityValue, out exception);
        }

        public static int AddLatticeInfo(string cabinetNum, string cabinetLatticeNum, int location, string channel, string boardId, out Exception exception)
        {
            return DalLatticeInfo.AddLatticeInfo(cabinetNum, cabinetLatticeNum, location, channel, boardId, out exception);
        }

        public static int ModifyLatticeInfo(long id, string cabinetNum, string cabinetLatticeNum, int location, string channel, string boardId, out Exception exception)
        {
            return DalLatticeInfo.ModifyLatticeInfo(id, cabinetNum, cabinetLatticeNum, location, channel, boardId, out exception);
        }

        public static int SaveLatticeInfo(LatticeInfo latticeInfo, out Exception exception)
        {
            return DalLatticeInfo.SaveLatticeInfo(latticeInfo, out exception);
        }

        public static int UpdateLatticeInfo(LatticeInfo latticeInfo, out Exception exception)
        {
            return DalLatticeInfo.UpdateLatticeInfo(latticeInfo, out exception);
        }

        public static int DeleteLatticeInfo(long id, out Exception exception)
        {
            return DalLatticeInfo.DeleteLatticeInfo(id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return DalLatticeInfo.ExecSqlQuery(queryCmd, paraList, out exception);
        }

        public static IList<LatticeInfo> GetLatticeInfoList(long[] latticeIdAry, out Exception exception)
        {
            return DalLatticeInfo.GetLatticeInfoList(latticeIdAry, out exception);
        }

        public static int InitLattice(IList<string> doorList, string labName, int location, out Exception exception)
        {
            return DalLatticeInfo.InitLattice(doorList, labName, location, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            return DalLatticeInfo.DeleteAll(out exception);
        }

        public static IList<LatticeInfo> SearchLatticeInfo(long[] idAry, out Exception exception)
        {
            return DalLatticeInfo.SearchLatticeInfo(idAry, out exception);
        }

        public static LatticeInfo GetLatticeInfo(string labName, int location, string cabinetNum, string cabinetLatticeNum, out Exception exception)
        {
            return DalLatticeInfo.GetLatticeInfo(labName, location, cabinetNum, cabinetLatticeNum, out exception);
        }
    }
}
