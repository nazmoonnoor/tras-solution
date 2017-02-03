using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;
using Tras.Core.PagedList;

namespace Tras.Services.UserAuth
{
    public interface IRoleMethodService
    {
        void InsertRoleMethod(RoleMethod roleMethod);
        void UpdateRoleMethod(RoleMethod roleMethod);
        void DeleteRoleMethod(RoleMethod roleMethod);
        RoleMethod GetRoleMethodById(int roleMethodId);
        IPagedList<RoleMethod> GetAllRoleMethods(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
