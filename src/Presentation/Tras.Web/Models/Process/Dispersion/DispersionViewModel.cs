using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Tras.Services.Process.Dispersion;
using Tras.Web.Framework.Mapping;
using Tras.Web.Models.Employee;
using Tras.Web.Models.Ration;

namespace Tras.Web.Models.Process.Dispersion
{
    public class DispersionViewModel : IMapFrom<DispersionAsItem>
    {
        public PersonViewModel Person { get; set; }
        public PackageViewModel Package { get; set; }
        public IList<FoodItemScale> FoodItems { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Gross Price")]
        public decimal GrossPrice { get; set; }
    }
}