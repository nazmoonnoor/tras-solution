using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Core.Domain.Employee
{
   public partial class EducationalInfo:BaseEntity
    {
       public int EducationalInfoId { get; set; }
       public int PersonId { get; set; }
       public string EducationTypeKey { get; set; }// Use common enum Table
       public string ExaminationName { get; set; } // ND
       public int PassingYear { get; set; } // ND
       public DateTime FromDate { get; set; }
       public DateTime ToDate { get; set; }
       public string Result { get; set; }
       public string Institutionname { get; set; }
       public string BoardName { get; set; }
       public string Remarks { get; set; }

       public virtual Person Person { get; set; }

    }
}
