namespace Tras.Services.Process.Dispersion
{
    public class FoodPackageItem
    {
        //DTO
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; } /*RationItemCategory.*/
        public decimal? SoldierQty { get; set; }
        public decimal? GeneralQty { get; set; }
        public decimal? HalfQty { get; set; }
        public decimal? MinorQty { get; set; }
        public decimal? UnitPricePerKg { get; set; }
    }
}
