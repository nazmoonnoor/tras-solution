using System.Collections.Generic;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;

namespace Tras.Services.Employee
{
    public interface IDirectorService
    {
        Director InsertDirectory(Director director);
        void UpdateDirector(Director director);
        void DeleteDirector(Director director);
        Director GetDirectorById(int directorId);
        IEnumerable<Director> GetDirectors();
        IPagedList<Director> GetDirectors(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
