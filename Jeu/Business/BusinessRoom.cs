using Classes.Starship;
using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessRoom
    {
        public void showRooms()
        {
            int i = 0;
            foreach (Room room in CrudRoom.getAll())
            {
                i++;
                Console.WriteLine(string.Format(i + " : Salle " + room.name));
            }
            Console.WriteLine(Environment.NewLine);
        }

        public string showSpecificRoom(double position)
        {
            string name = "";
            foreach(Room room in CrudRoom.getAll())
            {
                if (room.position == position)
                    name = room.name;
            }
            return name;
        }
    }
}
