using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Employee
{
   public partial class ChildrenInfo:BaseEntity 
    {
       public int ChildrenInfoId { get; set; }
       public int PersonId { get; set; }
       public string FullName { get; set; }
       public DateTime DateOfBirth { get; set; }
       public string GenderKey { get; set; }
       public string ContractNo { get; set; }
       public byte[] Photo { get; set; }

       public virtual Person Person { get; set; }  
    }
}
