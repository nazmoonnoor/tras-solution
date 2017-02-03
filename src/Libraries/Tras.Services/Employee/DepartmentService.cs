using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Employee
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public Department InsertDepartment(Department department)
        {
            if(department==null)
                throw new ArgumentNullException("department");
            return _departmentRepository.Insert(department);
        }

        public void UpdateDepartment(Department department)
        {
            if (department==null)
                throw new ArgumentNullException("department");

            _departmentRepository.Update(department);
        }

        public void DeleteDepartment(Department department)
        {
            if(department==null)
                throw new ArgumentNullException("department");
            _departmentRepository.Delete(department);
        }

        public Department GetDepartmentById(int departmentId)
        {
            if (departmentId == 0)
                return null;

            return _departmentRepository.GetById(departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepository.Table.ToList();
        }

        public IPagedList<Department> GetDepartments(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _departmentRepository.Table;
            if (!showDeleted)
                query = query.Where(l => l.Deleted == false);
            query = query.OrderByDescending(l => l.DepartmentId).ThenBy(n => n.Name);

            var lookups = new PagedList<Department>(query, pageIndex, pageSize);
            return lookups;
        }
    }
}
