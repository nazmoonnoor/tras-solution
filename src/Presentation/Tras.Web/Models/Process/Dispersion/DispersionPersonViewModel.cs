using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tras.Web.Models.Process.Dispersion
{
    public class DispersionPersonViewModel
    {
        public int RecordId { get; set; }
        
        public int PersonId { get; set; }

        [DisplayName("Personal No")]
        [Display(Prompt = "Personal No")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        public string PersonalNo { get; set; }

        [DisplayName("Month Range")]
        [UIHint("RadioButtonList")]
        public string MonthRangeKey { get; set; }

        [DisplayName("Month")]
        [Required(ErrorMessage = "Required")]
        [UIHint("DateTime")]
        public string FromMonth { get; set; }

        [DisplayName("Till")]
        [Required(ErrorMessage = "Required")]
        [UIHint("DateTime")]
        public string ToMonth { get; set; }
    }
}