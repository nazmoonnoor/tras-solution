using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tras.Core.Domain.Employee
{
    public partial class Rank : BaseEntity
    {
        [Key]
        public int RankId { get; set; }
        public string Name { get; set; }
        
        public ICollection<Person> Person { get; set; }
    }
}
