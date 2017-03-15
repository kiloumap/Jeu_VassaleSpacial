using Classes.Starship;
using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Classe business Room
    /// Gére tout les traitements des salles
    /// </summary>
    public class BusinessRoom
    {
        /// <summary>
        /// Fonction qui affiche la liste des salles
        /// </summary>
        public void showRooms()
        {
            int i = 0;
            foreach (Room room in CrudRoom.getAll())
            {
                i++;
                Console.WriteLine(string.Format(" " + i + " : Salle " + room.name));
            }
        }

        /// <summary>
        /// Fonction pour connaitre la
        /// </summary>
        /// <param name="position"></param>
        /// <returns>nom de la salle</returns>
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
