using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;
using Tras.Services.Process.Demand;

namespace Tras.Services.Employee
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public Person InsertPerson(Person person)
        {
            if(person==null)
                throw new ArgumentNullException("person");
            return _personRepository.Insert(person);
        }

        public void UpdatePerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");
            _personRepository.Update(person);
        }

        public void DeletePerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");
            _personRepository.Delete(person);
        }

        public Person GetPersonById(int personId)
        {
            if (personId == 0)
                return null;
            return _personRepository.GetById(personId);
        }

        public IEnumerable<Person> GetPeople()
        {
            return _personRepository.Table.ToList();
        }

        public IPagedList<Person> GetPeople(int pageSize, int pageIndex, string searchText, bool showDeleted = false)
        {
            var query = _personRepository.Table;
            if (!showDeleted)
                query = query.Where(c => c.Deleted == false);
            query = query.OrderByDescending(a => a.PersonId).ThenBy(b => b.FullName);
            var person = new PagedList<Person>(query,pageIndex,pageSize);
            return person;
        }

        public Person GetPersonByNo(string personalNo)
        {
            if (string.IsNullOrWhiteSpace(personalNo))
                return null;
            return _personRepository.Find(m => m.PersonalNo == personalNo);
        }

        public IEnumerable<ManpowerTable> GetManpowerForRegularItemOfSubsidy(int rationHeadId)
        {
            //Subsidy
            var query = _personRepository.Table.Where(p => p.PersonPackage.Package.SubHead.HeadId == rationHeadId);
            
            return query.Select(m => new ManpowerTable
            {
                PersonId = m.PersonId,
                PackageId = (m.PersonPackage != null) ? m.PersonPackage.PackageId : 0,
                PeopleTypeKey = m.PersonTypeKey,
                JobTypeKey = m.JobTypeKey,
                Own = m.FamilyInfo !=null ? m.FamilyInfo.Own : 1,
                BatMan = m.FamilyInfo.BatMan,
                KidsMinor = m.FamilyInfo.KidsMinor,
                KidsHalf = m.FamilyInfo.KidsHalf,
                KidsAdult = m.FamilyInfo.KidsAdult,
                Spouse = m.FamilyInfo.Spouse
            }).ToList();
        }

        public IEnumerable<ManpowerTable> GetManpowerForRegularItemOfFree(int rationHeadId, string solderJobTypeKey)
        {
            // Free Regular Item
            var query = _personRepository.Table.Where(p => p.JobTypeKey==solderJobTypeKey );
            
            return query.Select(m => new ManpowerTable
            {
                PersonId = m.PersonId,
                PackageId = (m.PersonPackage != null) ? m.PersonPackage.PackageId : 0,
                PeopleTypeKey = m.PersonTypeKey,
                JobTypeKey = m.JobTypeKey,
                Own = m.FamilyInfo !=null ? m.FamilyInfo.Own : 1,
                BatMan = 0,
                KidsMinor = 0,
                KidsHalf = 0,
                KidsAdult = 0,
                Spouse = 0
            }).ToList();
        }

        public IEnumerable<ManpowerTable> GetManpowerForFreshAndSpicyItemOfFree(int rationHeadId)
        {
            // 

            var query = _personRepository.Table.Where(p => p.Allotments.LastOrDefault().Active == Active.Y);

            return query.Select(m => new ManpowerTable
            {
                PersonId = m.PersonId,
                PackageId = (m.PersonPackage != null) ? m.PersonPackage.PackageId : 0,
                PeopleTypeKey = m.PersonTypeKey,
                JobTypeKey = m.JobTypeKey,
                Own = m.FamilyInfo != null ? m.FamilyInfo.Own : 1,
                BatMan = 0,
                KidsMinor = 0,
                KidsHalf = 0,
                KidsAdult = 0,
                Spouse = 0
            }).ToList();

            return null;
        }

        public IEnumerable<ManpowerTable> GetManpowerForRegularItemOfNormal(int rationHeadId)
        {
            var query = _personRepository.Table.Where(p => p.PersonPackage.Package.SubHead.HeadId == rationHeadId);

            return query.Select(m => new ManpowerTable
            {
                PersonId = m.PersonId,
                PackageId = (m.PersonPackage != null) ? m.PersonPackage.PackageId : 0,
                PeopleTypeKey = m.PersonTypeKey,
                JobTypeKey = m.JobTypeKey,
                Own = m.FamilyInfo != null ? m.FamilyInfo.Own : 1,
                BatMan = m.FamilyInfo.BatMan,
                KidsMinor = m.FamilyInfo.KidsMinor,
                KidsHalf = m.FamilyInfo.KidsHalf,
                KidsAdult = m.FamilyInfo.KidsAdult,
                Spouse = m.FamilyInfo.Spouse
            }).ToList();

        }
    }
}
