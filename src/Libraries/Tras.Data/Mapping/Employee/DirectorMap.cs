using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Employee;

namespace Tras.Data.Mapping.Employee
{
   public partial class DirectorMap:EntityTypeConfiguration<Director>
   {
       public DirectorMap()
       {
           //primary key
           this.HasKey(d => d.DirectorId);
           // Properties
           this.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(200);
           this.ToTable("Directors");
       }
    }
}
