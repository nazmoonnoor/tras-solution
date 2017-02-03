using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Residence;
using Tras.Core.PagedList;

namespace Tras.Services.Residence
{
   public interface IRoomService
    {
       Room InsertRoom(Room room);
       void UpdateRoom(Room room);
       void DeleteRoom(Room room);
       Room GetRoomById(int roomId);
       IEnumerable<Room> GetRooms();
       IPagedList<Room> GetRooms(int pageSize, int pageIndex, bool showDeleted = false);
    }
}
