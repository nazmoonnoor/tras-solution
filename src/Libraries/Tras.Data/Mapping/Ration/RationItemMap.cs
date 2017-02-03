using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Ration;

namespace Tras.Data.Mapping.Ration
{
    public partial class RationItemMap : EntityTypeConfiguration<RationItem>
    {
        public RationItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemId);

            // Properties
            this.Property(t => t.ItemName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("RationItems");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.ItemName).HasColumnName("ItemName");

            this.Property(t => t.SoldierQty).HasColumnName("SoldierQty");
            this.Property(t => t.GeneralQty).HasColumnName("GeneralQty");
            this.Property(t => t.HalfQty).HasColumnName("HalfQty");
            this.Property(t => t.MinorQty).HasColumnName("MinorQty");

            // Foreign Key Association 
            this.HasRequired(i => i.Category)
                .WithMany(ic => ic.Items)
                .HasForeignKey(i => i.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
