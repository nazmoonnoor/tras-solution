using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Ration;

namespace Tras.Data.Mapping.Ration
{
    public partial class PackageMap : EntityTypeConfiguration<Package>
    {
        public PackageMap()
        {
            // Primary Key
            this.HasKey(t => t.PackageId);

            // Properties
            this.Property(t => t.PackageCode)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Packages");
            this.Property(t => t.PackageId).HasColumnName("PackageId");
            this.Property(t => t.PackageCode).HasColumnName("PackageCode");
            this.Property(t => t.SubHeadId).HasColumnName("SubHeadId");
            
            
            // Foreign Key Association 
      
            this.HasRequired(p => p.SubHead)
                .WithMany(rt => rt.Packages)
                .HasForeignKey(p => p.SubHeadId);
        }
    }
}
