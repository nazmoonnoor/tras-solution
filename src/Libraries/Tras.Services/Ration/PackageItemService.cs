using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;
using Tras.Services.Process.Demand;
using Tras.Services.Process.Dispersion;

namespace Tras.Services.Ration
{
    public class PackageItemService : IPackageItemService
    {
        private readonly IRepository<PackageItem> _packageItemRepository;
        private readonly IPackageService _packageService;
        private readonly IRationSubHeadService _subHeadService;

        public PackageItemService(IRepository<PackageItem> packageItemRepository, IPackageService packageService,IRationSubHeadService rationSubHeadService)
        {
            _packageItemRepository = packageItemRepository;
            _packageService = packageService;
            _subHeadService = rationSubHeadService;
        }

        public PackageItem InsertPackageItem(PackageItem packageItem)
        {
            if (packageItem == null)
                throw new ArgumentNullException("packageItem");
            return _packageItemRepository.Insert(packageItem);
        }

        public void UpdatePackageItem(PackageItem packageItem)
        {
            if (packageItem == null)
                throw new ArgumentNullException("packageItem");
            packageItem.LastUpdatedDate = DateTime.Now;
            _packageItemRepository.Update(packageItem);
        }

        public void DeletePackageItem(PackageItem packageItem)
        {
            if (packageItem == null)
                throw new ArgumentNullException("packageItem");
            packageItem.LastUpdatedDate = DateTime.Now;
            _packageItemRepository.Delete(packageItem);
        }

        public PackageItem GetPackageItemById(int packageItemId)
        {
            if (packageItemId == 0)
                return null;
            return _packageItemRepository.GetById(packageItemId);
        }

        public IEnumerable<PackageItem> GetPackageItems()
        {
            return _packageItemRepository.Table.ToList();
        }

        public IPagedList<PackageItem> GetPackageItems(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _packageItemRepository.Table;
            if (!showDeleted)
                query = query.Where(r => r.Deleted == false);
            query = query.OrderByDescending(r => r.PackageId).ThenBy(r => r.RationItemId);
            var packageItems = new PagedList<PackageItem>(query, pageIndex, pageSize);
            return packageItems;
        }
        
        public IEnumerable<PackageItem> GetPackageItemsByPackageId(int packageId, bool isBatman = false)
        {
            if (packageId < 1)
            {
                return null;
            }

            if (!isBatman)
            {
                return _packageItemRepository.Table.Where(it => it.PackageId == packageId);
            }

            return PackageItemsForBatManByPackageId(packageId);
        }

        private IEnumerable<PackageItem> PackageItemsForBatManByPackageId(int packageId)
        {
            IList<PackageItem> batManPackageItems = new List<PackageItem>();

            var packageItems = _packageItemRepository.Table.Where(it => it.PackageId == packageId && it.IsApplicableForBatman).ToList();
            var packageItemsForCivilian = GetPackageItemsForCivil();

            foreach (var packageItem in packageItems)
            {
                PackageItem tmPackageItem = packageItem;
                var civilPackageItem = packageItemsForCivilian.SingleOrDefault(it => it.RationItemId == packageItem.RationItemId);
                if (civilPackageItem != null)
                    tmPackageItem.Price = civilPackageItem.Price;
                batManPackageItems.Add(tmPackageItem);

            }
            return batManPackageItems.AsEnumerable();
        }

        public List<FoodPackageItem> GetFoodPackageItemsByPackageId(int packageId, bool isBatman)
        {
            var rationItemList = GetPackageItemsByPackageId(packageId, isBatman);

            var foodPackageItemList = new List<FoodPackageItem>();
            if (rationItemList != null)
            {
                foreach (var rationItem in rationItemList)
                {
                    if (rationItem.RationItem != null)
                    {
                        FoodPackageItem foodItem = new FoodPackageItem
                        {
                            ItemId = rationItem.RationItem.ItemId,
                            ItemName = rationItem.RationItem.ItemName,
                            CategoryName = rationItem.RationItem.Category.CategoryName,
                            GeneralQty = rationItem.RationItem.GeneralQty,
                            HalfQty = rationItem.RationItem.HalfQty,
                            MinorQty = rationItem.RationItem.MinorQty,
                            SoldierQty = rationItem.RationItem.SoldierQty,
                            UnitPricePerKg = rationItem.Price
                        };
                        foodPackageItemList.Add(foodItem);
                    }
                }
            }
            return foodPackageItemList;
        }

        public List<FoodPackage> GetPackageItems(int rationSubHeadId, int itemCategoryId)
        {
            //By RationSubHead
            //By ItemCategory
            List<FoodPackage> foodPackageList = null;

            var packages = _packageService.GetPackageByRationSubHead(rationSubHeadId);
            if (packages == null || !packages.Any()) return foodPackageList;
            
            foodPackageList = new List<FoodPackage>();
            foreach (var package in packages)
            {
                var foodPackage = new FoodPackage
                {
                    PackageId = package.PackageId,
                    PackageCode = package.PackageCode,
                    SubHeadId = package.SubHeadId,
                    SubHeadName = package.SubHead.SubHeadName,
                    Items = new List<FoodPackageItem>()
                };

                foreach (var item in package.PackageItems)
                {
                    if (item.RationItem.CategoryId == itemCategoryId)
                    {
                        var foodItem = new FoodPackageItem
                        {
                            ItemId = item.RationItem.ItemId,
                            ItemName = item.RationItem.ItemName,
                            CategoryName = item.RationItem.Category.CategoryName,
                            GeneralQty = item.RationItem.GeneralQty,
                            HalfQty = item.RationItem.HalfQty,
                            MinorQty = item.RationItem.MinorQty,
                            SoldierQty = item.RationItem.SoldierQty,
                            UnitPricePerKg = item.Price
                        };

                        foodPackage.Items.Add(foodItem);
                    }
                }
                foodPackageList.Add(foodPackage);

            }


            return foodPackageList;
        }

        public IList<PackageItem> GetPackageItemsForCivil()
        {
            //"Normal For Civilian"
            int subHeadId =_subHeadService.GetSubHeadIdForCivilian();

            return _packageItemRepository.Table.Where(p => p.Package.SubHeadId == subHeadId).ToList();



        }
    }
}
