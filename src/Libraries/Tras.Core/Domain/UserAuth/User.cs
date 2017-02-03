using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Employee;

namespace Tras.Core.Domain.UserAuth
{
    public class User : BaseEntity
    {
        [Key, ForeignKey("Person")]
        public int PersonId { get; set; }

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
