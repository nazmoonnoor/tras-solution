using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tras.Core.Domain.Employee;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Employee
{
    public class UnitViewModel : IMapFrom<Unit>
    {
        [Render(ShowForEdit = false)]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Unit")]
        [Display(Prompt = "Unit")]
        public string Name { get; set; }
    }
}