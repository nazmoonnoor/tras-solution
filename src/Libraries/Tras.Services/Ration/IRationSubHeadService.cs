using System.Collections.Generic;
using Tras.Core.Domain.Ration;
using Tras.Core.PagedList;

namespace Tras.Services.Ration
{
    public interface IRationSubHeadService
    {
        RationSubHead InsertSubHead(RationSubHead rationSubHead);
        void UpdateSubHead(RationSubHead rationSubHead);
        void DeleteSubHead(RationSubHead rationSubHead);
        RationSubHead GetSubHeadById(int subHeadId);
        RationHead GetHeadById(int subHeadId);
        IEnumerable<RationSubHead> GetSubHeads();
        IPagedList<RationSubHead> GetSubHeads(int pageSize, int pageIndex, bool showDeleted = false);
        int GetSubHeadIdForCivilian();
    }
}
