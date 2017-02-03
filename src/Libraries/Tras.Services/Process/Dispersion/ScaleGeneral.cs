using System.Collections.Generic;

namespace Tras.Services.Process.Dispersion
{
    public class ScaleGeneral : IRationScale
    {
        public List<FoodItem> GetFoodItems(List<FoodPackageItem> packageItems, int days, int numberOfPerson = 1)
        {
            var foodCointaner = new List<FoodItem>();
            foreach (FoodPackageItem packageItem in packageItems)
            {
                var foodItem = GetFoodItem(packageItem,days,numberOfPerson);
                foodCointaner.Add(foodItem);
            }
            return foodCointaner;
        }

        public FoodItem GetFoodItem(FoodPackageItem packageItem, int days, int numberOfPerson = 1)
        {
            return new FoodItem
            {
                Name = packageItem.ItemName,                
                Quantity = packageItem.GeneralQty * days * numberOfPerson ?? 0,
                PricePerKg = packageItem.UnitPricePerKg ?? 0
            };
        }
    }
}