using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Common;
using Tras.Core.Domain.Employee;
using Tras.Core.Domain.UserAuth;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.UserAuth
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void InsertUser(User user)
        {
            if(user==null)
                throw new AggregateException("User");
            _userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            if(user==null)
                throw new AggregateException("User");
            _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
                throw new AggregateException("User");
            _userRepository.Delete(user);
        }

        public User GetUserById(int userId)
        {
            if (userId == 0)
                return null;
           return _userRepository.GetById(userId);
        }

        public IPagedList<User> GetAllUsers(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _userRepository.Table;
            if (!showDeleted)
                query = query.Where(c => c.Deleted == false);
            query = query.OrderByDescending(d => d.PersonId).ThenBy(d => d.UserName);
            var users = new PagedList<User>(query, pageIndex, pageSize);
            return users;
        }
    }
}
