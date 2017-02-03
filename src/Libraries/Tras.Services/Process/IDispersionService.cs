using System.Collections.Generic;
using Tras.Services.Process.Dispersion;

namespace Tras.Services.Process
{
    public interface IDispersionService
    {
        DispersionAsScale CalculateByScales(int personId, bool isBatMan, int numberOfDays);
        DispersionAsItem CalculateByItems(int personId, int numberOfDays);

        IList<FoodItemScale> GetFoodItemScale(List<IDependant> dependants, List<FoodPackageItem> foodPackageItems,
            int numberOfDays);
    }
}