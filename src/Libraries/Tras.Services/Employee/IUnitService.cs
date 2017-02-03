using System.Collections.Generic;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;

namespace Tras.Services.Employee
{
   public interface IUnitService
    {
        Unit InsertUnit(Unit unit);
        void Updateunit(Unit unit);
        void Deleteunit(Unit unit);
        Unit GetunitById(int unitId);
        IEnumerable<Unit> GetUnits();
        IPagedList<Unit> Getunits(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
