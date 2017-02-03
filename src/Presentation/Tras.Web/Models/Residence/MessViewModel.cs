using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tras.Core.Domain.Residence;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Residence
{
    public class MessViewModel : IMapFrom<Mess>
    {
        [Render(ShowForEdit = false)]
        public int MessId { get; set; }
        [Required(ErrorMessage = "Please enter a mess nmae")]
        [DataType(DataType.Text)]
        [DisplayName("Mess")]
        [Display(Prompt = "Mess")]
        public string MessName { get; set; }
    }
}