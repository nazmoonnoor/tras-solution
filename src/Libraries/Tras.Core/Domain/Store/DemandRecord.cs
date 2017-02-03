using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;

namespace Tras.Core.Domain.Store
{
   public partial class DemandRecord:BaseEntity
    {
       public long DemandRecordId { get; set; }
       public int HeadId { get; set; }// Ration Head ex. free,subsidy,normal
       public int CategoryId { get; set; } // Item Category ration item, fresh item

       public string DemandNo { get; set; }
       public int GeneratedBy { get; set; }
       public DateTime GeneratedDate { get; set; }
       public DateTime OnDemandDate { get; set; }
       public DateTime FromDate { get; set; }
       public DateTime ToDate { get; set; }

       public virtual ICollection<DemandItemRecord> DemandItemRecords { get; set; }
       public virtual RationHead RationHead { get; set; }
       public virtual RationItemCategory RationItemCategory { get; set; }
    }
}
