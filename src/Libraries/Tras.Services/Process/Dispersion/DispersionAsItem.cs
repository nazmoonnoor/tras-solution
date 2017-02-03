using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Employee;
using Tras.Core.Domain.Ration;

namespace Tras.Services.Process.Dispersion
{
    public class DispersionAsItem
    {
        public Person Person { get; set; }
        public Package Package { get; set; }

        public IList<FoodItemScale> FoodItems { get; set; }

        public decimal GrossPrice
        {
            get
            {
                return FoodItems.Sum(aFoodItem => aFoodItem.TotalPrice);
            }
        }
    }
}