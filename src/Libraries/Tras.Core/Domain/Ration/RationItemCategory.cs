using System.Collections.Generic;
using Tras.Core.Domain.Store;

namespace Tras.Core.Domain.Ration
{
    public partial class RationItemCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<RationItem> Items { get; set; }
        public virtual ICollection<DemandRecord> DemandRecords { get; set; } 
    }
}
