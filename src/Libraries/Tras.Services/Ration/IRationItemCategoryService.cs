using System.Collections.Generic;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;

namespace Tras.Services.Ration
{
   public interface IRationItemCategoryService
    {
       RationItemCategory InsertRationItemCategory(RationItemCategory rationItemCategory);
       void UpdateRationItemCategory(RationItemCategory rationItemCategory);
       void DeleteRationItemCategory(RationItemCategory rationItemCategory);
       RationItemCategory GetRationItemCategoryById(int rationItemCategoryId);
       IEnumerable<RationItemCategory> GetRationItemCategories();
       IPagedList<RationItemCategory> GetRationItemCategories(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
