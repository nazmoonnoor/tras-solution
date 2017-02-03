using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;

namespace Tras.Data.Mapping.UserAuth
{
   public partial class RoleMethodMap:EntityTypeConfiguration<RoleMethod>
   {
       public RoleMethodMap()
       {
           // primary key
           this.HasKey(rm => rm.RoleMethodId);

           // Properties
           // Table & Column Mappings
           this.ToTable("RoleMethods");
           //Foreign Key Association

           this.HasRequired(mr => mr.Roles)
               .WithMany(mr => mr.RoleMethods)
               .HasForeignKey(mr => mr.RoleId);

           this.HasRequired(mr => mr.Methods)
               .WithMany(mr => mr.RoleMethods)
               .HasForeignKey(mr => mr.MethodId);


       }
    }
}
