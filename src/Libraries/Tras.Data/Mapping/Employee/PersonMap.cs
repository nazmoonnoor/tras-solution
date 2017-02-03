using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tras.Core.Domain.Employee;

namespace Tras.Data.Mapping.Employee
{
    public partial class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            this.HasKey(a => a.PersonId);

            this.Property(c => c.PersonId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Properties
            this.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(200);
            this.Property(a => a.PersonalNo)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(a => a.GenderKey)
                .IsRequired();
            this.Property(a => a.StdP1No)
                .IsOptional()
                .HasMaxLength(100);
            this.Property(a => a.PersonTypeKey);
            this.Property(a => a.CategoryKey);
            this.Property(a => a.UnitId);
            this.Property(a => a.JobTypeKey);

            this.Property(a => a.DepartmentId);
            this.Property(a => a.DirectorId);
            this.Property(a => a.MaritalStatusKey);
            this.Property(a => a.JoiningDate);
            this.Property(a => a.StdP1NoDate);
            this.ToTable("Person");

            // Foreign Key Association 


            this.HasOptional(c => c.Unit)
                .WithMany(c => c.Person)
                .HasForeignKey(c => c.UnitId);
            this.HasOptional(c => c.Department)
               .WithMany(c => c.Person)
               .HasForeignKey(c => c.DepartmentId);
            this.HasRequired(c => c.Director)
                .WithMany(c => c.Person)
                .HasForeignKey(c => c.DirectorId);
            this.HasRequired(c => c.Rank)
                .WithMany(c => c.Person)
                .HasForeignKey(c => c.RankId);
            // Foreign Key
            this.HasOptional(f => f.FamilyInfo)
                .WithRequired(f => f.Person);

            this.HasOptional(u => u.User)
                .WithRequired(u => u.Person);

            //Station
            this.HasOptional(c => c.Station)
               .WithMany(c => c.Persons)
               .HasForeignKey(c => c.StationId);


        }
    }
}
