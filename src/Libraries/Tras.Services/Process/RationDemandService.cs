
using System;
using System.Collections;
using System.Collections.Generic;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Services.Employee;
using Tras.Services.Process.Demand;
using Tras.Services.Process.Dispersion;
using Tras.Services.Ration;

namespace Tras.Services.Process
{
    public class RationDemandService : IRationDemandService
    {
        private readonly IPackageItemService _packageItemService;
        private readonly IDispersionService _dispersionService;
        private readonly IFamilyInfoService _familyInfoService;
        private readonly IRationSubHeadService _rationSubHeadService;
        private readonly IRationItemCategoryService _rationItemCategory;
        private readonly IPersonService _personService;

        public RationDemandService(IPackageItemService packageItemService,
            IDispersionService dispersionService,
            IFamilyInfoService familyInfoService,
            IRationSubHeadService rationSubHeadService, 
            IRationItemCategoryService rationItemCategory,
            IPersonService personService)
        {
            _packageItemService = packageItemService;
            _dispersionService = dispersionService;
            _familyInfoService = familyInfoService;
            _rationSubHeadService = rationSubHeadService;
            _rationItemCategory = rationItemCategory;
            _personService = personService;
        }
        public IList<RationBox> CalculateByItems(int rationSubHeadId,int rationItemCategoryId, int numberOfDays)
        {
            //var manpowerTable = _personService.GetSubSidyManpower(2);
            IList<RationBox> rationBoxList = new List<RationBox>();
            
            //todo: validation
            //RationHead : Subcidy : Item Category : Regular Exception case: solder live with family own= 0 (means dont cosider himself)  
            //RationHead: Normal : Item category:Regular
            //RationHead: Free : Item Category : Fresh,Regular and Spicy
            //
            var foodPackageList = _packageItemService.GetPackageItems(rationSubHeadId, rationItemCategoryId);

            var rationHead = _rationSubHeadService.GetHeadById(rationSubHeadId);

            var rationItemCategory= _rationItemCategory.GetRationItemCategoryById(rationItemCategoryId);

            foreach (var package in foodPackageList)
            {
                var manpowerCalculator = new PackageManpowerCalculator(rationHead, rationItemCategory, package.PackageId, _familyInfoService);
                var manPowerCount = manpowerCalculator.CalculateManpower();
                var dependants = GetTotalDependants(manPowerCount, rationHead);
                var rationBox = new RationBox
                {
                    TotalNumberOfPeople = manPowerCount.TotalNoOfPerson,
                    PackageCode = package.PackageCode,
                    FoodItems = _dispersionService.GetFoodItemScale(dependants,package.Items, numberOfDays)
                };
                
                rationBoxList.Add(rationBox);
            }

            return rationBoxList;
        }



        private List<IDependant> GetTotalDependants(Manpower familyInfo, RationHead rationHead)
        {


            if (!rationHead.HeadName.Contains(AppConstant.RationHeadNameForFree))
            {
                var dependants = new List<IDependant>
                {
                    new Spouse()
                    {
                        NumberOf = familyInfo.TotalNoOfSpouse
                    },
                    new KidsAdult()
                    {
                        NumberOf = familyInfo.TotalNoOfKidsAdult
                    },
                    new KidsHalf()
                    {
                        NumberOf = familyInfo.TotalNoOfKidsHalf
                    },
                    new KidsMinor()
                    {
                        NumberOf = familyInfo.TotalNoOfKidsMinor
                    }
                

                };
                //1. When Ration Head is Subsidy and Normal ,Own will be calculated as Generale scale 
                //2.When Ration Head is Free, own will be calculated as Soldier Scale

                if (rationHead.HeadName.Contains(AppConstant.RationHeadNameForNormal) ||
                    rationHead.HeadName.Contains(AppConstant.RationHeadNameForSubsidy))
                {
                    dependants.Add(new OfficerSelf {NumberOf = familyInfo.TotalNoOfOwn});
                }
                else
                {
                    dependants.Add(new SoldierSelf {NumberOf = familyInfo.TotalNoOfOwn});
                }

                // when ration head is Subsidy batman will not be accountable

                if (rationHead.HeadName.Contains(AppConstant.RationHeadNameForNormal))
                    dependants.Add(new BatMan {NumberOf = familyInfo.TotalNoOfBatMan});

                return dependants;

            }
            else
            {
                var dependants = new List<IDependant>
                {
                    new SoldierSelf {NumberOf = familyInfo.TotalNoOfOwn}
                };
                return dependants;
            }




            
        }
    }
}
