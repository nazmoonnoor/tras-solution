using System.Collections.Generic;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;

namespace Tras.Services.Ration
{
   public interface IRationHeadService
    {
       RationHead InsertHead(RationHead rationHead);
       void UpdateHead(RationHead rationHead);
       void DeleteHead(RationHead rationHead);
       RationHead GetHeadById(int rationHeadId);

       IEnumerable<RationHead> GetHeads();
       IPagedList<RationHead> GetHeads(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
