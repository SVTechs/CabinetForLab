using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMgr.Common
{
    public class FormCallback
    {
        public delegate void FormIndexRefreshDelegate();
        public static FormIndexRefreshDelegate FormIndexRefresh = null;

        public delegate void FormUserManageRefreshDelegate();
        public static FormUserManageRefreshDelegate FormUserManageRefresh = null;

        public delegate void FormToolManageRefreshDelegate();
        public static FormToolManageRefreshDelegate FormToolManageRefresh = null;
    }
}
