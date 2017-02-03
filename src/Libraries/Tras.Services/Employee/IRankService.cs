using System.Collections.Generic;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;

namespace Tras.Services.Employee
{
   public interface IRankService
    {
       Rank InsertRank(Rank rank);
       void UpdateRank(Rank rank);
       void DeleteRank(Rank rank);
       Rank GetRankById(int rankId);
       IEnumerable<Rank> GetRanks();
       IPagedList<Rank> GetRanks(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
