using System.Collections.Generic;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;

namespace Tras.Services.Ration
{
   public interface IPackageService
    {
       Package InsertPackage(Package package);
       void UpdatePackage(Package package);
       void DeletePackage(Package package);
       Package GetPackageById(int packageId);
       IEnumerable<PackageItem> GetPackageItemsById(int packageId);
       IEnumerable<Package> GetPackages();
       IPagedList<Package> GetPackages(int pageSize, int pageIndex, bool showDeleted = false);

       IEnumerable<Package> GetPackageByRationSubHead(int rationSubHeadId);


    }
}
