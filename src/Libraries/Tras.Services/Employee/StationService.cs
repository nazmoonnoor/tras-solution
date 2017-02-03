using System;
using System.Collections.Generic;
using System.Linq;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Employee
{
    public class StationService : IStationService
    {
        private readonly IRepository<Station> _stationRepository;

        public StationService(IRepository<Station> stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public Station InsertStation(Station station)
        {
            if(station==null)
                throw new ArgumentNullException("station");
            return _stationRepository.Insert(station);
        }

        public void UpdateStation(Station station)
        {
            if (station == null)
                throw new ArgumentNullException("station");
             _stationRepository.Update(station);
        }

        public void DeleteStation(Station station)
        {
            if (station == null)
                throw new ArgumentNullException("station");
             _stationRepository.Delete(station);
        }

        public Station GetStationById(int stationId)
        {

            if (stationId == 0)
                return null;
            return _stationRepository.GetById(stationId);
        }

        public IEnumerable<Station> GetStations()
        {
            return _stationRepository.Table.ToList();
        }

        public IPagedList<Station> GetStations(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _stationRepository.Table;
            if (!showDeleted)
                query = query.Where(c => c.Deleted == false);

            query = query.OrderByDescending(c => c.StationId).ThenBy(n => n.Name);
            var stations = new PagedList<Station>(query, pageIndex, pageSize);
            return stations;
        }
    }
}
