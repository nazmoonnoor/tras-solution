using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;
using Tras.Services.Process.Demand;

namespace Tras.Services.Employee
{
    public class FamilyInfoService : IFamilyInfoService
    {
        private readonly IRepository<FamilyInfo> _familyInfoRepository;

        public FamilyInfoService(IRepository<FamilyInfo> familyInfoRepository)
        {
            _familyInfoRepository = familyInfoRepository;
        }

        public FamilyInfo InsertFamilyInfo(FamilyInfo familyInfo)
        {
            if (familyInfo == null)
                throw new ArgumentNullException("familyInfo");
            return _familyInfoRepository.Insert(familyInfo);
        }

        public void UpdateFamilyInfo(FamilyInfo familyInfo)
        {
            if (familyInfo == null)
                throw new ArgumentNullException("familyInfo");
            _familyInfoRepository.Update(familyInfo);
        }

        public void DeleteFamilyInfo(FamilyInfo familyInfo)
        {
            if (familyInfo == null)
                throw new ArgumentNullException("familyInfo");
            _familyInfoRepository.Delete(familyInfo);
        }

        public FamilyInfo GetFamilyInfoById(int familyInfoId)
        {
            if (familyInfoId == 0)
                return null;
            return _familyInfoRepository.GetById(familyInfoId);
        }

        public IEnumerable<FamilyInfo> GetAllFamilyInfo()
        {
            return _familyInfoRepository.Table.ToList();
        }

        public IPagedList<FamilyInfo> GetAllFamilyInfo(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _familyInfoRepository.Table;
            if (!showDeleted)
                query = query.Where(c => c.Deleted == false);
            var familyInfo = new PagedList<FamilyInfo>(query, pageIndex, pageSize);
            return familyInfo;
        }

        public FamilyInfo GetFamilyInfoByPersonId(int personId)
        {
            return _familyInfoRepository.Table.FirstOrDefault(c => c.PersonId == personId);
        }

        public Manpower GetManpowerForFreshAndSpicyItemOfFree(int packageId)
        {
            // ##
            // #RationHead: Free : 
            // #Item Category : Fresh and Spicy
            // Get all Solder who stay  mess 
            // [Mess Allotment] 
            // Only Own field will be field,other field will be 0;
            
            return new Manpower
            {
                TotalNoOfBatMan = 0,
                TotalNoOfKidsAdult = 0,
                TotalNoOfKidsHalf = 0,
                TotalNoOfKidsMinor = 0,
                TotalNoOfOwn = 5,
                TotalNoOfSpouse = 0
            };
        }

        public Manpower GetManpowerForRegularItemOfFree(int packageId)
        {
            //#Case 3
            // RationHead: Free : 
            // Item Category : Regular(Ration Item)
            // Get all Solder who stay in home and mess both
            // SP
            
            
            //GetFreeRegularManpower
            return new Manpower
            {
                TotalNoOfBatMan = 1,
                TotalNoOfKidsAdult = 2,
                TotalNoOfKidsHalf = 3,
                TotalNoOfKidsMinor = 4,
                TotalNoOfOwn = 5,
                TotalNoOfSpouse = 7
            };
        }

        public Manpower GetManpowerForRegularItemOfNormal(int packageId)
        {

            //Civil own and family
            //Case 2.1
            //RationHead: Normal
            //Item Category : Regular(Ration Item)                       
            //Get all civil person from personpackage  according to package and it's family info                               
            //then sum each dependantField like [Own]
            //,[Spouse]
            //,[KidsMinor]
            //,[KidsHalf]
            //,[KidsAdult]

   
            //SP 

            //batman
            //Case 2.1            
            //Get all batman of officer persons from personpackage according to package  .()
            //then sum  dependantField like 
            //[BatMan]

            //RationHead : Subcidy : Item Category : Regular . Exception case: solder live with family own= 0 (means don't consider himself)  
            //RationHead: Normal : Item category:Regular 
            //

            //sum of 2.1 + 2.2
            
            return new Manpower
            {
                TotalNoOfBatMan = 1,
                TotalNoOfKidsAdult = 2,
                TotalNoOfKidsHalf = 3,
                TotalNoOfKidsMinor = 4,
                TotalNoOfOwn = 5,
                TotalNoOfSpouse = 7
            };
        }

        public Manpower GetManpowerForRegularItemOfSubsidy(int packageId)
        {
            //#
            //# 
            //#RationHead: Subsidy
            //#Item Category : Regular(Ration Item)
            //Get all person from personpackage according to package and it's family info                        
            //then sum each dependantField like [Own]
            //,[Spouse]
            //,[KidsMinor]
            //,[KidsHalf]
            //,[KidsAdult]
            //,[BatMan]

            //Clue : Item Category : Regular . Exception case: solder live with family own= 0 (means dont cosider himself)  


            //GetSubSidyManpower
            
            return new Manpower
            {
                TotalNoOfBatMan = 1,
                TotalNoOfKidsAdult = 2,
                TotalNoOfKidsHalf = 3,
                TotalNoOfKidsMinor = 4,
                TotalNoOfOwn = 5,
                TotalNoOfSpouse = 7
            };
        }
    }
}
