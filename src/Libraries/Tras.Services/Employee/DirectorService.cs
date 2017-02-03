using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Employee
{
    public class DirectorService : IDirectorService
    {
        private readonly IRepository<Director> _directorRepository;

        public DirectorService(IRepository<Director> directorRepository)
        {
            _directorRepository = directorRepository;
        }
        public Director InsertDirectory(Director director)
        {
            if (director==null)
                throw new ArgumentNullException("director");
            return _directorRepository.Insert(director);

        }

        public void UpdateDirector(Director director)
        {
            if (director==null)
                throw new ArgumentNullException("director");
            _directorRepository.Update(director);
        }

        public void DeleteDirector(Director director)
        {
            if (director == null)
                throw new ArgumentNullException("director");
            _directorRepository.Delete(director);
        }

        public Director GetDirectorById(int directorId)
        {
            if (directorId == 0)
                return null;
            return _directorRepository.GetById(directorId);
        }

        public IEnumerable<Director> GetDirectors()
        {
            return _directorRepository.Table.ToList();
        }

        public IPagedList<Director> GetDirectors(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _directorRepository.Table;
            if (!showDeleted)
                query = query.Where(c => c.Deleted == false);
            query = query.OrderByDescending(d => d.DirectorId).ThenBy(d => d.Name);
            var directors = new PagedList<Director>(query,pageIndex,pageSize);
            return directors;
        }
    }
}
