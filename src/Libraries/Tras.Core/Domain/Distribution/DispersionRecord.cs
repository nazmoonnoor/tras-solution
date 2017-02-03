using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Employee;

namespace Tras.Core.Domain.Distribution
{
    public partial class DispersionRecord : BaseEntity
    {
        public long DispersionRecordId { get; set; }
        public int PersonId { get; set; }
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


        // Navigation Property
        public virtual Person Person { get; set; }
        public virtual ICollection<DispersionItemRecord> DispersionItemRecords { get; set; }

    }
}

