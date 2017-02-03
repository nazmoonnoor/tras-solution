using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Configuration;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Configuration
{
    public class LookupViewModel : IMapFrom<Lookup>
    {
        [Render(ShowForEdit = false)]
        public int LookupId { get; set; }

        [DisplayName("Lookup Type")]
        [Required(ErrorMessage = "Required")]
        [Display(Prompt = "Lookup Type")]
        [UIHint("DropDownList")]
        public string LookupType { get; set; }

        [DisplayName("Key")]
        [Required(ErrorMessage = "Required")]
        [Display(Prompt = "Key")]
        public string Key { get; set; }

        [DisplayName("Value")]
        [Required(ErrorMessage = "Required")]
        [Display(Prompt = "Value")]
        public string Value { get; set; }

        [DisplayName("Description")]
        [Display(Prompt = "Description")]
        [UIHint("MultilineText")]
        public string Description { get; set; }

        [DisplayName("Order")]
        [Required(ErrorMessage = "Required")]
        [Display(Prompt = "Order")]
        public int? Order { get; set; }
    }
}