using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tras.Core.Domain.Employee
{
    public partial class JobType:BaseEntity
    {
        [Key]
        public int JobTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ArmyPerson> ArmyPersons { get; set; }
    }
}
