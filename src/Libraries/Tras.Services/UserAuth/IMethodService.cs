using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;
using Tras.Core.PagedList;

namespace Tras.Services.UserAuth
{
    public interface IMethodService
    {
        void InsertMethod(Method method);
        void UpdateMethod(Method method);
        void DeleteMethod(Method method);
        Method GetMethodById(int methodId);
        IPagedList<Method> GetAllMethods(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
