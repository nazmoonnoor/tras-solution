using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Report
{
    public class InvoiceMemo
    {
        public int PersonId { get; set; }
        public string PersonalNo { get; set; }
        public string FullName { get; set; }
        public string RankName { get; set; }
        public string DirectorateName { get; set; }
        public string Category { get; set; }
        public string PeopleType { get; set; }
        public int Own { get; set; }
        public int Spouse { get; set; }
        public int KidsMinor { get; set; }
        public int KidsHalf { get; set; }
        public int KidsAdult { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string ItemName { get; set; }
    }
}
