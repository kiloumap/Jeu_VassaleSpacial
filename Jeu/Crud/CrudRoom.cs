using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Starship;
namespace Crud
{
    public class CrudRoom
    {
        public static List<Room> getAll()
        {
            List<Room> list = new List<Room>();
            foreach(Room room in BaseRoom.RoomList)
            {
                list.Add(room);
            }
            return list;
        }

        public static Room getOne(double position)
        {
            Room res = null;
            foreach(Room item in BaseRoom.RoomList)
            {
                if(item.position == position)
                {
                    res = item;
                }
            }
            return res;
        }
    }
}
