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
    public class PackageManpowerCalculator
    {
        private readonly IPackageManpower _currentPackageManpower;
        private readonly RationHead _rationHead;
        private readonly RationItemCategory _rationItemCategory;
        private readonly int _packageId;


        public PackageManpowerCalculator( RationHead rationHead, RationItemCategory rationItemCategory, int packageId, IFamilyInfoService familyInfoService)
        {
            _rationItemCategory = rationItemCategory;
            _packageId = packageId;
            var familyInfoService1 = familyInfoService;
            _rationHead = rationHead;

            //Strategy

            if( rationHead.HeadName.Contains(AppConstant.RationHeadNameForFree) && !rationItemCategory.CategoryName.Contains(AppConstant.RationItemCategoryForRegularItem))
                _currentPackageManpower = new ManpowerForFreshAndSpicyItemOfFree(familyInfoService1);
            
            if(rationHead.HeadName.Contains(AppConstant.RationHeadNameForFree) && rationItemCategory.CategoryName.Contains(AppConstant.RationItemCategoryForRegularItem))
                _currentPackageManpower = new ManpowerForRegularItemOfFree(familyInfoService1);
            
            if(rationHead.HeadName.Contains(AppConstant.RationHeadNameForNormal))
                _currentPackageManpower = new ManpowerForRegularItemOfNormal(familyInfoService1);
            
            if(rationHead.HeadName.Contains(AppConstant.RationHeadNameForSubsidy))
                _currentPackageManpower = new ManpowerForRegularItemOfSubsidy(familyInfoService1);


        }

        public Manpower CalculateManpower()
        {
            return _currentPackageManpower.GetManpowerInfo(_packageId);
        }
    }
}
