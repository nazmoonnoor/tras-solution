using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Tras.Core.Domain.Store;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Store
{
    public class DemandRecordService : IDemandRecordService
    {
        private readonly IRepository<DemandRecord> _repository;
        private readonly IRepository<DemandItemRecord> _repositoryItem;

        public DemandRecordService(IRepository<DemandRecord> repository,IRepository<DemandItemRecord> repositoryItem  )
        {
            _repository = repository;
            _repositoryItem = repositoryItem;
        }

        public DemandRecord InsertDemandRecord(DemandRecord demandRecord)
        {
            if(demandRecord==null)
                throw new ArgumentNullException("demandRecord");
            return _repository.Insert(demandRecord);
        }

        public void UpdateDemandRecord(DemandRecord demandRecord)
        {
            if (demandRecord == null)
                throw new ArgumentNullException("demandRecord");
            _repository.Update(demandRecord);
        }

        public void DeleteDemandRecord(DemandRecord demandRecord)
        {
            if (demandRecord == null)
                throw new ArgumentNullException("demandRecord");
            _repository.Delete(demandRecord);
        }

        public DemandRecord GetDemandRecordById(long demandRecordId)
        {
            if (demandRecordId == 0)
                return null;
            return _repository.GetById(demandRecordId);
        }

        public IPagedList<DemandRecord> GetDemandRecords(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(d => d.Deleted == false);
            query = query.OrderByDescending(d => d.DemandNo).ThenBy(d => d.DemandRecordId);
            var demandRecord = new PagedList<DemandRecord>(query, pageIndex, pageSize);
            return demandRecord;
        }

        public void ExecuteCommandScope(DemandRecord demandRecord, IEnumerable<DemandItemRecord> demandItemRecords)
        {
            using (var scope = new TransactionScope())
            {
                _repository.Insert(demandRecord);

                if (demandRecord.DemandRecordId < 1 || demandItemRecords == null)
                    throw new ArgumentNullException("demandRecord"); 

                var item = demandItemRecords.Select(c =>
                {
                    c.DemandRecordId = demandRecord.DemandRecordId; return c;
                });
                _repositoryItem.Insert(item);

                scope.Complete();
            }
        }
    }
}
