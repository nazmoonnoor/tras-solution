using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;

namespace Tras.Data.Mapping.Distribution
{
   public partial class MessDispersionItemRecordMap:EntityTypeConfiguration<MessDispersionItemRecord>
   {
       public MessDispersionItemRecordMap()
       {
           // Key
           this.HasKey(d => d.MessDispersionItemRecordId);

           //properties
           this.Property(d => d.MessDispersionRecordId);
           this.Property(d => d.ItemId);
           this.Property(d => d.Price);
           this.Property(d => d.Quantity);
           this.ToTable("MessDispersionItemRecord");

           //Foreign key association

           this.HasRequired(d => d.MessDispersionRecord)
               .WithMany(d => d.MessDispersionItemRecords)
               .HasForeignKey(d => d.MessDispersionRecordId);

           this.HasRequired(d => d.RationItem)
               .WithMany(d => d.MessDispersionItemRecords)
               .HasForeignKey(d => d.ItemId);
       }
    }
}
