using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Web.Extensions;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Employee
{
    public class PersonViewModel : IMapFrom<Person>, IHaveCustomMappings
    {
        [Render(ShowForEdit = false)]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Personal No")]
        [Display(Prompt = "Personal No")]
        public string PersonalNo { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Person Type")]
        [UIHint("DropDownList")]
        public string PersonTypeKey { get; set; }
        public string PersonTypeValue { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Category")]
        [UIHint("DropDownList")]
        public string CategoryKey { get; set; }
        public string CategoryValue { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Full Name")]
        [Display(Prompt = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayName("Joining Date (AHQ)")]
        public DateTime JoiningDate { get; set; }

        [DisplayName("Department")]
        [UIHint("DropDownList")]
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Rank")]
        [UIHint("DropDownList")]
        public int RankId { get; set; }
        public string RankName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Branch/Director")]
        [UIHint("DropDownList")]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("STD/P1 Order No")]
        [Display(Prompt = "STD/P1 Order No")]
        public string Stdp1No { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayName("STD/P1 Date")]
        public DateTime Stdp1NoDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Family Type")]
        [UIHint("DropDownList")]
        public string FamilyTypeKey { get; set; }
        public string FamilyTypeValue { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Gender")]
        [UIHint("DropDownList")]
        public string GenderKey { get; set; }
        public string GenderValue { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Marital Status")]
        [UIHint("DropDownList")]
        public string MaritalStatusKey { get; set; }
        public string MaritalStatusValue { get; set; }

        [DisplayName("Present Unit")]
        [UIHint("DropDownList")]
        public int? UnitId { get; set; }
        public string UnitName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Job Type")]
        [UIHint("DropDownList")]
        public string JobTypeKey { get; set; }
        public string JobTypeValue { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Mobile No")]
        [Display(Prompt = "Mobile No")]
        public string MobileNo { get; set; }

        public FamilyInfoViewModel FamilyInfoViewModel { get; set; }
        public PersonPackageViewModel PersonPackageViewModel { get; set; }
        
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Person, PersonViewModel>()
                .ForMember(m => m.PersonTypeValue, opt => opt.MapFrom(u => ServiceUtil.FatchLookupValue(AppConstant.LookupType.Person_Type, u.PersonTypeKey)))
                .ForMember(m => m.CategoryValue, opt => opt.MapFrom(u => ServiceUtil.FatchLookupValue(AppConstant.LookupType.Category, u.CategoryKey)))
                .ForMember(m => m.DepartmentName, opt => opt.MapFrom(u => u.Department.Name))
                .ForMember(m => m.RankName, opt => opt.MapFrom(u => u.Rank.Name))
                .ForMember(m => m.DirectorName, opt => opt.MapFrom(u => u.Director.Name))
                .ForMember(m => m.FamilyTypeValue, opt => opt.MapFrom(u => ServiceUtil.FatchLookupValue(AppConstant.LookupType.Family_Type, u.FamilyTypeKey)))
                .ForMember(m => m.GenderValue, opt => opt.MapFrom(u => ServiceUtil.FatchLookupValue(AppConstant.LookupType.Gender, u.GenderKey)))
                .ForMember(m => m.MaritalStatusValue, opt => opt.MapFrom(u => ServiceUtil.FatchLookupValue(AppConstant.LookupType.Marital_Status, u.MaritalStatusKey)))
                .ForMember(m => m.UnitName, opt => opt.MapFrom(u => u.Unit.Name))
                .ForMember(m => m.JobTypeValue, opt => opt.MapFrom(u => ServiceUtil.FatchLookupValue(AppConstant.LookupType.Job_Type, u.JobTypeKey)))
                .ForMember(m => m.FamilyInfoViewModel, option => option.Ignore())
                .ForMember(m=>m.PersonPackageViewModel,option=>option.Ignore());
        }
    }
}