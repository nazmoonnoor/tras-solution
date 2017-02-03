using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Employee
{
   public partial class Nok:BaseEntity 
    {
       public int NokId { get; set; }
       public int PersonId { get; set; }
       public string FullName { get; set; }
       public string RelationKey { get; set; }// Use common enum Table 
       public string ContractNo { get; set; }
       public byte[] Photo { get; set; }

       public virtual Person Person { get; set; }  
    }
}
