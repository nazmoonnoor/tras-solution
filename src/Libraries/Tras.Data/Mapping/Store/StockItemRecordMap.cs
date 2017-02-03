using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Store;

namespace Tras.Data.Mapping.Store
{
    public partial class StockItemRecordMap:EntityTypeConfiguration<StockItemRecord>
    {
        public StockItemRecordMap()
        {
            //key
            this.HasKey(s => s.StockItemRecordId);
            this.Property(s => s.StockRecordId);
            this.Property(s => s.ItemId);
            this.Property(s => s.Quantity);
            this.ToTable("StockItemRecord");

            //Foreign key association
            this.HasRequired(d => d.StockRecord)
               .WithMany(d => d.StockItemRecords)
               .HasForeignKey(d => d.StockRecordId);

            this.HasRequired(d => d.RationItem)
                .WithMany(d => d.StockItemRecords)
                .HasForeignKey(d => d.ItemId);
        }
    }
}
