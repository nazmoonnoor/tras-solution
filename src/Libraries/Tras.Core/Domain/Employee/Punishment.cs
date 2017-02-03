using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Employee
{
  public partial class Punishment:BaseEntity
    {
      public int PunishmentId { get; set; }
      public int PersonId { get; set; }
      public string Place { get; set; }//ND
      public string OffenceSummery { get; set; }
      public string PunishmentAwarded { get; set; }
      public string AwardedBy { get; set; }//ND
      public string DateOfPunishment { get; set; }
      public virtual ICollection<Person> Persons { get; set; }  
    }
}
