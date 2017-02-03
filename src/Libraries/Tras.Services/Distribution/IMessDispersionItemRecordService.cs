using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Distribution;
using Tras.Core.PagedList;

namespace Tras.Services.Distribution
{
   public interface IMessDispersionItemRecordService
    {
       MessDispersionItemRecord InsertMessDispersionItemRecord(MessDispersionItemRecord messDispersionItemRecord);
        void UpdateMessDispersionItemRecord(MessDispersionItemRecord messDispersionItemRecord);
        void DeleteMessDispersionItemRecord(MessDispersionItemRecord messDispersionItemRecord);
        MessDispersionItemRecord GetMessDispersionItemRecordById(long messDispersionItemRecordId);
        IPagedList<MessDispersionItemRecord> GetAllMessDispersionItemRecord(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
