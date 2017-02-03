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
   public class RoleService:IRoleService
   {
       private IRepository<Role> _roleRepository;
       public RoleService(IRepository<Role> roleRepository)
       {
           _roleRepository = roleRepository;
       }

       public void InsertRole(Role role)
       {
           if (role == null)
               throw new AggregateException("Role");
           _roleRepository.Insert(role);
       }

       public void UpdateRole(Role role)
       {
           if (role == null)
               throw new AggregateException("Role");
           _roleRepository.Update(role);
       }

       public void DeleteRole(Role role)
       {
           if (role == null)
               throw new AggregateException("Role");
           _roleRepository.Delete(role);
       }

       public Role GetRoleById(int roleId)
       {
           if (roleId == 0)
               return null;
           return _roleRepository.GetById(roleId);
       }

       public IPagedList<Role> GetAllRoles(int pageSize, int pageIndex, bool showDeleted = false)
       {
           var query = _roleRepository.Table;
           if (!showDeleted)
               query = query.Where(r => r.Deleted == false);
           query = query.OrderByDescending(r => r.RoleId).ThenBy(r => r.RoleName);
           var roles = new PagedList<Role>(query,pageIndex,pageSize);
           return roles;
       }
    }
}
