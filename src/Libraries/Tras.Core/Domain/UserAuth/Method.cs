using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tras.Core.Domain.UserAuth
{
   public class Method:BaseEntity
    {
        public int MethodId { get; set; }
        public string ModuleName { get; set; }
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public string NameToShow { get; set; }
        public bool IsShowInMenu { get; set; }
        public int OrderNo { get; set; }

        public virtual ICollection<RoleMethod> RoleMethods { get; set; } 
    }
}
