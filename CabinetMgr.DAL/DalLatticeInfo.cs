using CabinetMgr.DAL.NhUtils;
using Domain.Main.Domain;
using Domain.Main.Types;
using NHibernate;
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

        public static int InitLattice(IList<string> doorList, string labName, int location, out Exception exception)
        {
            IList<TaskInfo> taskList = new List<TaskInfo>();
            foreach(string doorInfo in doorList)
            {
                string id = doorInfo.Split('|')[0];
                string nch = doorInfo.Split('|')[1];
                LatticeInfo info = new LatticeInfo()
                {
                    CabinetNum = id,
                    CabinetLatticeNum = nch,
                    Location = location,
                    LabName = labName,
                    Channel = id,
                    BoardId = nch
                };
                taskList.Add(new TaskInfo(OperationType.Add, info));
            }
            
            return ExecBatchTask(taskList, out exception);
        }

        public static int DeleteAll(out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.Not(Restrictions.Eq("Id", null)));
            return DeleteItem(criterionList, out exception);
        }

        public static IList<LatticeInfo> SearchLatticeInfo(long[] idAry, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.In("Id", idAry));
            //Criterion Processing
            return SearchItem(criterionList, null, 0, -1, out exception);
        }

        public static LatticeInfo GetLatticeInfo(string labName, int location, string cabinetNum, string cabinetLatticeNum, out Exception exception)
        {
            List<AbstractCriterion> criterionList = new List<AbstractCriterion>();
            criterionList.Add(Restrictions.Eq("LabName", labName));
            criterionList.Add(Restrictions.Eq("Location", location));
            criterionList.Add(Restrictions.Eq("CabinetNum", cabinetNum));
            criterionList.Add(Restrictions.Eq("CabinetLatticeNum", cabinetLatticeNum));

            return GetItemInfo(criterionList, out exception);
        }

        public static IList<string> GetPageList(out Exception exception)
        {
            exception = null;
            try
            {
                var sessionFactory = NhControl.CreateSessionFactory(NhTypes.DbTarget.Client);
                using (var session = sessionFactory.OpenSession())
                {
                    string queryStr = "select distinct CabinetNum from LatticeInfo order by cabinetnum";
                    var pQuery = session.CreateQuery(queryStr);
                    return pQuery.List<string>();
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return null;
        }
    }
}
