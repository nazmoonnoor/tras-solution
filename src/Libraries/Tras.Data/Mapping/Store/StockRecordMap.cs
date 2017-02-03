using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Store;

namespace Tras.Data.Mapping.Store
{
    public partial class StockRecordMap : EntityTypeConfiguration<StockRecord>
   {
        public StockRecordMap()
        {
            //Key
            this.HasKey(s => s.StockRecordId);
            this.Property(s => s.DemandRecordId)
                .IsOptional();
            this.Property(s => s.TransactionType);

            this.Property(s => s.InvoiceNo)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(s => s.ReceivedBy);
            this.Property(s => s.ReceivedDate)
                .IsRequired();
            this.ToTable("StockRecord");
        }
    }
}
