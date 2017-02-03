using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Store;

namespace Tras.Data.Mapping.Store
{
    public partial class DemandItemRecordMap : EntityTypeConfiguration<DemandItemRecord>
   {
        public DemandItemRecordMap()
        {
            // key
            this.HasKey(d => d.DemandItemRecordId);
            this.Property(d => d.DemandRecordId);
            this.Property(d => d.ItemId);
            this.Property(d => d.OwnQuantity);
            this.Property(d => d.SpouseQuantity);
            this.Property(d => d.AdultQuantity);
            this.Property(d => d.HalfQuantity);
            this.Property(d => d.MinorQuantity);
            this.Property(d => d.BatManQuantity);


            this.ToTable("DemandItemRecord");

            //Foreign key association
            this.HasRequired(d => d.DemandRecord)
               .WithMany(d => d.DemandItemRecords)
               .HasForeignKey(d => d.DemandRecordId);

            this.HasRequired(d => d.RationItem)
                .WithMany(d => d.DemandItemRecords)
                .HasForeignKey(d => d.ItemId);
        }
    }
}
