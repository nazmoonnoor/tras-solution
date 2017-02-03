using System.Collections.Generic;
using Tras.Services.Process.Dispersion;

namespace Tras.Services.Process.Demand
{
    public class RationBox
    {
        public int TotalNumberOfPeople { get; set; }    
        public string PackageCode { get; set; }
        public IList<FoodItemScale> FoodItems { get; set; }
    }
}
