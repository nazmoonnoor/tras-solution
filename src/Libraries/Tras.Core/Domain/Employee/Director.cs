using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tras.Core.Domain.Employee
{
    public partial class Director : BaseEntity
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Person { get; set; }
    }
}
