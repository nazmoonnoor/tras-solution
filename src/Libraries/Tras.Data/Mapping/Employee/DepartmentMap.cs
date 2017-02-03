using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Employee;

namespace Tras.Data.Mapping.Employee
{
    public partial class DepartmentMap : EntityTypeConfiguration<Department>
   {
        public DepartmentMap()
        {
            //primary key
            this.HasKey(d => d.DepartmentId);
            // Properties
            this.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);
            this.ToTable("Departments");
        }
    }
}
