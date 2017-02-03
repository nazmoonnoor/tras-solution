using System.Collections.Generic;
using Tras.Core.Domain.Distribution;
using Tras.Core.Domain.Store;

namespace Tras.Core.Domain.Ration
{
    public partial class RationItem : BaseEntity
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public decimal? SoldierQty { get; set; }
        public decimal? GeneralQty { get; set; }

        public decimal? HalfQty { get; set; }
        public decimal? MinorQty { get; set; }

        public virtual RationItemCategory Category { get; set; }
        public virtual ICollection<PackageItem> PackageItems { get; set; }
        public virtual ICollection<DispersionItemRecord> DispersionItemRecords { get; set; }
        public virtual ICollection<MessDispersionItemRecord> MessDispersionItemRecords { get; set; }
        public virtual ICollection<DemandItemRecord> DemandItemRecords { get; set; }
        public virtual ICollection<StockItemRecord> StockItemRecords { get; set; } 
    }
}
