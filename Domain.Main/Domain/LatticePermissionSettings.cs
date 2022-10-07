using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Domain
{
    public class LatticePermissionSettings
    {
        public virtual string Id { get; set; }

        public virtual string OwnerType { get; set; }

        public virtual string OwnerId { get; set; }

        public virtual long LatticeId { get; set; }

        public virtual DateTime AddTime { get; set; }
    }
}
