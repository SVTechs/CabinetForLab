using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Domain
{
    public class Info
    {
        public virtual string Id { get; set; }

        public virtual string InfoContent { get; set; }

        public virtual int InfoType { get; set; }

        public virtual int IsTop { get; set; }

        public virtual DateTime CreateTime { get; set; }
    }
}
