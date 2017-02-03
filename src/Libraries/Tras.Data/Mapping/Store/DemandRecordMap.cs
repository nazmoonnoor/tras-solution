using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Store;

namespace Tras.Data.Mapping.Store
{
   public partial class DemandRecordMap:EntityTypeConfiguration<DemandRecord>
   {
       public DemandRecordMap()
       {
           //key
           this.HasKey(d => d.DemandRecordId);

           this.Property(d => d.HeadId);
           this.Property(d => d.CategoryId);
           this.Property(d => d.DemandNo)
               .IsRequired()
               .HasMaxLength(50);
           this.Property(d => d.GeneratedBy);
           this.Property(d => d.GeneratedDate)
               .IsRequired();
           this.Property(d => d.OnDemandDate)
               .IsRequired();
           this.Property(d => d.FromDate)
               .IsRequired();
           this.Property(d => d.ToDate)
               .IsRequired();
           this.ToTable("DemandRecord");

           // Foreign Key Association

           this.HasRequired(d => d.RationHead)
               .WithMany(d => d.DemandRecords)
               .HasForeignKey(d => d.HeadId);

           this.HasRequired(d => d.RationItemCategory)
              .WithMany(d => d.DemandRecords)
              .HasForeignKey(d => d.CategoryId);
       }
    }
}
