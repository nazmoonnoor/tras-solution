using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.UserAuth
{
    public class UserRole : BaseEntity
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Roles { get; set; }
        public virtual User Users { get; set; }
    }
}
