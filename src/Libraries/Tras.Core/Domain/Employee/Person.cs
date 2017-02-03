using System;
using System.Collections.Generic;
using Tras.Core.Domain.Ration;
using Tras.Core.Domain.Distribution;
using Tras.Core.Domain.Residence;
using Tras.Core.Domain.UserAuth;

namespace Tras.Core.Domain.Employee
{
    public partial class Person : BaseEntity
    {
        public int PersonId { get; set; }
        public string PersonalNo { get; set; }
        public string PersonTypeKey { get; set; } //Army or civil from lookup PERSON_TYPE
        public string CategoryKey { get; set; }
        public string FullName { get; set; }
        public DateTime JoiningDate { get; set; }
        public int? DepartmentId { get; set; }
        public int RankId { get; set; }
        public int DirectorId { get; set; }
        public string StdP1No { get; set; }
        public DateTime StdP1NoDate { get; set; }
        public string FamilyTypeKey { get; set; }
        public string GenderKey { get; set; }
        public string MaritalStatusKey { get; set; }
        public int? UnitId { get; set; }
        public string JobTypeKey { get; set; } //JOB_TYPE : posted,Attested,Getting Ration,Mission
        public byte[] Photo { get; set; }

        public string MobileNo { get; set; }
        public int? StationId { get; set; }



        // Navigation Property
        public virtual Department Department { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual Director Director { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual User User { get; set; }
        public virtual PersonPackage PersonPackage { get; set; }
        public virtual ICollection<DispersionRecord>  RationDispersionRecords { get; set; }
        public virtual FamilyInfo FamilyInfo { get; set; }
        public virtual Station Station { get; set; }
        public virtual ICollection<Allotment> Allotments { get; set; }

        
    }
}