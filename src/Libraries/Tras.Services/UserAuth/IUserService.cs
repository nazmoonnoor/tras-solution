using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.UserAuth;
using Tras.Core.PagedList;

namespace Tras.Services.UserAuth
{
    public interface IUserService
    {
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User GetUserById(int userId);
        IPagedList<User> GetAllUsers(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
