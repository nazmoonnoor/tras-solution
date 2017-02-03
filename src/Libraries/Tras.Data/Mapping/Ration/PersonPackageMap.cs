using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;

namespace Tras.Data.Mapping.Ration
{
    public partial class PersonPackageMap : EntityTypeConfiguration<PersonPackage>
   {
        public PersonPackageMap()
        {
            // primary key
            this.HasKey(p => p.PersonPackageId);
            this.Property(c => c.PersonPackageId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Properties
            this.Property(p => p.PersonId);
            this.Property(p => p.PackageId);
            this.Property(p => p.StartDate).IsRequired().HasColumnName("StartDate");
            this.Property(p => p.EndDate).IsOptional().HasColumnName("EndDate");

            this.ToTable("PersonPackages");

            this.HasRequired(p => p.Person)
                .WithOptional(p => p.PersonPackage);
                

            this.HasRequired(p => p.Package)
                .WithMany(p => p.PersonPackages)
                .HasForeignKey(p => p.PackageId);

        }
    }
}
