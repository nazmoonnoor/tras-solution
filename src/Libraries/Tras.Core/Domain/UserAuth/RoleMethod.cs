using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.UserAuth
{
    public class RoleMethod : BaseEntity
    {
        public int RoleMethodId { get; set; }
        public int RoleId { get; set; }
        public int MethodId { get; set; }

        public virtual Role Roles { get; set; }
        public virtual Method Methods { get; set; }
    }
}
