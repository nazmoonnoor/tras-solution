using System.Collections.Generic;

namespace Tras.Core.Domain.Employee
{
    public partial class Department : BaseEntity
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Person { get; set; }
    }
}
