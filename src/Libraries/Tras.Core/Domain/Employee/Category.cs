using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tras.Core.Domain.Employee
{
    public partial class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ArmyPerson> ArmyPersons { get; set; }
    }
}
