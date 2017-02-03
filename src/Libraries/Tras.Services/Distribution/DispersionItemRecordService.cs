using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;
using Tras.Core.Domain.Distribution;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Distribution
{
   public  class DispersionItemRecordService:IDispersionItemRecordService
    {
       private readonly IRepository<DispersionItemRecord> _repository;

       public DispersionItemRecordService(IRepository<DispersionItemRecord> repository)
       {
           _repository = repository;
       }

       public DispersionItemRecord InsertDispersionItemRecord(DispersionItemRecord dispersionItemRecord)
        {
            if(dispersionItemRecord==null)
                throw new ArgumentNullException("dispersionItemRecord");

           return _repository.Insert(dispersionItemRecord);
        }

        public void UpdateDispersionItemRecord(DispersionItemRecord dispersionItemRecord)
        {
            if (dispersionItemRecord == null)
                throw new ArgumentNullException("dispersionItemRecord");

            _repository.Update(dispersionItemRecord);
        }

        public void DeleteDispersionItemRecord(DispersionItemRecord dispersionItemRecord)
        {
            if (dispersionItemRecord == null)
                throw new ArgumentNullException("dispersionItemRecord");

            _repository.Delete(dispersionItemRecord);
        }

        public DispersionItemRecord GetDispersionItemRecordById(long dispersionItemRecordId)
        {
            if (dispersionItemRecordId == 0)
                return null;
            return _repository.GetById(dispersionItemRecordId);
        }

        public IPagedList<DispersionItemRecord> GetAllDispersionItemRecord(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(d => d.Deleted == false);
            query = query.OrderByDescending(d => d.DispersionRecordId).ThenBy(d => d.DispersionRecordId);
            var dispersionDetail = new PagedList<DispersionItemRecord>(query, pageIndex, pageSize);

            return dispersionDetail;
        }
    }
}
