using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Starship;
namespace Crud
{
    /// <summary>
    /// Crud room
    /// </summary>
    public class CrudRoom
    {
        /// <summary>
        /// Fonction qui recupere la liste de salles
        /// </summary>
        /// <returns>la liste des salles</returns>
        public static List<Room> getAll()
        {
            List<Room> list = new List<Room>();
            foreach(Room room in BaseRoom.RoomList)
            {
                list.Add(room);
            }
            return list;
        }

        /// <summary>
        /// Fonction qui récupère une salle
        /// </summary>
        /// <param name="position">position</param>
        /// <returns>une salle</returns>
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
