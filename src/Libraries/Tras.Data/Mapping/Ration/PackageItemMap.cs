using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;

namespace Tras.Data.Mapping.Ration
{
    public class PackageItemMap: EntityTypeConfiguration<PackageItem>
    {

        public PackageItemMap()
        {
            // Primary Key
            this.HasKey(t => t.PackageItemId);


            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.IsApplicableForBatman).HasColumnName("IsApplicableForBatman");
            // Table & Column Mappings
            this.ToTable("PackageItems");


            // Foreign Key Association 
            this.HasRequired(i => i.RationItem)
                .WithMany(ic => ic.PackageItems)
                .HasForeignKey(i => i.RationItemId);

            this.HasRequired(t => t.Package)
                .WithMany(t => t.PackageItems)
                .HasForeignKey(t => t.PackageId);

        }
    }
}
