using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Tras.Core.Domain.Distribution;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Distribution
{
    public class MessDispersionRecordService : IMessDispersionRecordService
    {
        private readonly IRepository<MessDispersionRecord> _repository;
        private readonly IRepository<MessDispersionItemRecord> _repositoryItem;

        public MessDispersionRecordService(IRepository<MessDispersionRecord> repository,IRepository<MessDispersionItemRecord> repositoryItem  )
        {
            _repository = repository;
            _repositoryItem = repositoryItem;
        }

        public MessDispersionRecord InsertMessDispersionRecord(MessDispersionRecord messDispersionRecord)
        {
            if (messDispersionRecord == null)
                throw new ArgumentNullException("messDispersionRecord");
            return _repository.Insert(messDispersionRecord);
        }

        public void UpdateMessDispersionRecord(MessDispersionRecord messDispersionRecord)
        {
            if (messDispersionRecord == null)
                throw new ArgumentNullException("messDispersionRecord");
            _repository.Update(messDispersionRecord);
        }

        public void DeleteMessDispersionRecord(MessDispersionRecord messDispersionRecord)
        {
            if (messDispersionRecord == null)
                throw new ArgumentNullException("messDispersionRecord");
            _repository.Delete(messDispersionRecord);
        }

        public MessDispersionRecord GetMessDispersionRecordById(long messDispersionRecordId)
        {
            if (messDispersionRecordId == 0)
                return null;
            return _repository.GetById(messDispersionRecordId);
        }

        public IPagedList<MessDispersionRecord> GetMessDispersionRecords(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(d => d.Deleted == false);
            query = query.OrderByDescending(d => d.InvoiceNo).ThenBy(d => d.MessDispersionRecordId);
            var messDispersion = new PagedList<MessDispersionRecord>(query, pageIndex, pageSize);

            return messDispersion;
        }

        public void ExecuteCommandScope(MessDispersionRecord messDispersionRecord, IEnumerable<MessDispersionItemRecord> messDispersionItemRecords)
        {
            using (var scope = new TransactionScope())
            {
                _repository.Insert(messDispersionRecord);

                if (messDispersionRecord.MessDispersionRecordId < 1 || messDispersionItemRecords == null)
                    return;

                var dd = messDispersionItemRecords.Select(c =>
                {
                    c.MessDispersionRecordId = messDispersionRecord.MessDispersionRecordId; return c;
                });
                _repositoryItem.Insert(dd);

                scope.Complete();
            }
        }
    }
}
