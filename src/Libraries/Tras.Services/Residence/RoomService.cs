using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tras.Core.Domain.Residence;
using Tras.Core.PagedList;
using Tras.Data.Infrastructure;

namespace Tras.Services.Residence
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Room InsertRoom(Room room)
        {
            if(room==null)
                throw new ArgumentNullException("room");

            return _roomRepository.Insert(room);
        }

        public void UpdateRoom(Room room)
        {
            if(room==null)
                throw new ArgumentNullException("room");
            _roomRepository.Update(room);
        }

        public void DeleteRoom(Room room)
        {
            if(room==null)
                throw new ArgumentNullException("room");

            _roomRepository.Delete(room);
        }

        public Room GetRoomById(int roomId)
        {
            if (roomId == 0)
                return null;
            return _roomRepository.GetById(roomId);
        }

        public IEnumerable<Room> GetRooms()
        {
            return _roomRepository.Table.ToList();
        }

        public IPagedList<Room> GetRooms(int pageSize, int pageIndex, bool showDeleted = false)
        {
            var query = _roomRepository.Table;
            if (!showDeleted)
                query = query.Where(l => l.Deleted == false);
            query = query.OrderByDescending(l => l.RoomId).ThenBy(n => n.RoomName);

            var rooms = new PagedList<Room>(query, pageIndex, pageSize);
            return rooms;
        }
    }
}
