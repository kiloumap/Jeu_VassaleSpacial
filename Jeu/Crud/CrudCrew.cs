using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Crew;
namespace Crud
{
    /// <summary>
    /// Crud crew
    /// </summary>
    public class CrudCrew
    {
        /// <summary>
        /// Fonction qui return la totalité de l'équipage
        /// </summary>
        /// <returns>List Crew</returns>
        public static List<Crew> getAll()
        {
            List<Crew> list = new List<Crew>();
            foreach (Crew item in BaseCrew.CrewList)
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Fonction qui return un equipier
        /// </summary>
        /// <param name="id">id equipier</param>
        /// <returns>Mate</returns>
        public static Crew getOne(int id)
        {
            Crew res = null;
            foreach (Crew item in BaseCrew.CrewList)
            {
                if (item.id == id)
                {
                    res = item;
                }
            }
            return res;
        }

        /// <summary>
        /// Fonction qui modifie un équipier
        /// </summary>
        /// <param name="id">id équipier</param>
        /// <param name="name">nom équipier</param>
        /// <param name="life">vie équipier</param>
        /// <param name="room">position équipier</param>
        /// <param name="alive">état équipier</param>
        /// <param name="skillUsed">nombre de fois sort spécial équipier</param>
        public static void modify(int id, string name, int life, double room, bool alive, int skillUsed)
        {
            Crew item = getOne(id);
            item.name = name;
            item.life = life;
            item.room = room;
            item.alive = alive;
            item.skillUsed = skillUsed;
        }

        
    }
}
