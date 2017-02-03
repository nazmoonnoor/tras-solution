using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Configuration;

namespace Tras.Data.Mapping.Configuration
{
    public partial class LookupMap : EntityTypeConfiguration<Lookup>
    {
        public LookupMap()
        {
            // Primary Key
            this.HasKey(t => t.LookupId);

            // Properties
            this.Property(s => s.LookupType)
                .IsRequired()
                .HasMaxLength(50);
            
            this.Property(s => s.Key)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Sys_Lookup");
            this.Property(t => t.LookupId).HasColumnName("LookupId");
            this.Property(t => t.LookupType).HasColumnName("LookupType");
            this.Property(t => t.Key).HasColumnName("Key");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Order).HasColumnName("Order");
        }
    }
}