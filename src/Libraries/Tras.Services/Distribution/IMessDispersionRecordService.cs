using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;
using Tras.Core.PagedList;

namespace Tras.Services.Distribution
{
    public interface IMessDispersionRecordService
    {
        MessDispersionRecord InsertMessDispersionRecord(MessDispersionRecord messDispersionRecord);
        void UpdateMessDispersionRecord(MessDispersionRecord messDispersionRecord);
        void DeleteMessDispersionRecord(MessDispersionRecord messDispersionRecord);
        MessDispersionRecord GetMessDispersionRecordById(long messDispersionRecordId);
        IPagedList<MessDispersionRecord> GetMessDispersionRecords(int pageSize, int pageIndex, bool showDeleted = false);

        void ExecuteCommandScope(MessDispersionRecord messDispersionRecord, IEnumerable<MessDispersionItemRecord> messDispersionItemRecords);
    }
}
