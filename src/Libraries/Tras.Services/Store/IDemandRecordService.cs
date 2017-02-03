using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;
using Tras.Core.Domain.Store;
using Tras.Core.PagedList;

namespace Tras.Services.Store
{
   public  interface IDemandRecordService
    {
       DemandRecord InsertDemandRecord(DemandRecord demandRecord);
       void UpdateDemandRecord(DemandRecord demandRecord);
       void DeleteDemandRecord(DemandRecord demandRecord);
       DemandRecord GetDemandRecordById(long demandRecordId);
       IPagedList<DemandRecord> GetDemandRecords(int pageSize, int pageIndex, bool showDeleted = false);

       void ExecuteCommandScope(DemandRecord demandRecord, IEnumerable<DemandItemRecord> demandItemRecords);
    }
}
