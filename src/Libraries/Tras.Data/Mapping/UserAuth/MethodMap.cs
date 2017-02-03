using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;

namespace Tras.Data.Mapping.UserAuth
{
   public partial class MethodMap: EntityTypeConfiguration<Method>
    {
       public MethodMap()
       {
           // Primary Key
           this.HasKey(m => m.MethodId);

           // Properties
           this.Property(m => m.ModuleName)
               .HasMaxLength(50)
               .IsOptional();
           this.Property(m => m.ControllerName)
              .HasMaxLength(50);
           this.Property(m => m.MethodName)
               .HasMaxLength(50);
           this.Property(m => m.NameToShow)
              .HasMaxLength(50);

           // Table & Column Mappings
           this.ToTable("Methods");
          


       }
    }
}
