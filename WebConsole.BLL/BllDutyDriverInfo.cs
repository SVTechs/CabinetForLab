using System;
using System.Collections;
using System.Collections.Generic;
using WebConsole.DAL;
using Domain.Server.Domain;
using Domain.Server.Types;

namespace WebConsole.BLL
{
    public class BllDutyDriverInfo
    {
        public static IList<DutyDriverInfo> SearchDutyDriverInfo(int dataStart, int dataCount, List<DbOrder.OrderInfo> orderList, out Exception exception) {
            return DalDutyDriverInfo.SearchDutyDriverInfo(dataStart, dataCount, orderList, out exception);
        }

        public static int GetDutyDriverInfoCount(out Exception exception) {
            return DalDutyDriverInfo.GetDutyDriverInfoCount(out exception);
        }

        public static DutyDriverInfo GetDutyDriverInfo(long id, out Exception exception) {
            return DalDutyDriverInfo.GetDutyDriverInfo(id, out exception);
        }

        public static int AddDutyDriverInfo(string trainType, string trainCode, string runtimeCode, string trainPos, string driver1Id, string driver1Name, string driver1Tel, string driver2Id, string driver2Name, string driver2Tel, string mechanicianId, string mechanician, string mechanicianTel, out Exception exception) {
            return DalDutyDriverInfo.AddDutyDriverInfo(trainType, trainCode, runtimeCode, trainPos, driver1Id, driver1Name, driver1Tel, driver2Id, driver2Name, driver2Tel, mechanicianId, mechanician, mechanicianTel, out exception);
        }

        public static int ModifyDutyDriverInfo(long id, string trainType, string trainCode, string runtimeCode, string trainPos, string driver1Id, string driver1Name, string driver1Tel, string driver2Id, string driver2Name, string driver2Tel, string mechanicianId, string mechanician, string mechanicianTel, out Exception exception) {
            return DalDutyDriverInfo.ModifyDutyDriverInfo(id, trainType, trainCode, runtimeCode, trainPos, driver1Id, driver1Name, driver1Tel, driver2Id, driver2Name, driver2Tel, mechanicianId, mechanician, mechanicianTel, out exception);
        }

        public static int UpdateDutyDriverInfo(DutyDriverInfo dutyDriverInfo, out Exception exception) {
            return DalDutyDriverInfo.UpdateDutyDriverInfo(dutyDriverInfo, out exception);
        }

        public static int DeleteDutyDriverInfo(long id, out Exception exception) {
            return DalDutyDriverInfo.DeleteDutyDriverInfo(id, out exception);
        }
    }
}
