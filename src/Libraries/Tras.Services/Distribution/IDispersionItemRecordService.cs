using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Ration;
using Tras.Core.Domain.Distribution;
using Tras.Core.PagedList;

namespace Tras.Services.Distribution
{
   public  interface IDispersionItemRecordService
    {
       DispersionItemRecord InsertDispersionItemRecord(DispersionItemRecord dispersionItemRecord);
       void UpdateDispersionItemRecord(DispersionItemRecord dispersionItemRecord);
       void DeleteDispersionItemRecord(DispersionItemRecord dispersionItemRecord);
       DispersionItemRecord GetDispersionItemRecordById(long dispersionItemRecordId);
       IPagedList<DispersionItemRecord> GetAllDispersionItemRecord(int pageSize, int pageIndex, bool showDeleted = false);
      
    }
}
