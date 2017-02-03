using System.Collections.Generic;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Services.Process.Demand;
using Tras.Services.Process.Dispersion;

namespace Tras.Services.Ration
{
    public interface IPackageItemService
    {
        PackageItem InsertPackageItem(PackageItem packageItem);
        void UpdatePackageItem(PackageItem packageItem);
        void DeletePackageItem(PackageItem packageItem);
        PackageItem GetPackageItemById(int packageItemId);
        IEnumerable<PackageItem> GetPackageItems();
        IPagedList<PackageItem> GetPackageItems(int pageSize, int pageIndex, bool showDeleted = false);

        IEnumerable<PackageItem> GetPackageItemsByPackageId(int packageId, bool isBatman = false);
        List<FoodPackageItem> GetFoodPackageItemsByPackageId(int packageId, bool isBatman);
        List<FoodPackage> GetPackageItems(int rationSubHeadId, int itemCategoryId);

        IList<PackageItem> GetPackageItemsForCivil();

    }
}
