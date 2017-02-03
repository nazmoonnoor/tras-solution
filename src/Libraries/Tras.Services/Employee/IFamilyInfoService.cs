using System.Collections.Generic;
using Tras.Core.Domain.Employee;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Services.Process.Demand;

namespace Tras.Services.Employee
{
    public interface IFamilyInfoService
    {
        FamilyInfo InsertFamilyInfo(FamilyInfo familyInfo);
        void UpdateFamilyInfo(FamilyInfo familyInfo);
        void DeleteFamilyInfo(FamilyInfo familyInfo);
        FamilyInfo GetFamilyInfoById(int familyInfoId);
        IEnumerable<FamilyInfo> GetAllFamilyInfo();
        IPagedList<FamilyInfo> GetAllFamilyInfo(int pageSize, int pageIndex, bool showDeleted = false);
        FamilyInfo GetFamilyInfoByPersonId(int personId);

        Manpower GetManpowerForFreshAndSpicyItemOfFree( int packageId);
        Manpower GetManpowerForRegularItemOfFree( int packageId);
        Manpower GetManpowerForRegularItemOfNormal( int packageId);
        Manpower GetManpowerForRegularItemOfSubsidy( int packageId);
    }
}