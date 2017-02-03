using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Tras.Core.Domain.Ration;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Employee
{
    public class PersonPackageViewModel : IMapFrom<PersonPackage>
    {
        [Render(ShowForEdit = false)]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Package")]
        [UIHint("DropDownList")]
        public int PackageId { get; set; }
        public string PackageCode { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
    }
}