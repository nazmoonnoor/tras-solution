using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Tras.Core.Domain.Ration;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Ration
{
    public class RationItemViewModel: IMapFrom<RationItem>
    {
        [Render(ShowForEdit = false)]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        
        
        [DisplayName("Category")]
        public string CategoryCategoryName { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Item Name")]
        [Display(Prompt = "Item Name")]
        public string ItemName { get; set; }

        [DisplayName("Soldier Quantity")]
        [Range(0,999)]
     
        public decimal? SoldierQty { get; set; }

        [DisplayName("General Quantity")]
        [DataType(DataType.Text)]
        [Range(0, 999)]
      
        public decimal? GeneralQty { get; set; }

        [DisplayName("Half Quantity")]
        [DataType(DataType.Text)]
        [Range(0, 999)]

        public decimal? HalfQty { get; set; }
        [AdditionalMetadata("MaxLength", 3)]
        [DisplayName("Minor Quantity")]
        [DataType(DataType.Text)]
        [Range(0, 999)]
   
        public decimal? MinorQty { get; set; }
    }
}