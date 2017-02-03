using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Employee
{
   public partial  class ParentsInfo:BaseEntity 
    {
       public int ParentsInfoId { get; set; }
       public int PersonId { get; set; }
       public string ParentTypeKey { get; set; }
       public string FullName { get; set; }
       public DateTime DateOfBirth { get; set; }
       public DateTime DateOfDeceased { get; set; }
       public string GenderKey { get; set; }
       public string NationalId { get; set; }
       public string Profession { get; set; }
       public string PresentAddress { get; set; }
       public string PermanentAddress { get; set; }
       public string ContractNo { get; set; }
       public byte[] Photo { get; set; }

       
       public virtual Person Person { get; set; }  
    }
}
