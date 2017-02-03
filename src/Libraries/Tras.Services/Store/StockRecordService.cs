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
   public class StockRecordService:IStockRecordService
    {
       private readonly IRepository<StockRecord> _repository;
       private readonly IRepository<StockItemRecord> _repositoryItem;

       public StockRecordService(IRepository<StockRecord> repository, IRepository<StockItemRecord> repositoryItem  )
       {
           _repository = repository;
           _repositoryItem = repositoryItem;
       }

       public StockRecord InsertStockRecord(StockRecord stockRecord)
       {
           if(stockRecord==null)
               throw new ArgumentNullException("stockRecord");
           return _repository.Insert(stockRecord);
       }

       public void UpdateStockRecord(StockRecord stockRecord)
       {
           if (stockRecord == null)
               throw new ArgumentNullException("stockRecord");
           _repository.Update(stockRecord);
       }

       public void DeleteStockRecord(StockRecord stockRecord)
       {
           if (stockRecord == null)
               throw new ArgumentNullException("stockRecord");
           _repository.Delete(stockRecord);
       }

       public StockRecord GetStockRecordById(long stockRecordId)
       {
           if (stockRecordId == 0)
               return null;
           return _repository.GetById(stockRecordId);
       }

       public IPagedList<StockRecord> GetStockRecords(int pageSize, int pageIndex, bool showDeleted = false)
       {
           var query = _repository.Table;
           if (!showDeleted)
               query = query.Where(d => d.Deleted == false);
           query = query.OrderByDescending(d => d.InvoiceNo).ThenBy(d => d.StockRecordId);
           var stockRecord = new PagedList<StockRecord>(query, pageIndex, pageSize);
           return stockRecord;
       }

       public void ExecuteCommandScope(StockRecord stockRecord, IEnumerable<StockItemRecord> stockItemRecords)
       {
           using (var scope = new TransactionScope())
           {
               _repository.Insert(stockRecord);

               if (stockRecord.StockRecordId < 1 || stockItemRecords == null)
                   throw new ArgumentNullException("stockRecord");

               var item = stockItemRecords.Select(c =>
               {
                   c.StockRecordId = stockRecord.StockRecordId; return c;
               });
               _repositoryItem.Insert(item);

               scope.Complete();
           }
       }
    }
}
