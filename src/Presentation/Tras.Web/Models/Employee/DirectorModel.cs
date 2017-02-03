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
    public class DirectorModel : IMapFrom<Director>
    {
        [Render(ShowForEdit = false)]
        public int DirectorId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Director")]
        [Display(Prompt = "Director")]
        public string Name { get; set; }
    }
}