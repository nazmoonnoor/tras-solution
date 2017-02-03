using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tras.Core.Domain.Employee
{
    public class FamilyInfo : BaseEntity
    {
        [Key, ForeignKey("Person")]
        public int PersonId { get; set; }
        public int Own { get; set; }
        public int Spouse { get; set; }
        public int KidsMinor { get; set; }
        public int KidsHalf { get; set; }
        public int KidsAdult { get; set; }
        public int BatMan { get; set; }
        
        public virtual Person Person { get; set; }
    }
}
