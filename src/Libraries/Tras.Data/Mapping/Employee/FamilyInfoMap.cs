using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Employee;

namespace Tras.Data.Mapping.Employee
{
    public partial class FamilyInfoMap : EntityTypeConfiguration<FamilyInfo>
    {
        public FamilyInfoMap()
        {
            //Has key

            // Properties
            this.Property(f => f.PersonId);
            this.Property(f => f.Own);
            this.Property(f => f.Spouse);
            this.Property(f => f.KidsMinor);
            this.Property(f => f.KidsHalf);
            this.Property(f => f.KidsAdult);
            this.Property(f => f.BatMan);
            this.ToTable("FamilyInfos");

            // Foreignkey 
        }
    }
}
