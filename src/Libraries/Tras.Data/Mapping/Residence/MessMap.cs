using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Residence;

namespace Tras.Data.Mapping.Residence
{
   public partial class MessMap:EntityTypeConfiguration<Mess>
   {
       public MessMap()
       {
           //primary key
           this.HasKey(m => m.MessId);
           this.Property(m=>m.MessName)
               .IsRequired()
               .HasMaxLength(100);
           this.ToTable("Messes");

       }
    }
}
