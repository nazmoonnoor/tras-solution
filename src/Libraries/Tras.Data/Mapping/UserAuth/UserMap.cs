using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;

namespace Tras.Data.Mapping.UserAuth
{
   public partial class UserMap:EntityTypeConfiguration<User>
   {
       public UserMap()
       {
           // Primary Key
           this.HasKey(u => u.PersonId);


           //this.Property(u=>u.PersonId)
           //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

           this.Property(u => u.UserName)
               .HasMaxLength(50);
           this.Property(u => u.UserPassword)
               .HasMaxLength(50);
           // Table
           this.ToTable("Users");
           
       }
    }
}
