using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Ration
{
    public class PersonPackageService : IPersonPackageService
    {
        private readonly IRepository<PersonPackage> _repository;

        public PersonPackageService(IRepository<PersonPackage> repository)
        {
            _repository = repository;
        }

        public PersonPackage InsertPersonPackage(PersonPackage personPackage)
        {
            if(personPackage==null)
                throw new ArgumentNullException("personPackage");
            return _repository.Insert(personPackage);

        }

        public void UpdatePersonPackage(PersonPackage personPackage)
        {
            if (personPackage == null)
                throw new ArgumentNullException("personPackage");
            _repository.Update(personPackage);
        }

        public void DeletePersonPackage(PersonPackage personPackage)
        {
            if (personPackage == null)
                throw new ArgumentNullException("personPackage");
            _repository.Delete(personPackage);
        }

        public PersonPackage GetPersonPackageById(int personPackageId)
        {
            if (personPackageId == 0)
                return null;
            return _repository.GetById(personPackageId);
        }

        public IPagedList<PersonPackage> GetAllPersonPackages(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(p => p.Deleted == false);
            query = query.OrderByDescending(p => p.PackageId).ThenBy(p => p.PersonId);
            var personPackage = new PagedList<PersonPackage>(query,pageIndex,pageSize);
            return personPackage;
        }

        public IEnumerable<PersonPackage> GetPersonPackages()
        {
            return _repository.Table.ToList();
        }

        public PersonPackage GetPackageByPersonId(int personId)
        {
            return _repository.Table.FirstOrDefault(p => p.PersonId == personId && p.Deleted == false);
        }
    }
}
