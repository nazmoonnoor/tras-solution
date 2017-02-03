using System.Collections.Generic;
using Tras.Core.Domain.Store;

namespace Tras.Core.Domain.Ration
{
    public partial class RationHead : BaseEntity
    {
        public int HeadId { get; set; }
        public string HeadName { get; set; }

        public virtual ICollection<RationSubHead> SubHeads { get; set; }

        public virtual ICollection<DemandRecord> DemandRecords { get; set; } 
    }
}
