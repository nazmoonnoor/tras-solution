using System.Collections.Generic;

namespace Tras.Core.Domain.Employee
{
    public partial class Unit:BaseEntity
    {
        public int UnitId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
