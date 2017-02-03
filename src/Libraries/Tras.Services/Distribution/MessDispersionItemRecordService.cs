using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Distribution
{
    public class MessDispersionItemRecordService : IMessDispersionItemRecordService
    {
        private readonly IRepository<MessDispersionItemRecord> _repository;

        public MessDispersionItemRecordService(IRepository<MessDispersionItemRecord> repository )
        {
            _repository = repository;
        }

        public MessDispersionItemRecord InsertMessDispersionItemRecord(MessDispersionItemRecord messDispersionItemRecord)
        {
            if (messDispersionItemRecord == null)
                throw new ArgumentNullException("messDispersionItemRecord");

            return _repository.Insert(messDispersionItemRecord);
        }

        public void UpdateMessDispersionItemRecord(MessDispersionItemRecord messDispersionItemRecord)
        {
            if (messDispersionItemRecord == null)
                throw new ArgumentNullException("messDispersionItemRecord");

            _repository.Update(messDispersionItemRecord);
        }

        public void DeleteMessDispersionItemRecord(MessDispersionItemRecord messDispersionItemRecord)
        {
            if (messDispersionItemRecord == null)
                throw new ArgumentNullException("messDispersionItemRecord");

            _repository.Delete(messDispersionItemRecord);
        }

        public MessDispersionItemRecord GetMessDispersionItemRecordById(long messDispersionItemRecordId)
        {
            if (messDispersionItemRecordId == 0)
                return null;
            return _repository.GetById(messDispersionItemRecordId);
        }

        public IPagedList<MessDispersionItemRecord> GetAllMessDispersionItemRecord(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(d => d.Deleted == false);
            query = query.OrderByDescending(d => d.MessDispersionItemRecordId).ThenBy(d => d.MessDispersionRecordId);
            var messDispersionDetail = new PagedList<MessDispersionItemRecord>(query, pageIndex, pageSize);

            return messDispersionDetail;
        }
    }
}
