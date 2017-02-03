using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;

namespace Tras.Data.Mapping.UserAuth
{
   public partial class RoleMap:EntityTypeConfiguration<Role>
   {
       public RoleMap()
       {
           // Primary Key
           this.HasKey(r => r.RoleId);

           this.Property(r => r.RoleName)
               .HasMaxLength(50);
           this.Property(r => r.Remarks)
               .HasMaxLength(200)
               .IsOptional();

           // Table  Mappings
           this.ToTable("Roles");

       }
    }
}
