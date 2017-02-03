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
    public class UserRoleService : IUserRoleService
    {
        private IRepository<UserRole> _userRoleRepository;
        public UserRoleService(IRepository<UserRole> userRoleRepository )
        {
            _userRoleRepository = userRoleRepository;
        }
        public void InsertUserRole(UserRole userRole)
        {
            if(userRole==null)
                throw new AggregateException("User Role");
            _userRoleRepository.Insert(userRole);
        }

        public void UpdateUserRole(UserRole userRole)
        {
            if (userRole == null)
                throw new AggregateException("User Role");
            _userRoleRepository.Update(userRole);
        }

        public void DeleteUserRole(UserRole userRole)
        {
            if (userRole == null)
                throw new AggregateException("User Role");
            _userRoleRepository.Delete(userRole);
        }

        public UserRole GetUserRoleById(int userRoleId)
        {
            if (userRoleId == 0)
                return null;
            return _userRoleRepository.GetById(userRoleId);
        }

        public IPagedList<UserRole> GetAllUserRoles(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _userRoleRepository.Table;
            if (!showDeleted)
                query = query.Where(u => u.Deleted == false);
            query = query.OrderByDescending(u => u.UserRoleId).ThenBy(u => u.UserId);
            var userRoles = new PagedList<UserRole>(query,pageIndex,pageSize);
            return userRoles;
        }
    }
}
