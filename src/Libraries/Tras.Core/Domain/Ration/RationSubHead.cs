using System.Collections.Generic;

namespace Tras.Core.Domain.Ration
{
    public partial class RationSubHead : BaseEntity
    {
        public int SubHeadId { get; set; }
        public int HeadId { get; set; }
        public string SubHeadName { get; set; }

        public virtual RationHead Head { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
