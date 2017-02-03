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
    public class RationHeadViewModel : IMapFrom<RationHead>
    {
        [Render(ShowForEdit = false)]
        public int HeadId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Head Name")]
        [Display(Prompt = "Head Name")]
        public string HeadName { get; set; }
    }
}