using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Domain
{
    public class RoleSettings
    {
        public virtual string Id { get; set; }

        public virtual string UserId { get; set; }

        public virtual string RoleId { get; set; }

        public virtual DateTime AddTime { get; set; }
    }
}
