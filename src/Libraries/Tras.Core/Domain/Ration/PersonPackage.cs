using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tras.Core.Domain.Employee;

namespace Tras.Core.Domain.Ration
{
    public partial class PersonPackage : BaseEntity
    {
        //[Key, ForeignKey("Person")]
        public int PersonPackageId { get; set; }
        public int PersonId { get; set; }
        public int PackageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsApproved { get; set; }

        public virtual Person Person { get; set; }
        public virtual Package Package { get; set; }

    }
}
