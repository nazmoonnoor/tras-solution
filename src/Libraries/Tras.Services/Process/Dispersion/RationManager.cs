using System;
using System.Collections.Generic;

namespace Tras.Services.Process.Dispersion
{
    public class RationManager
    {
        public static List<FoodItem> CalculateForItems(IDependant dependent, int numberOfDays, List<FoodPackageItem> foodPackageItems)
        {
            if (dependent != null && foodPackageItems.Count > 0)
            {
                return GetScaleFor(dependent).GetFoodItems(foodPackageItems, numberOfDays, dependent.GetNumberOf());
            }

            return new List<FoodItem>();
        }

        public static FoodItem CalculateForItem(IDependant dependent, int numberOfDays, FoodPackageItem foodPackageItem)
        {
            if (dependent != null)
            {
                return GetScaleFor(dependent).GetFoodItem(foodPackageItem, numberOfDays, dependent.GetNumberOf());
            }

            return new FoodItem
            {
                Name = foodPackageItem.ItemName,
                Quantity = 0
                
            };
        }

       

        private static IRationScale GetScaleFor(IDependant dependent)
        {
            var scaleFactory = new ScaleFactory();

            return scaleFactory.CreateInstance(dependent.ScaleType.Name.ToLower());
        }

    }
}
