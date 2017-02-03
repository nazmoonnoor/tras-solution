using System;

namespace Tras.Services.Process.Dispersion
{
    public class FoodItemScale
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public FoodItem Own { get; set; }
        public FoodItem Spouse { get; set; }
        public FoodItem Minor { get; set; }
        public FoodItem Half { get; set; }
        public FoodItem Adult { get; set; }

        public decimal TotalQuantity
        {
            get
            {
                decimal quantityContainer = 0;

                quantityContainer += (Own != null) ? Own.Quantity : 0;
                quantityContainer += (Spouse != null) ? Spouse.Quantity : 0;
                quantityContainer += (Minor != null) ? Minor.Quantity : 0;
                quantityContainer += (Half != null) ? Half.Quantity : 0;
                quantityContainer += (Adult != null) ? Adult.Quantity : 0;

                return quantityContainer;
            }
        }

        public decimal TotalQuantityInKg
        {
            get
            {
                decimal quantityContainer = 0;

                quantityContainer += (Own != null) ? Own.QuantityInKg : 0;
                quantityContainer += (Spouse != null) ? Spouse.QuantityInKg : 0;
                quantityContainer += (Minor != null) ? Minor.QuantityInKg : 0;
                quantityContainer += (Half != null) ? Half.QuantityInKg : 0;
                quantityContainer += (Adult != null) ? Adult.QuantityInKg : 0;

                return quantityContainer;
            }
        }
        
        public decimal TotalPrice
        {
            get
            {
                decimal priceContainer = 0;

                priceContainer += (Own != null) ? Own.Price : 0;
                priceContainer += (Spouse != null) ? Spouse.Price : 0;
                priceContainer += (Minor != null) ? Minor.Price : 0;
                priceContainer += (Half != null) ? Half.Price : 0;
                priceContainer += (Adult != null) ? Adult.Price : 0;

                return Math.Round(priceContainer, 2);
            }
        }
    }
}