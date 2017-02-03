using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Store
{
   public partial class StockRecord:BaseEntity 
    {
       public long StockRecordId { get; set; }
       public long? DemandRecordId { get; set; }// stock receive from BSD according to Demand Record
       public int TransactionType { get; set; }
       public string InvoiceNo { get; set; }
       public int ReceivedBy { get; set; }
       public DateTime ReceivedDate { get; set; }

       public virtual ICollection<StockItemRecord> StockItemRecords { get; set; } 
    }
}
