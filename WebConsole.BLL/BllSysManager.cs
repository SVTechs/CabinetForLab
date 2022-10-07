using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllSysManager
    {
        public static int ExecConnect(out Exception exception)
        {
            return DalSysManager.ExecConnect(out exception);
        }
    }
}
