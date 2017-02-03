using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;

namespace Tras.Services.Ration
{
   public interface IRationItemService
    {
       RationItem InsertRationItem(RationItem rationItem);
       void UpdateRationItem(RationItem rationItem);
       void DeleteRationItem(RationItem rationItem);
       RationItem GetRationItemById(int rationItemId);
       IPagedList<RationItem> GetRationItems(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
