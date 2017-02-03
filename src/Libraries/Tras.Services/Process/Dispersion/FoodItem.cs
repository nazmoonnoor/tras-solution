using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tras.Services.Process.Dispersion
{
    public class FoodItem
    {
        public string Name { get; set; }

        public decimal Price
        {
            get { return QuantityInKg * PricePerKg; }
        }

        public decimal Quantity {  get; set; }
        public decimal PricePerKg { private get; set; }

        public decimal QuantityInKg
        {
            get { return Quantity>0 ?Quantity / 1000:0; }
        }
    }
    
}
