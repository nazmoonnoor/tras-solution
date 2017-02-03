using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tras.Web.Models.Process.MessDispersion
{
    public class MessDispersionUIViewModel
    {
        [DisplayName("Mess")]
        [Display(Prompt = "Mess")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        public int MessId { get; set; }

        [DisplayName("From")]
        [Required(ErrorMessage = "Required")]
        [UIHint("DateTime")]
        public DateTime FromDate { get; set; }

        [DisplayName("To")]
        [Required(ErrorMessage = "Required")]
        [UIHint("DateTime")]
        public DateTime ToDate { get; set; }
    }
}