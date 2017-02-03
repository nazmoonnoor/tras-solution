using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Employee;

namespace Tras.Data.Mapping.Employee
{
    public partial class RankMap:EntityTypeConfiguration<Rank>
    {
        public RankMap()
       {
           //primary key
           this.HasKey(d => d.RankId);
           // Properties
           this.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(200);
           this.ToTable("Ranks");
       }    
    }
}
