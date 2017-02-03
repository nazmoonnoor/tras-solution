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
    public class StockItemRecordService : IStockItemRecordService
    {
        private readonly IRepository<StockItemRecord> _repository;
        public StockItemRecordService(IRepository<StockItemRecord> repository )
        {
            _repository = repository;
        }

        public StockItemRecord InsertStockItemRecord(StockItemRecord stockItemRecord)
        {
            if(stockItemRecord==null)
                throw new ArgumentNullException("stockItemRecord");
            return _repository.Insert(stockItemRecord);
        }

        public void UpdateStockItemRecord(StockItemRecord stockItemRecord)
        {
            if (stockItemRecord == null)
                throw new ArgumentNullException("stockItemRecord");
             _repository.Update(stockItemRecord);
        }

        public void DeleteStockItemRecord(StockItemRecord stockItemRecord)
        {
            if (stockItemRecord == null)
                throw new ArgumentNullException("stockItemRecord");
             _repository.Delete(stockItemRecord);
        }

        public StockItemRecord GetStockItemRecordById(long stockItemRecordId)
        {
            if (stockItemRecordId == 0)
                return null;
            return _repository.GetById(stockItemRecordId);
        }

        public IPagedList<StockItemRecord> GetStockItemRecords(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _repository.Table;
            if (!showDeleted)
                query = query.Where(d => d.Deleted == false);
            query = query.OrderByDescending(d => d.ItemId).ThenBy(d => d.StockRecordId);
            var stockItemRecord = new PagedList<StockItemRecord>(query, pageIndex, pageSize);
            return stockItemRecord;
        }
    }
}
