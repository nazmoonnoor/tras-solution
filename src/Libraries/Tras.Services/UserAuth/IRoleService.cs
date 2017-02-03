using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;
using Tras.Core.PagedList;

namespace Tras.Services.UserAuth
{
    public interface IRoleService
    {
        void InsertRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        Role GetRoleById(int roleId);
        IPagedList<Role> GetAllRoles(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
