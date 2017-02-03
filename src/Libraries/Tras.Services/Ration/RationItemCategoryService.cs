using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Ration
{
    public class RationItemCategoryService : IRationItemCategoryService
    {
        private readonly IRepository<RationItemCategory> _rationItemCategoryRepository;
        public RationItemCategoryService(IRepository<RationItemCategory> rationItemCategoryRepository)
        {
            _rationItemCategoryRepository = rationItemCategoryRepository;
        }

        public RationItemCategory InsertRationItemCategory(RationItemCategory rationItemCategory)
        {
            if(rationItemCategory==null)
                throw new ArgumentNullException("rationItemCategory");
            return _rationItemCategoryRepository.Insert(rationItemCategory);
        }

        public void UpdateRationItemCategory(RationItemCategory rationItemCategory)
        {
            if (rationItemCategory == null)
                throw new ArgumentNullException("rationItemCategory");
            rationItemCategory.LastUpdatedDate=DateTime.Now;
            _rationItemCategoryRepository.Update(rationItemCategory);
        }

        public void DeleteRationItemCategory(RationItemCategory rationItemCategory)
        {
            if (rationItemCategory == null)
                throw new ArgumentNullException("rationItemCategory");
            rationItemCategory.LastUpdatedDate = DateTime.Now;
            _rationItemCategoryRepository.Delete(rationItemCategory);
        }

        public RationItemCategory GetRationItemCategoryById(int rationItemCategoryId)
        {
            if (rationItemCategoryId == 0)
                return null;
            return _rationItemCategoryRepository.GetById(rationItemCategoryId);
        }
        
        public IEnumerable<RationItemCategory> GetRationItemCategories()
        {
            return _rationItemCategoryRepository.Table.ToList();
        }

        public IPagedList<RationItemCategory> GetRationItemCategories(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _rationItemCategoryRepository.Table;
            if (!showDeleted)
                query = query.Where(r => r.Deleted == false);
            query = query.OrderByDescending(r => r.CategoryId).ThenBy(r => r.CategoryName);
            var rationItemCategorys = new PagedList<RationItemCategory>(query, pageIndex, pageSize);
            return rationItemCategorys;
        }
    }
}
