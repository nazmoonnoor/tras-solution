using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;

namespace Tras.Core.Domain.Store
{
   public partial class DemandItemRecord:BaseEntity
    {
       public long DemandItemRecordId { get; set; }
       public long DemandRecordId { get; set; }
       public int ItemId { get; set; }
       public decimal? OwnQuantity { get; set; }
       public decimal? SpouseQuantity { get; set; }
       public decimal? AdultQuantity { get; set; }
       public decimal? HalfQuantity { get; set; }
       public decimal? MinorQuantity { get; set; }
       public decimal? BatManQuantity { get; set; }

       public virtual DemandRecord DemandRecord { get; set; }
       public virtual RationItem RationItem { get; set; }

    }
}
