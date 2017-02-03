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
    public class DepartmentViewModel : IMapFrom<Department>
    {
        [Render(ShowForEdit = false)]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Department")]
        [Display(Prompt = "Department")]
        public string Name { get; set; }
    }
}