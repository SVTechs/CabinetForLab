using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Domain
{
    public class ToolInfo
    {
        public virtual string Id { get; set; }

        public virtual long LatticeId { get; set; }

        public virtual string ToolName { get; set; }

        public virtual string LatticePosition { get; set; }

        public virtual string ToolCode { get; set; }

        public virtual string ToolSpec { get; set; }

        public virtual long ToolTypeId { get; set; }

        public virtual string ToolTypeName { get; set; }

        public virtual int ToolCount { get; set; }

        public virtual int CurrentCount { get; set; }

        public virtual string HardwareId { get; set; }

        public virtual string CardId { get; set; }

        public virtual string ToolManager { get; set; }

        public virtual string Comment { get; set; }

        public virtual string Operator { get; set; }

        public virtual string OperatorName { get; set; }

        public virtual DateTime OperateTime { get; set; }

        public virtual int ToolStatus { get; set; }

        public virtual int WarnType { get; set; }

        public virtual int WarnValue { get; set; }
    }
}
