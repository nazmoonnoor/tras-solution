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
    public class RoleMethodService : IRoleMethodService
    {
        private IRepository<RoleMethod> _roleMethodRepository;
        public RoleMethodService(IRepository<RoleMethod> roleMethodRepository )
        {
            _roleMethodRepository = roleMethodRepository;
        }
        public void InsertRoleMethod(RoleMethod roleMethod)
        {
            if(roleMethod==null)
                throw new AggregateException("Role Method");
            _roleMethodRepository.Insert(roleMethod);
        }

        public void UpdateRoleMethod(RoleMethod roleMethod)
        {
            if (roleMethod == null)
                throw new AggregateException("Role Method");
            _roleMethodRepository.Update(roleMethod);
        }

        public void DeleteRoleMethod(RoleMethod roleMethod)
        {
            if (roleMethod == null)
                throw new AggregateException("Role Method");
            _roleMethodRepository.Delete(roleMethod);
        }

        public RoleMethod GetRoleMethodById(int roleMethodId)
        {
            if (roleMethodId == 0)
                return null;
            return _roleMethodRepository.GetById(roleMethodId);
            
        }

        public IPagedList<RoleMethod> GetAllRoleMethods(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _roleMethodRepository.Table;
            if (!showDeleted)
                query = query.Where(u => u.Deleted == false);
            query = query.OrderByDescending(u => u.RoleMethodId).ThenBy(u => u.RoleId);
            var roleMethods = new PagedList<RoleMethod>(query, pageIndex, pageSize);
            return roleMethods;
        }
    }
}
