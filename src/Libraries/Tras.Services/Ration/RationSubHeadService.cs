using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Ration
{
    public class RationSubHeadService : IRationSubHeadService
    {
        private readonly IRepository<RationSubHead> _repository;

        public RationSubHeadService(IRepository<RationSubHead> repository)
        {
            _repository = repository;
        }
        public RationSubHead InsertSubHead(RationSubHead rationSubHead)
        {
            if(rationSubHead==null)
                throw new ArgumentNullException("rationSubHead");
            return _repository.Insert(rationSubHead);
        }

        public void UpdateSubHead(RationSubHead rationSubHead)
        {
            if (rationSubHead == null)
                throw new ArgumentNullException("rationSubHead");
            rationSubHead.LastUpdatedDate = DateTime.Now;
            
            _repository.Update(rationSubHead);
        }

        public void DeleteSubHead(RationSubHead rationSubHead)
        {
            if (rationSubHead == null)
                throw new ArgumentNullException("rationSubHead");
            _repository.Delete(rationSubHead);
        }

        public RationSubHead GetSubHeadById(int subHeadId)
        {
            if (subHeadId == 0)
                return null;
            return _repository.GetById(subHeadId);
        }

        public RationHead GetHeadById(int subHeadId)
        {
            if (subHeadId == 0)
                return null;
            var rationHead = _repository.Table.SingleOrDefault(it => it.SubHeadId == subHeadId);
            return rationHead != null ? rationHead.Head : null;
        }

        public IEnumerable<RationSubHead> GetSubHeads()
        {
            return _repository.Table.ToList();
        }

        public IPagedList<RationSubHead> GetSubHeads(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(r => r.Deleted == false);
            query = query.OrderByDescending(m => m.SubHeadId).ThenBy(m => m.SubHeadName);
            var subHeads = new PagedList<RationSubHead>(query,pageIndex,pageSize);
            return subHeads;
        }

        public int GetSubHeadIdForCivilian()
        {
            var firstOrDefault = _repository.Table.FirstOrDefault(s => s.SubHeadName.Contains(AppConstant.RationSubHeadNameForCivil));
            return firstOrDefault != null ? firstOrDefault.SubHeadId : 0;
        }
    }
}
