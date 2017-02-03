using System.Collections.Generic;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;

namespace Tras.Services.Ration
{
   public interface IPersonPackageService
    {
       PersonPackage InsertPersonPackage(PersonPackage personPackage);
       void UpdatePersonPackage(PersonPackage personPackage);
       void DeletePersonPackage(PersonPackage personPackage);
       PersonPackage GetPersonPackageById(int personPackageId);
       IPagedList<PersonPackage> GetAllPersonPackages(int pageSize, int pageIndex, bool showDeleted = false);
       IEnumerable<PersonPackage> GetPersonPackages();

       PersonPackage GetPackageByPersonId(int personId);
    }
}
