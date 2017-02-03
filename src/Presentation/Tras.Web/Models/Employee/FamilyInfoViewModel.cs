using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Tras.Core.Domain.Employee;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Employee
{
    public class FamilyInfoViewModel : IMapFrom<FamilyInfo>
    {
        [Render(ShowForEdit = false)]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Own")]
        [Display(Prompt = "Own")]
        public int Own { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Spouse")]
        [Display(Prompt = "Spouse")]
        public int Spouse { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Minor")]
        [Display(Prompt = "Minor")]
        public int KidsMinor { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Half")]
        [Display(Prompt = "Half")]
        public int KidsHalf { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("Adult")]
        [Display(Prompt = "Adult")]
        public int KidsAdult { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Text)]
        [DisplayName("BatMan")]
        [Display(Prompt = "BatMan")]
        public int BatMan { get; set; }
    }
}