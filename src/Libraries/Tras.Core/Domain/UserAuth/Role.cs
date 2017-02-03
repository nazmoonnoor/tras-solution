using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.UserAuth
{
    public class Role : BaseEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<RoleMethod> RoleMethods { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
