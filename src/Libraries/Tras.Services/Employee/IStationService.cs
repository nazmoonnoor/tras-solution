using System.Collections.Generic;
using Tras.Core.Domain.Employee;
using Tras.Core.PagedList;

namespace Tras.Services.Employee
{
   public interface IStationService
    {
       Station InsertStation(Station station);
       void UpdateStation(Station station);
       void DeleteStation(Station station);
       Station GetStationById(int stationId);
       IEnumerable<Station> GetStations();
       IPagedList<Station> GetStations(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
