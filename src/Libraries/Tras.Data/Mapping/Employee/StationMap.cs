using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Employee;

namespace Tras.Data.Mapping.Employee
{
   public partial  class StationMap:EntityTypeConfiguration<Station>
   {
       public StationMap()
       {
           this.HasKey(s => s.StationId);
           // Properties
           this.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(200);
           this.ToTable("Stations");
          
       }
    }
}
