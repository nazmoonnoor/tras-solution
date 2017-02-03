using System.Collections.Generic;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;

namespace Tras.Services.Employee
{
   public interface IDepartmentService
    {
        Department InsertDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
        Department GetDepartmentById(int departmentId);
        IEnumerable<Department> GetDepartments();
        IPagedList<Department> GetDepartments(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
