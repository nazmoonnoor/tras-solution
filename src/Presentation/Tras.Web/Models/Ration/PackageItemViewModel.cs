using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Tras.Core.Domain.Ration;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Ration
{
    public class PackageItemViewModel : IMapFrom<PackageItem>, IHaveCustomMappings
    {
        [Render(ShowForEdit = false)]
        public int PackageItemId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Ration Item")]
        [Display(Prompt = "Ration Item")]
        public int RationItemId { get; set; }
        public string RationItemName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Package")]
        [Display(Prompt = "Package")]
        public int PackageId { get; set; }
        public string PackageCode { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Price")]
        [Display(Prompt = "Price")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Is Applicable For Batman")]
        [Display(Prompt = "Is Applicable For Batman")]
        public bool IsApplicableForBatman { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<PackageItem, PackageItemViewModel>()
                .ForMember(m => m.RationItemName, opt => opt.MapFrom(u => u.RationItem.ItemName))
                .ForMember(m => m.PackageCode, opt => opt.MapFrom(u => u.Package.PackageCode));
        }
    }
}