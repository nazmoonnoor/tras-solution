using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Services.Employee;

namespace Tras.Services.Process.Demand
{
    public class ManpowerForRegularItemOfSubsidy:IPackageManpower
    {
        private readonly IFamilyInfoService _familyInfoService;

        public ManpowerForRegularItemOfSubsidy(IFamilyInfoService familyInfoService)
        {
            _familyInfoService = familyInfoService;
        }

        public Manpower GetManpowerInfo(int packageId)
        {
           
            return _familyInfoService.GetManpowerForRegularItemOfSubsidy( packageId);
        }
    }
}
