using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Employee
{
   public partial class Station:BaseEntity
    {
       public int StationId { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
