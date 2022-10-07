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

        public virtual int ToolPosition { get; set; }

        public virtual string WorkerId { get; set; }

        public virtual string WorkerName { get; set; }

        public virtual DateTime EventTime { get; set; }

        public virtual int Status { get; set; }

        public virtual DateTime ReturnTime { get; set; }
    }
}
