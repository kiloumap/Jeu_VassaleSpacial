using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Starship;
namespace FausseDb
{
    public static class BaseRoom
    {
        public static List<Room> RoomList{ get; set; }
        static BaseRoom()
        {
            RoomList = new List<Room>();
            RoomList.Add(new Room() { name = "Cockpit",         position = 1,  prevPosition = 0, nextPosition = 2, backRoom = 0 });
            RoomList.Add(new Room() { name = "Greenhouse",      position = 2,  prevPosition = 1, nextPosition = 3, backRoom = 0 });
            RoomList.Add(new Room() { name = "Infirmary",       position = 3,  prevPosition = 2, nextPosition = 4, backRoom = 3.10 });
            RoomList.Add(new Room() { name = "Laboratory",      position = 3.10,  prevPosition = 0, nextPosition = 3, backRoom = 0 });
            RoomList.Add(new Room() { name = "Relaxation",      position = 4,  prevPosition = 3, nextPosition = 5, backRoom = 4.10 });
            RoomList.Add(new Room() { name = "Survival",        position = 4.10,  prevPosition = 0, nextPosition = 4, backRoom = 0 });
            RoomList.Add(new Room() { name = "Maintenance",     position = 5,  prevPosition = 4, nextPosition = 0, backRoom = 0 });
        }
    }
}
