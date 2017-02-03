using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;

namespace Tras.Core.Domain.Store
{
   public partial class StockItemRecord:BaseEntity 
    {
       public long StockItemRecordId { get; set; }
       public long StockRecordId { get; set; }
       public int ItemId { get; set; }
       public decimal Quantity { get; set; }
       public virtual StockRecord StockRecord { get; set; }
       public virtual RationItem RationItem { get; set; }
    }
}
