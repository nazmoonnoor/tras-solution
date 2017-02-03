using System.Collections.Generic;
using Tras.Core.Domain.Distribution;
using Tras.Core.PagedList;

namespace Tras.Services.Distribution
{
    public interface IDispersionRecordService
    {
        DispersionRecord InsertDispersionRecord(DispersionRecord dispersionRecord);
        void UpdateDispersionRecord(DispersionRecord dispersionRecord);
        void DeleteDispersionRecord(DispersionRecord dispersionRecord);
        DispersionRecord GetDispersionRecordById(long dispersionRecordId);
        IPagedList<DispersionRecord> GetDispersionRecords(int pageSize, int pageIndex, bool showDeleted = false);

        void ExecuteCommandScope(DispersionRecord dispersionRecord,IEnumerable<DispersionItemRecord> dispersionItemRecords);

    }
}
