using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Tras.Core.Domain.Distribution;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Distribution
{
   public class DispersionRecordService:IDispersionRecordService
    {
       private readonly IRepository<DispersionRecord> _repository;
       private readonly IRepository<DispersionItemRecord> _repositoryItem;

       public DispersionRecordService(IRepository<DispersionRecord> repository,IRepository<DispersionItemRecord> repositoryItem )
       {
           _repository = repository;
           _repositoryItem = repositoryItem;
       }

       public DispersionRecord InsertDispersionRecord(DispersionRecord dispersionRecord)
       {
           if(dispersionRecord ==null)
               throw new ArgumentNullException("dispersionRecord");
           return _repository.Insert(dispersionRecord);
       }

       public void UpdateDispersionRecord(DispersionRecord dispersionRecord)
       {
           if (dispersionRecord == null)
               throw new ArgumentNullException("dispersionRecord");
           _repository.Update(dispersionRecord);
       }

       public void DeleteDispersionRecord(DispersionRecord dispersionRecord)
       {
           if (dispersionRecord == null)
               throw new ArgumentNullException("dispersionRecord");
           _repository.Delete(dispersionRecord);
       }

       public DispersionRecord GetDispersionRecordById(long dispersionRecordId)
       {
           if (dispersionRecordId == 0)
               return null;
           return _repository.GetById(dispersionRecordId);
       }

       public IPagedList<DispersionRecord> GetDispersionRecords(int pageSize, int pageIndex, bool showDeleted = false)
       {
           var query = _repository.Table;
           if (!showDeleted)
               query = query.Where(d => d.Deleted == false);
           query = query.OrderByDescending(d => d.InvoiceNo).ThenBy(d => d.DispersionRecordId);
           var dispersion = new PagedList<DispersionRecord>(query,pageIndex,pageSize);

           return dispersion;
       }

       public void ExecuteCommandScope(DispersionRecord dispersionRecord, IEnumerable<DispersionItemRecord> dispersionItemRecords)
       {
           using (var scope = new TransactionScope())
           {
               _repository.Insert(dispersionRecord);

               if (dispersionRecord.DispersionRecordId < 1 || dispersionItemRecords==null)
                   return;
               
            var dd = dispersionItemRecords.Select(c =>
               {
                   c.DispersionRecordId = dispersionRecord.DispersionRecordId;return c; 
               });
            _repositoryItem.Insert(dd);
               
               scope.Complete();
           }

       }
    }
}
