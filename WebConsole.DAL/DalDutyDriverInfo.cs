using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using Domain.Server.Types;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalDutyDriverInfo : FlexNhBase<DutyDriverInfo>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<DutyDriverInfo> SearchDutyDriverInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception)
        {
            var order = DbOrder.ToOrderList(orderList);
            return SearchItem<DutyDriverInfo>(null, order, dataStart, dataCount, out exception);
        }

        public static int GetDutyDriverInfoCount(out Exception exception)
        {
            return GetItemCount<DutyDriverInfo>(null, out exception);
        }

        public static DutyDriverInfo GetDutyDriverInfo(long id, out Exception exception)
        {
            return GetItemInfo<DutyDriverInfo>("Id", id, out exception);
        }

        public static int AddDutyDriverInfo(string trainType, string trainCode, string runtimeCode, string trainPos, string driver1Id, string driver1Name, string driver1Tel, string driver2Id, string driver2Name, string driver2Tel, string mechanicianId, string mechanician, string mechanicianTel, out Exception exception)
        {
            DutyDriverInfo itemRecord = new DutyDriverInfo
            {
                TrainType = trainType,
                TrainCode = trainCode,
                RuntimeCode = runtimeCode,
                TrainPos = trainPos,
                Driver1Id = driver1Id,
                Driver1Name = driver1Name,
                Driver1Tel = driver1Tel,
                Driver2Id = driver2Id,
                Driver2Name = driver2Name,
                Driver2Tel = driver2Tel,
                MechanicianId = mechanicianId,
                Mechanician = mechanician,
                MechanicianTel = mechanicianTel,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyDutyDriverInfo(long id, string trainType, string trainCode, string runtimeCode, string trainPos, string driver1Id, string driver1Name, string driver1Tel, string driver2Id, string driver2Name, string driver2Tel, string mechanicianId, string mechanician, string mechanicianTel, out Exception exception)
        {
            DutyDriverInfo itemRecord = GetDutyDriverInfo(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.TrainType = trainType;
            itemRecord.TrainCode = trainCode;
            itemRecord.RuntimeCode = runtimeCode;
            itemRecord.TrainPos = trainPos;
            itemRecord.Driver1Id = driver1Id;
            itemRecord.Driver1Name = driver1Name;
            itemRecord.Driver1Tel = driver1Tel;
            itemRecord.Driver2Id = driver2Id;
            itemRecord.Driver2Name = driver2Name;
            itemRecord.Driver2Tel = driver2Tel;
            itemRecord.MechanicianId = mechanicianId;
            itemRecord.Mechanician = mechanician;
            itemRecord.MechanicianTel = mechanicianTel;
            return UpdateItem(itemRecord, out exception);
        }

        public static int UpdateDutyDriverInfo(DutyDriverInfo dutyDriverInfo, out Exception exception)
        {
            return UpdateItem(dutyDriverInfo, out exception);
        }

        public static int DeleteDutyDriverInfo(long id, out Exception exception)
        {
            return DeleteItem<DutyDriverInfo>("Id", id, out exception);
        }
    }
}
