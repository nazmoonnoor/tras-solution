using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Ration;

namespace Tras.Data.Mapping.Ration
{
    public partial class RationHeadMap : EntityTypeConfiguration<RationHead>
    {
        public RationHeadMap()
        {
            // Primary Key
            this.HasKey(t => t.HeadId);

            // Properties
            this.Property(t => t.HeadName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RationHeads");
            this.Property(t => t.HeadId).HasColumnName("HeadId");
            this.Property(t => t.HeadName).HasColumnName("HeadName");
        }
    }
}
