using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Store;
using Tras.Core.PagedList;

namespace Tras.Services.Store
{
   public interface IStockItemRecordService
    {
       StockItemRecord InsertStockItemRecord(StockItemRecord stockItemRecord);
       void UpdateStockItemRecord(StockItemRecord stockItemRecord);
       void DeleteStockItemRecord(StockItemRecord stockItemRecord);
       StockItemRecord GetStockItemRecordById(long stockItemRecordId);
       IPagedList<StockItemRecord> GetStockItemRecords(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
