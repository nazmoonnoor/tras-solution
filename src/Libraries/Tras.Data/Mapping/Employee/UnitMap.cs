using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Employee;

namespace Tras.Data.Mapping.Employee
{
   public partial class UnitMap:EntityTypeConfiguration<Unit>
   {
       public UnitMap()
       {
           //primary key
           this.HasKey(d => d.UnitId);
           // Properties
           this.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(200);
           this.ToTable("Units");
       }
    }
}
