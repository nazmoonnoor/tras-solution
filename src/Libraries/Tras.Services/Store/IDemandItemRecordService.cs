using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Store;
using Tras.Core.PagedList;

namespace Tras.Services.Store
{
   public  interface IDemandItemRecordService
    {
        DemandItemRecord InsertDemandItemRecord(DemandItemRecord demandItemRecord);
        void UpdateDemandItemRecord(DemandItemRecord demandItemRecord);
        void DeleteDemandItemRecord(DemandItemRecord demandItemRecord);
        DemandItemRecord GetDemandItemRecordById(long demandItemRecordId);
        IPagedList<DemandItemRecord> GetDemandItemRecords(int pageSize, int pageIndex, bool showDeleted = false);

    }
}
