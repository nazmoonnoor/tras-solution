using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Employee
{
   public partial class SpouseInfo:BaseEntity
    {
       public int SpouseInfoId { get; set; }
       public int PersonId { get; set; }
       public string FullName { get; set; }
       public string FatherName { get; set; }
       public DateTime DateOfBirth { get; set; }
       public string NationalId { get; set; }
       public string Profession { get; set; }
       public string PresentAddress { get; set; }
       public string PermanentAddress { get; set; }
       public string ContractNo { get; set; }
       public byte[] Photo { get; set; }


       public virtual Person Person { get; set; }

    }
}
