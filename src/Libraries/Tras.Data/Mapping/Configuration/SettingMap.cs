using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Configuration;

namespace Tras.Data.Mapping.Configuration
{
    public partial class SettingMap : EntityTypeConfiguration<Setting>
    {
        public SettingMap()
        {
            // Primary Key
            this.HasKey(t => t.SettingId);

            // Properties
            this.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Settings");
            this.Property(t => t.SettingId).HasColumnName("SettingId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
        }
    }
}