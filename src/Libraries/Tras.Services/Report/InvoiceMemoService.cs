using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Report;
using Tras.Data;

namespace Tras.Services.Report
{
    public class InvoiceMemoService 
    {
        public IEnumerable<InvoiceMemo> PaymentRationInvoice(int personId,string invoiceNo)
        {
            using (var context = new TrasObjectContext())
            {

                var param1 = new SqlParameter("@QueryOption", 1);
                var param2 = new SqlParameter("@PersonId", personId);
                var param3 = new SqlParameter("@InvoiceNo", invoiceNo);

                const string query = "EXEC rptInvoice @QueryOption,@PersonId,@InvoiceNo";
                var data = context.Database.SqlQuery<InvoiceMemo>(query, param1,param2,param3).ToList();

                return data;
            }
        }
        
    }
}
