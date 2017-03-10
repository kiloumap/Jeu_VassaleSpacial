using Classes.Starship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class BusinessRoom
    {
        public void showRooms()
        {
            int i = 0;
            List<Room> rooms = Crud.CrudRoom.getAll();
            foreach (Room room in rooms)
            {
                i++;
                Console.WriteLine(string.Format(i + " : Salle " + room.name));
            }
            Console.WriteLine(Environment.NewLine);
        }

    }
}
