using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;

namespace Tras.Core.Domain.Distribution
{
    public partial class DispersionItemRecord : BaseEntity
    {
        public long DispersionItemRecordId { get; set; }
        public long DispersionRecordId { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        // Navigation properties
        public virtual DispersionRecord DispersionRecord { get; set; }
        public virtual RationItem RationItem { get; set; }
    }
}
