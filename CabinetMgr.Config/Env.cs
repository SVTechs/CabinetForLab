using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMgr.Config
{
    public class Env
    {
        public static string ConfigPath = "";

        public static string EncSeed = "CabinetForLab";

        public static int UhfDelay = 3;

        public static string DataType = "";

        public static DateTime MinTime = DateTime.Parse("1980-01-01 00:00:00"), MaxTime = DateTime.Parse("2099-12-31 23:59:59");
    }
}
