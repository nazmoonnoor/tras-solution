using System.Collections.Generic;
using System.Linq;

namespace Tras.Services.Process.Dispersion
{
    public class DispersionAsScale
    {   
        //DTO           
        public decimal GrossQuantity { get; set; }
        public decimal GrossPrice { get; set; }
        public Dictionary<string, List<FoodItem>> FoodItems { get; set; }
    }
}
