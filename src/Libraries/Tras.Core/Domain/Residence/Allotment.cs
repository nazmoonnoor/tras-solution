using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Employee;

namespace Tras.Core.Domain.Residence
{
    public partial class Allotment:BaseEntity
    {
        public int AllotmentId { get; set; }
        public int PersonId { get; set; }
        public int RoomId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Person Person { get; set; }
       

        public virtual Room Room { get; set; }
    }
}
