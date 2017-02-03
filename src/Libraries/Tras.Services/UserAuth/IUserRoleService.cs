using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;
using Tras.Core.PagedList;

namespace Tras.Services.UserAuth
{
   public interface IUserRoleService
    {
       void InsertUserRole(UserRole userRole);
       void UpdateUserRole(UserRole userRole);
       void DeleteUserRole(UserRole userRole);
       UserRole GetUserRoleById(int userRoleId);
       IPagedList<UserRole> GetAllUserRoles(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
