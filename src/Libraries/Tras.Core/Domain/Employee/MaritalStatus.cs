using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tras.Core.Domain.Employee
{
   public partial class MaritalStatus:BaseEntity
    {
       [Key]
       public int MaritalStatusId { get; set; }
       public string Name { get; set; }
       public ICollection<ArmyPerson> ArmyPersons { get; set; }
    }
}
