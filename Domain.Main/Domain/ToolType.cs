using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Domain
{
    public class ToolType
    {
        public virtual long Id { get; set; }

        public virtual string TypeName { get; set; }

        public virtual DateTime CreateTime { get; set; }
    }
}
