using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Employee
{
   public class RankService:IRankService
   {
       private readonly IRepository<Rank> _rankRepository;

       public RankService(IRepository<Rank> rankRepository)
       {
           _rankRepository = rankRepository;
       }

       public Rank InsertRank(Rank rank)
       {
           if(rank==null)
               throw new ArgumentNullException("rank");
           return _rankRepository.Insert(rank);
       }

       public void UpdateRank(Rank rank)
       {
           if (rank == null)
               throw new ArgumentNullException("rank");
           _rankRepository.Update(rank);
       }

       public void DeleteRank(Rank rank)
       {
           if (rank == null)
               throw new ArgumentNullException("rank");
           _rankRepository.Delete(rank);
       }

       public Rank GetRankById(int rankId)
       {
           if (rankId == 0)
               return null;
           return _rankRepository.GetById(rankId);
       }

       public IEnumerable<Rank> GetRanks()
       {
           return _rankRepository.Table.ToList();
       }

       public IPagedList<Rank> GetRanks(int pageSize, int pageIndex, bool showDeleted = false)
       {
           var query = _rankRepository.Table;
           if (!showDeleted)
               query = query.Where(c => c.Deleted == false);
           query = query.OrderByDescending(d => d.RankId).ThenBy(d => d.Name);
           var ranks = new PagedList<Rank>(query, pageIndex, pageSize);
           return ranks;
       }
   }
}
