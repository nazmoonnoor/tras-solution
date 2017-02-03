using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Residence;

namespace Tras.Core.Domain.Distribution
{
    public partial class MessDispersionRecord:BaseEntity
    {
        public long MessDispersionRecordId { get; set; }
        public int MessId { get; set; }
        public int TransactionType { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceCreatedBy { get; set; }
        public DateTime DeliveredDate { get; set; }
        public int DeliveredBy { get; set; }
        public double NetPrice { get; set; }
        public int DaysCount { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


        public virtual Mess Mess { get; set; }
        public virtual ICollection<MessDispersionItemRecord> MessDispersionItemRecords { get; set; } 
    }
}
