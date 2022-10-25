using CabinetMgr.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.DbHelper;

namespace Domain.Main.Domain
{
    [Serializable, DomainAnnotations(true, "借用记录")]
    public class BorrowRecord
    {
        [HbAnnotations("Id")]
        public virtual string Id { get; set; }

        public virtual string ToolId { get; set; }

        public virtual string ToolName { get; set; }

        public virtual string ToolPosition { get; set; }

        public virtual int ToolCount { get; set; }

        public virtual string WorkerId { get; set; }

        public virtual string WorkerName { get; set; }

        public virtual DateTime EventTime { get; set; }

        public virtual int Status { get; set; }

        public virtual DateTime ReturnTime { get; set; }

        public virtual string StatusResult
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "借出";
                    case 10:
                        return "已归还";
                    case -10:
                        return "报修";
                    case -20:
                        return "缺料";
                    default:
                        return "";
                }
            }
        }

        public virtual string ReturnTimeValue
        {
            get
            {
                return ReturnTime == Env.MinTime ? "" : ReturnTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

    }
}
