using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using Tras.Core.Domain.Ration;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Ration
{
    public class PackageViewModel: IMapFrom<Package>, IHaveCustomMappings
    {
        [Render(ShowForEdit = false)]
        public int PackageId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Package Code")]
        [Display(Prompt = "Package Code")]
        public string PackageCode { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Sub Head")]
        public int SubHeadId { get; set; }
        public string SubHeadName { get; set; }

        [DisplayName("Head")]
        public string HeadName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Package, PackageViewModel>()
                .ForMember(m => m.SubHeadName, opt => opt.MapFrom(u => u.SubHead.SubHeadName))
                .ForMember(m => m.HeadName, opt => opt.MapFrom(u => u.SubHead.Head.HeadName));
        }
    }
}