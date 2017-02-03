using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Services.Employee;
using Tras.Services.Process.Dispersion;
using Tras.Services.Ration;


namespace Tras.Services.Process
{
    public class DispersionService : IDispersionService
    {
        private readonly IPersonService _personService;
        private readonly IPersonPackageService _personPackageService;
        private readonly IPackageItemService _packageItemService;
        public Person Person { get; set; }

        public DispersionService(IPersonService personService, IPersonPackageService personPackageService, IPackageItemService packageItemService)
        {
            _personService = personService;
            _personPackageService = personPackageService;
            _packageItemService = packageItemService;
        }

        public DispersionAsScale CalculateByScales(int personId, bool isBatMan, int numberOfDays)
        {
            if (personId < 1)
            {
                return null;
            }

            this.Person = _personService.GetPersonById(personId);

            var package = _personPackageService.GetPackageByPersonId(personId);
            var packageId = package != null ? package.PackageId : 0;
            if (packageId < 1)
            {
                return null;
            }

            var dependants = GetDependants();
            var foodPackageItems = GetFoodPackageItems(packageId);

            var calculateFoodItems = dependants.ToDictionary(d => d.GetType().Name,
                    d => RationManager.CalculateForItems(d, numberOfDays, foodPackageItems));

            var dispersion = new DispersionAsScale
            {
                FoodItems = calculateFoodItems,
                GrossPrice = 0,
                GrossQuantity = 0
            };

            foreach (var aFoodItem in dispersion.FoodItems.SelectMany(item => item.Value))
            {
                dispersion.GrossQuantity += aFoodItem.QuantityInKg;
                dispersion.GrossPrice += aFoodItem.Price;
            }

            return dispersion;
        }

        public DispersionAsItem CalculateByItems(int personId, int numberOfDays)
        {
            if (personId < 1)
            {
                return null;
            }

            this.Person = _personService.GetPersonById(personId);

            var package = _personPackageService.GetPackageByPersonId(personId);
            var packageId = package != null ? package.PackageId : 0;
            if (package == null)
            {
                return null;
            }
            
            var dependants = GetDependants();
            var foodPackageItems = GetFoodPackageItems(packageId);

            if (this.Person.FamilyInfo.BatMan > 0)
            {
                var foodPackageItemsForBatman = GetFoodPackageItemsForBatman(packageId);
            }
            var dispersion = new DispersionAsItem
            {
                Person = this.Person,
                Package = package.Package,
                FoodItems = GetFoodItemScale(dependants, foodPackageItems, numberOfDays)
            };
            return dispersion;
        }

        #region private methods

        private List<IDependant> GetDependants()
        {
            if (this.Person == null)
            {
                return null;
            }
            
            var dependants = new List<IDependant>();

            if (this.Person.FamilyInfo.BatMan>0)
            {
                dependants.Add(new BatMan()
                {
                    NumberOf = this.Person.FamilyInfo.BatMan
                });
                return dependants;
            }

            if (this.Person.FamilyInfo != null)
            {
                dependants.Add(new Spouse()
                {
                    NumberOf = this.Person.FamilyInfo.Spouse
                });
                dependants.Add(new KidsAdult()
                {
                    NumberOf = this.Person.FamilyInfo.KidsAdult
                });
                dependants.Add(new KidsHalf()
                {
                    NumberOf = this.Person.FamilyInfo.KidsHalf
                });
                dependants.Add(new KidsMinor()
                {
                    NumberOf = this.Person.FamilyInfo.KidsMinor
                });
            }
            else
            {
                throw new ApplicationException("familyInfo Not Found");
            }

            if (!IsEligibleForOwnRation(this.Person.FamilyInfo))
            {
                return dependants;
            }

            if (this.Person.CategoryKey != AppConstant.PersonCategory.Officer.ToString())
            {
                dependants.Add(new OfficerSelf { NumberOf = 1 });
            }
            else if (this.Person.CategoryKey == AppConstant.PersonCategory.Soldier.ToString())
            {
                dependants.Add(new SoldierSelf { NumberOf = 1 });
            }

            return dependants;
        }

        private List<FoodPackageItem> GetFoodPackageItems(int packageId)
        {
            return _packageItemService.GetFoodPackageItemsByPackageId(packageId, false);
        }

        private List<FoodPackageItem> GetFoodPackageItemsForBatman(int packageId)
        {
            return _packageItemService.GetFoodPackageItemsByPackageId(packageId, true);
        }

        private bool IsEligibleForOwnRation(FamilyInfo familyInfo)
        {
            //if the solder or officer went to mission then they will not get ration for them self.
            return familyInfo.Own.Equals(1);
        }

        public IList<FoodItemScale> GetFoodItemScale(List<IDependant> dependants, List<FoodPackageItem> foodPackageItems, int numberOfDays)
        {
            var foodItemScales = new List<FoodItemScale>();
            foreach (var item in foodPackageItems)
            {
                var foodItem = new FoodItemScale
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    Spouse = RationManager.CalculateForItem(dependants.FirstOrDefault(d => d.GetType().Name == typeof(Spouse).Name), numberOfDays, item),
                    Adult = RationManager.CalculateForItem(dependants.FirstOrDefault(d => d.GetType().Name == typeof(KidsAdult).Name), numberOfDays, item),
                    Half = RationManager.CalculateForItem(dependants.FirstOrDefault(d => d.GetType().Name == typeof(KidsHalf).Name), numberOfDays, item),
                    Minor = RationManager.CalculateForItem(dependants.FirstOrDefault(d => d.GetType().Name == typeof(KidsMinor).Name), numberOfDays, item),
                    Own = RationManager.CalculateForItem(dependants.FirstOrDefault(d=> d.GetType().Name == typeof(OfficerSelf).Name || d.GetType().Name== typeof(SoldierSelf).Name),numberOfDays,item)
                };
                foodItemScales.Add(foodItem);
            }

            return foodItemScales;
        }

        #endregion
    }
}
