using System;
using System.Linq;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Ration
{
    public class RationItemService : IRationItemService
    {
        private readonly IRepository<RationItem> _rationItem;

        public RationItemService(IRepository<RationItem> rationItem)
        {
            _rationItem = rationItem;
        }

        public RationItem InsertRationItem(RationItem rationItem)
        {
            if(rationItem==null)
                throw new ArgumentNullException("rationItem");
            return _rationItem.Insert(rationItem);
        }

        public void UpdateRationItem(RationItem rationItem)
        {
            if (rationItem == null)
                throw new ArgumentNullException("rationItem");
            rationItem.LastUpdatedDate=DateTime.Now;
            _rationItem.Update(rationItem);
        }

        public void DeleteRationItem(RationItem rationItem)
        {
            if (rationItem == null)
                throw new ArgumentNullException("rationItem");
            rationItem.LastUpdatedDate = DateTime.Now;
            _rationItem.Delete(rationItem);
        }

        public RationItem GetRationItemById(int rationItemId)
        {
            if (rationItemId == 0)
                return null;
            return _rationItem.GetById(rationItemId);
        }

        public IPagedList<RationItem> GetRationItems(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _rationItem.Table;
            if (!showDeleted)
                query = query.Where(r => r.Deleted == false);
            query = query.OrderByDescending(r => r.ItemId).ThenBy(r => r.ItemName);
            var rationItems= new PagedList<RationItem>(query, pageIndex, pageSize);
            return rationItems;
        }
    }
}
