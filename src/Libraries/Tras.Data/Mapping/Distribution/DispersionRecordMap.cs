using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;

namespace Tras.Data.Mapping.Distribution
{
   public partial class DispersionRecordMap:EntityTypeConfiguration<DispersionRecord>
   {
       public DispersionRecordMap()
       {
           //key
           this.HasKey(d => d.DispersionRecordId);
           // properties
           this.Property(d => d.PersonId);
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
           this.ToTable("DispersionRecord");

           // Foreign Key Association
           this.HasRequired(d => d.Person)
               .WithMany(d => d.RationDispersionRecords)
               .HasForeignKey(d => d.PersonId);

       }
    }
}
