using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoomService
    {
        public void SelectAvaibleRooms(Accommodation accommodation, ObservableCollection<Room> rooms)
        {
            rooms.Clear();
            using (HotelContext ctx = new HotelContext())
            {
                var innerQuery = from r in ctx.Rooms
                                 join a in ctx.Accommodations.Where
                                 (s => !(s.StartDate >= accommodation.EndDate
                                 || s.EndDate <= accommodation.StartDate))
                                 on r.Number equals a.Room.Number
                                 select new
                                 {
                                     number = a.Room.Number,
                                     capacity = a.Room.Capacity,
                                     price = a.Room.Price
                                 };

                var query = from r in ctx.Rooms
                            select new
                            {
                                number = r.Number,
                                capacity = r.Capacity,
                                price = r.Price
                            };

                var result = query.Except(innerQuery);

                foreach (var item in result)
                {
                    rooms.Add(new Room(item.number, item.capacity, item.price));
                }
            }
        }

        public bool ContainRoom(ObservableCollection<Room> rooms, Room room)
        {
            int i = 0;

            foreach (var item in rooms)
            {
                if (item.Number == room.Number)
                {
                    i++;
                }
            }
            if (i == 1)
                return true;
            else return false;
        }
    }
}
