using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.UserAuth;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.UserAuth
{
   public class MethodService:IMethodService
   {
       private IRepository<Method> _methodRepository;
       public MethodService(IRepository<Method> methodRepository)
       {
           _methodRepository = methodRepository;
       }
       public void InsertMethod(Method method)
       {
           if(method==null)
            throw new AggregateException("Method");
           _methodRepository.Insert(method);
       }

       public void UpdateMethod(Method method)
       {
           if (method == null)
               throw new AggregateException("Method");
           _methodRepository.Update(method);
       }

       public void DeleteMethod(Method method)
       {
           if (method == null)
               throw new AggregateException("Method");
           _methodRepository.Delete(method);
       }

       public Method GetMethodById(int methodId)
       {
           if (methodId == 0)
               return null;
          return _methodRepository.GetById(methodId);
       }

       public IPagedList<Method> GetAllMethods(int pageSize, int pageIndex, bool showDeleted = false)
       {
           var query = _methodRepository.Table;
           if (!showDeleted)
               query = query.Where(m => m.Deleted == false);
           query = query.OrderByDescending(m => m.ControllerName).ThenBy(m=> m.MethodName);
           var methods = new PagedList<Method>(query,pageIndex,pageSize);
           return methods;
       }
    }
}
