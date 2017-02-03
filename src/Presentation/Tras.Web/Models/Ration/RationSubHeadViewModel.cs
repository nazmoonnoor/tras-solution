using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tras.Core.Domain.Ration;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Ration
{
    public class RationSubHeadViewModel : IMapFrom<RationSubHead>
    {
        [Render(ShowForEdit = false)]
        public int SubHeadId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Head")]
        public int HeadId { get; set; }

        [DisplayName("Head")]
        public string HeadName { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Sub Head")]
        [Display(Prompt = "Sub Head")]
        public string SubHeadName { get; set; }
    }
}