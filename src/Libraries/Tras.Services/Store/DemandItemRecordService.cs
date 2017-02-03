using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Store;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Store
{
    public class DemandItemRecordService : IDemandItemRecordService
    {
        private readonly IRepository<DemandItemRecord> _repository;
        public DemandItemRecordService(IRepository<DemandItemRecord> repository )
        {
            _repository = repository;
        }

        public DemandItemRecord InsertDemandItemRecord(DemandItemRecord demandItemRecord)
        {
            if(demandItemRecord ==null)
                throw new ArgumentNullException("demandItemRecord");
            return _repository.Insert(demandItemRecord);
        }

        public void UpdateDemandItemRecord(DemandItemRecord demandItemRecord)
        {
            if (demandItemRecord == null)
                throw new ArgumentNullException("demandItemRecord");
            _repository.Update(demandItemRecord);
        }

        public void DeleteDemandItemRecord(DemandItemRecord demandItemRecord)
        {
            if (demandItemRecord == null)
                throw new ArgumentNullException("demandItemRecord");
            _repository.Delete(demandItemRecord);
        }

        public DemandItemRecord GetDemandItemRecordById(long demandItemRecordId)
        {
            if (demandItemRecordId == 0)
                return null;
            return _repository.GetById(demandItemRecordId);
        }

        public IPagedList<DemandItemRecord> GetDemandItemRecords(int pageSize, int pageIndex, bool showDeleted = false)
        {

            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(d => d.Deleted == false);
            query = query.OrderByDescending(d => d.ItemId).ThenBy(d => d.DemandRecordId);
            var demandItemRecord = new PagedList<DemandItemRecord>(query, pageIndex, pageSize);
            return demandItemRecord;
        }
    }
}
