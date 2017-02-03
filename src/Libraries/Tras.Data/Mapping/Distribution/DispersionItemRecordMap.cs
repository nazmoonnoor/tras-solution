using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;

namespace Tras.Data.Mapping.Distribution
{
    public partial class DispersionItemRecordMap : EntityTypeConfiguration<DispersionItemRecord>
   {
       public DispersionItemRecordMap()
       {
           // Key
           this.HasKey(d => d.DispersionItemRecordId);

           //properties
           this.Property(d => d.DispersionRecordId);
           this.Property(d => d.ItemId);
           this.Property(d => d.Price);
           this.Property(d => d.Quantity);
           this.ToTable("DispersionItemRecord");

           //Foreign key association

           this.HasRequired(d => d.DispersionRecord)
               .WithMany(d => d.DispersionItemRecords)
               .HasForeignKey(d => d.DispersionRecordId);

           this.HasRequired(d => d.RationItem)
               .WithMany(d => d.DispersionItemRecords)
               .HasForeignKey(d => d.ItemId);
       }
    }
}
