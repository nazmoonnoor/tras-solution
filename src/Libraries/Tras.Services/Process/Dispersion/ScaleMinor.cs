﻿using System.Collections.Generic;

namespace Tras.Services.Process.Dispersion
{
    public class ScaleMinor : IRationScale
    {
        public List<FoodItem> GetFoodItems(List<FoodPackageItem> rationItems, int days, int numberOfPerson = 1)
        {
            var foodCointaner = new List<FoodItem>();

            foreach (FoodPackageItem packageItem in rationItems)
            {
                var aFoodItem = GetFoodItem(packageItem, days, numberOfPerson);
                foodCointaner.Add(aFoodItem);
            }
            return foodCointaner;
        }

        public FoodItem GetFoodItem(FoodPackageItem packageItem, int days, int numberOfPerson = 1)
        {
            return new FoodItem
            {
                Name = packageItem.ItemName,
                Quantity = packageItem.MinorQty * days * numberOfPerson ?? 0,
                PricePerKg = packageItem.UnitPricePerKg??0
            };
        }
    }
}
