using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Employee
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> _unitRepository;

        public UnitService(IRepository<Unit> unitRepository )
        {
            _unitRepository = unitRepository;
        }
        public Unit InsertUnit(Unit cantonment)
        {
            if(cantonment==null)
                throw new ArgumentNullException("unit");

            return _unitRepository.Insert(cantonment);
        }

        public void Updateunit(Unit cantonment)
        {
            if(cantonment==null)
                throw new ArgumentNullException("unit");

            _unitRepository.Update(cantonment);
        }

        public void Deleteunit(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException("unit");

            _unitRepository.Delete(unit);
        }

        public Unit GetunitById(int unitId)
        {
            if (unitId == 0)
                return null;
            return _unitRepository.GetById(unitId);
        }

        public IEnumerable<Unit> GetUnits()
        {
            return _unitRepository.Table.ToList();
        }
        
        public IPagedList<Unit> Getunits(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _unitRepository.Table;
            if (!showDeleted)
                query = query.Where(c =>c.Deleted == false);

            query = query.OrderByDescending(c => c.UnitId).ThenBy(n => n.Name);
            var cantonments = new PagedList<Unit>(query,pageIndex,pageSize);
            return cantonments;
        }

    }
}
