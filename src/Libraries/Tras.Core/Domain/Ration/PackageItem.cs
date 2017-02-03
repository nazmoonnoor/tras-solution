namespace Tras.Core.Domain.Ration
{
    public class PackageItem : BaseEntity
    {
        public int PackageItemId { get; set; }
        public int RationItemId { get; set; }
        public int PackageId { get; set; }
        public decimal? Price { get; set; }
        public bool IsApplicableForBatman { get; set; }
        
        public virtual RationItem RationItem { get; set; }
        public virtual Package Package { get; set; }
    }
}
