using System.Collections.Generic;

namespace Tras.Services.Process.Dispersion
{
    public interface IRationScale
    {
        List<FoodItem> GetFoodItems(List<FoodPackageItem> rationItems, int numberOfDays, int numberOfPerson = 1);
        FoodItem GetFoodItem(FoodPackageItem packageItem, int days, int numberOfPerson = 1);
    }
}