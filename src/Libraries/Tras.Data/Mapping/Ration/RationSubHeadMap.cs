using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Ration;

namespace Tras.Data.Mapping.Ration
{
    public partial class RationSubHeadMap : EntityTypeConfiguration<RationSubHead>
    {
        public RationSubHeadMap()
        {
            // Primary Key
            this.HasKey(t => t.SubHeadId);

            // Properties
            this.Property(t => t.SubHeadName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RationSubHeads");
            this.Property(t => t.SubHeadId).HasColumnName("SubHeadId");
            this.Property(t => t.HeadId).HasColumnName("HeadId");
            this.Property(t => t.SubHeadName).HasColumnName("SubHeadName");

            // Foreign Key Association 
            this.HasRequired(t => t.Head)
                .WithMany(mt => mt.SubHeads)
                .HasForeignKey(t => t.HeadId);
        }
    }
}
