using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Residence;

namespace Tras.Data.Mapping.Residence
{
   public partial class RoomMap:EntityTypeConfiguration<Room>
   {
       public RoomMap()
       {
           //Primary key
           this.HasKey(r => r.RoomId);
           //property
           this.Property(r => r.RoomName)
               .IsRequired()
               .HasMaxLength(100);
           this.Property(r => r.MessId);
           this.ToTable("Rooms");

           // Foreign Key 
           this.HasRequired(r => r.Mess)
               .WithMany(r => r.Rooms)
               .HasForeignKey(r => r.MessId);

       }
    }
}
