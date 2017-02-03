using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Tras.Core.Domain.Ration;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Ration
{
    public class RationItemCategoryViewModel : IMapFrom<RationItemCategory>
    {
        [Render(ShowForEdit = false)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Category Name")]
        [Display(Prompt = "Category Name")]
        public string CategoryName { get; set; }
    }
}