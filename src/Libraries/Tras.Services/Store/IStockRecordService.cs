using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Store;
using Tras.Core.PagedList;

namespace Tras.Services.Store
{
   public interface IStockRecordService
   {
       StockRecord InsertStockRecord(StockRecord stockRecord);
       void UpdateStockRecord(StockRecord stockRecord);
       void DeleteStockRecord(StockRecord stockRecord);
       StockRecord GetStockRecordById(long stockRecordId);
       IPagedList<StockRecord> GetStockRecords(int pageSize, int pageIndex, bool showDeleted = false);

       void ExecuteCommandScope(StockRecord stockRecord, IEnumerable<StockItemRecord> stockItemRecords);

    }
}
