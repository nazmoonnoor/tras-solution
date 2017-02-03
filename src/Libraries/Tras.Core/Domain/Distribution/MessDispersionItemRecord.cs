using Tras.Core.Domain.Ration;

namespace Tras.Core.Domain.Distribution
{
   public partial class MessDispersionItemRecord:BaseEntity
    {

        public long MessDispersionItemRecordId { get; set; }
        public long MessDispersionRecordId { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        public virtual MessDispersionRecord MessDispersionRecord { get; set; }
        public virtual RationItem RationItem { get; set; }

    }
}
