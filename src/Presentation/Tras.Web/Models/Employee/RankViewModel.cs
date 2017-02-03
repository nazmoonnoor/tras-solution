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
    public class RankViewModel : IMapFrom<Rank>
    {
        [Render(ShowForEdit = false)]
        public int RankId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Rank")]
        [Display(Prompt = "Rank")]
        public string Name { get; set; }

    }
}