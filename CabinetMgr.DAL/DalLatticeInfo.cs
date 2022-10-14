using CabinetMgr.DAL.NhUtils;
using Domain.Main.Domain;
using Domain.Main.Types;
using NHibernate.Criterion;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMgr.DAL
{
    public class DalLatticeInfo : FlexNhBase<LatticeInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<LatticeInfo> SearchLatticeInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            List<Order> requestedOrder = new List<Order>() { new Order("LabName", true), new Order("Location", true), new Order("CabinetNum", true), new Order("CabinetLatticeNum", true) };
            return SearchItem(criterionList, requestedOrder, dataStart, dataCount, out exception);
        }

        public static int GetLatticeInfoCount(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            return GetItemCount(criterionList, out exception);
        }

        public static LatticeInfo GetLatticeInfo(long id, out Exception exception)
        {
            return GetItemInfo("Id", id, out exception);
        }

        public static LatticeInfo GetLatticeInfo(string entityName, object entityValue, out Exception exception)
        {
            return GetItemInfo(entityName, entityValue, out exception);
        }

        public static int AddLatticeInfo(string cabinetNum, string cabinetLatticeNum, int location, string channel, string boardId, out Exception exception)
        {
            LatticeInfo itemRecord = new LatticeInfo
            {
                CabinetNum = cabinetNum,
                CabinetLatticeNum = cabinetLatticeNum,
                Location = location,
                Channel = channel,
                BoardId = boardId,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyLatticeInfo(long id, string cabinetNum, string cabinetLatticeNum, int location, string channel, string boardId, out Exception exception)
        {
            LatticeInfo itemRecord = GetLatticeInfo(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.CabinetNum = cabinetNum;
            itemRecord.CabinetLatticeNum = cabinetLatticeNum;
            itemRecord.Location = location;
            itemRecord.Channel = channel;
            itemRecord.BoardId = boardId;
            return UpdateItem(itemRecord, out exception);
        }

        public static int SaveLatticeInfo(LatticeInfo latticeInfo, out Exception exception)
        {
            return SaveItem(latticeInfo, out exception);
        }

        public static int UpdateLatticeInfo(LatticeInfo latticeInfo, out Exception exception)
        {
            return UpdateItem(latticeInfo, out exception);
        }

        public static int DeleteLatticeInfo(long id, out Exception exception)
        {
            return DeleteItem("Id", id, out exception);
        }

        public static DataSet ExecSqlQuery(string queryCmd, DbParameter[] paraList, out Exception exception)
        {
            return ExecQuery(queryCmd, paraList, out exception);
        }

        public static IList<LatticeInfo> GetLatticeInfoList(long[] latticeIdAry, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            //Criterion Processing
            criterionList.Add(Restrictions.In("Id", latticeIdAry));
            return SearchItem(criterionList, null, 0, -1, out exception);
        }
    }
}
