using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Server.Domain;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalSysManager : FlexNhBase<UserInfo>
    {
        public static int ExecConnect(out Exception exception)
        {
            exception = null;
            try
            {
                var result = ExecQuery("select 1", null, out exception);
                if (exception != null) return -201;
                return (int)result.Tables[0].Rows[0][0];
            }
            catch (Exception ex)
            {
                exception = ex;
                return -200;
            }
        }
    }
}
