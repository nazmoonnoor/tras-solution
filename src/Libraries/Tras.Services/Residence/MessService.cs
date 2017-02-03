using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Residence;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Residence
{
   public class MessService:IMessService
    {
       private readonly IRepository<Mess> _messRepository;

       public MessService(IRepository<Mess> messRepository)
       {
           _messRepository = messRepository;
       }

       public Mess InsertMess(Mess mess)
       {
           if(mess==null)
               throw new ArgumentNullException("mess");
           return _messRepository.Insert(mess);
       }

       public void UpdateMess(Mess mess)
       {
           if (mess == null)
               throw new ArgumentNullException("mess");
           _messRepository.Update(mess);
       }

       public void DeleteMess(Mess mess)
       {
           if (mess == null)
               throw new ArgumentNullException("mess");
           _messRepository.Delete(mess);
       }

       public Mess GetMessById(int messId)
       {
           if (messId == 0)
               return null;
           return _messRepository.GetById(messId);
       }

       public IEnumerable<Mess> GetMesses()
       {
           return _messRepository.Table.ToList();
       }

       public IPagedList<Mess> GetMesses(int pageSize, int pageIndex, bool showDeleted = false)
       {
           var query = _messRepository.Table;
           if (!showDeleted)
               query = query.Where(m => m.Deleted == false);
           query = query.OrderByDescending(m => m.MessId).ThenBy(m => m.MessName);
           var messes = new PagedList<Mess>(query,pageIndex,pageSize);
           return messes;
       }
    }
}
