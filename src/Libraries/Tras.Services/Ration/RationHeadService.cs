using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Ration
{
    public class RationHeadService : IRationHeadService
    {
        private readonly IRepository<RationHead> _repository;

        public RationHeadService(IRepository<RationHead> repository)
        {
            _repository = repository;
        }
        public RationHead InsertHead(RationHead rationHead)
        {
            if(rationHead==null)
                throw new ArgumentNullException("rationHead");
            return _repository.Insert(rationHead);
        }

        public void UpdateHead(RationHead rationHead)
        {
            if (rationHead == null)
                throw new ArgumentNullException("rationHead");
            rationHead.LastUpdatedDate= DateTime.Now;
            _repository.Update(rationHead);
        }

        public void DeleteHead(RationHead rationHead)
        {
            if (rationHead == null)
                throw new ArgumentNullException("rationHead");
            _repository.Delete(rationHead);
        }

        public RationHead GetHeadById(int rationHeadId)
        {
            if (rationHeadId == 0)
                return null;
            return _repository.GetById(rationHeadId);
        }

        public IPagedList<RationHead> GetHeads(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(r => r.Deleted == false);
            query = query.OrderByDescending(r => r.HeadId).ThenBy(r => r.HeadName);
            var heads = new PagedList<RationHead>(query, pageIndex, pageSize);
            return heads;
        }

        public IEnumerable<RationHead> GetHeads()
        {
            return _repository.Table.ToList();
        }
    }
}
