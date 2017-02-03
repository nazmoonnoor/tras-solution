using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Residence
{
    public partial class Room:BaseEntity
    {
        public int RoomId { get; set; }
        public int MessId { get; set; }
        public string RoomName { get; set; }

        public virtual Mess Mess { get; set; }
        public virtual ICollection<Allotment> Allotments { get; set; }
    }
}
