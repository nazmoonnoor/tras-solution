using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;

namespace Tras.Data.Mapping.Distribution
{
   public partial class MessDispersionRecordMap:EntityTypeConfiguration<MessDispersionRecord>
   {
       public MessDispersionRecordMap()
       {
           //key
           this.HasKey(d => d.MessDispersionRecordId);
           // properties
           this.Property(d => d.MessId);
           this.Property(d => d.TransactionType);
           this.Property(d => d.InvoiceNo)
               .IsRequired()
               .HasMaxLength(50);
           this.Property(d => d.InvoiceCreatedBy);
           this.Property(d => d.DeliveredBy)
               .IsOptional();
           this.Property(d => d.InvoiceDate)
               .IsRequired();
           this.Property(d => d.DeliveredDate)
               .IsOptional();
           this.Property(d => d.NetPrice)
               .IsOptional();
           this.Property(d => d.DaysCount)
               .IsOptional();
           this.Property(d => d.IsDelivered)
               .IsOptional();
           this.Property(d => d.FromDate)
               .IsRequired();
           this.Property(d => d.ToDate)
               .IsOptional();
           this.ToTable("MessDispersionRecord");

           // Foreign Key Association
           this.HasRequired(d => d.Mess)
               .WithMany(d => d.MessDispersionRecords)
               .HasForeignKey(d => d.MessId);
       }
    }
}
