using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using Tras.Core.Domain.Ration;
using Tras.Web.Framework.Mapping;

namespace Tras.Web.Models.Ration
{
    public class PackageDetailsViewModel : IMapFrom<Package>,IHaveCustomMappings
    {

        [DisplayName("Code")]    
        public string PackageCode { get; set; }
         [DisplayName("Sub Head ")] 
        public string SubHeadName { get; set; }
         [DisplayName("Head")] 
        public string HeadName { get; set; }
         [DisplayName("Last Updated")] 
        public DateTime? LastUpDate { get; set; }
         [DisplayName("Updated By")] 
        public string LastUpdateUserName { get; set; }

        [DisplayName("Food Item List")]


    
        public virtual ICollection<PackageItem> PackageItems { get; set; }
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Package, PackageDetailsViewModel>()
                .ForMember(m => m.SubHeadName, opt => opt.MapFrom(u => u.SubHead.SubHeadName))
                .ForMember(m => m.HeadName, opt => opt.MapFrom(u => u.SubHead.Head.HeadName));
        }
    }
}