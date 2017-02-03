using System.Collections.Generic;

namespace Tras.Core.Domain.Ration
{
    public partial class Package : BaseEntity
    {
        public int PackageId { get; set; }
        public string PackageCode { get; set; }
        public int SubHeadId { get; set; }


        public virtual RationSubHead SubHead { get; set; }
        public virtual ICollection<PackageItem> PackageItems { get; set; }
        public virtual ICollection<PersonPackage> PersonPackages { get; set; }
    }
}
