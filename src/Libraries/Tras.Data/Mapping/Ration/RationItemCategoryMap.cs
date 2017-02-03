using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Ration;

namespace Tras.Data.Mapping.Ration
{
    public partial class RationItemCategoryMap : EntityTypeConfiguration<RationItemCategory>
    {
        public RationItemCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryId);

            // Properties
            this.Property(t => t.CategoryName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("RationItemCategories");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
        }
    }
}
