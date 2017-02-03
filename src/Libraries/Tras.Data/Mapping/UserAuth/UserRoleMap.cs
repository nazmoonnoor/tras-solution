using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;

namespace Tras.Data.Mapping.UserAuth
{
   public partial class UserRoleMap:EntityTypeConfiguration<UserRole>
   {
       public UserRoleMap()
       {
           // Primary Key
           this.HasKey(ur => ur.UserRoleId);

           // Table
           this.ToTable("UserRoles");

           // Foreign Key Association
           this.HasRequired(ur => ur.Roles)
               .WithMany(ur => ur.UserRoles)
               .HasForeignKey(ur => ur.RoleId);

           this.HasRequired(ur => ur.Users)
               .WithMany(ur => ur.UserRoles)
               .HasForeignKey(ur => ur.UserId);
       }
    }
}
