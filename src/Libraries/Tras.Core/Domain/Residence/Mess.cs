using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;

namespace Tras.Core.Domain.Residence
{
    public partial class Mess:BaseEntity
    {
        public int MessId { get; set; }
        public string MessName { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public virtual ICollection<MessDispersionRecord> MessDispersionRecords { get; set; }
    }
}
