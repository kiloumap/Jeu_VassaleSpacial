using Classes.Roll;
using FausseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{

    /// <summary>
    /// Crud dé à lancer
    /// </summary>
    public class CrudRollToDraw
    {
        /// <summary>
        /// Fonction qui récupére les dés non lancés
        /// </summary>
        /// <returns>liste de dés</returns>
        public static List<Roll> getAll()
        {
            List<Roll> list = new List<Roll>();
            foreach (Roll item in BaseRoll.RollListToDraw)
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Fonction qui recupere un dé non lancé
        /// </summary>
        /// <param name="id">id du dé</param>
        /// <returns>un dé</returns>
        public static Roll getOne(int id)
        {
            Roll res = null;
            foreach (Roll item in BaseRoll.RollListToDraw)
            {
                if (item.id == id)
                {
                    res = item;
                }
            }
            return res;
        }

        /// <summary>
        /// Fonction qui supprime un dé non lancé
        /// </summary>
        /// <param name="id">id du dé</param>
        public static void deleteOne(int id)
        {
            Roll item = getOne(id);
            BaseRoll.RollListToDraw.RemoveAll(x => x.id == id);
        }

        /// <summary>
        /// Fonction qui ajoute un dé non lancé
        /// </summary>
        /// <param name="id">id dé</param>
        public static void addOne(int id)
        {
            Roll lastRoll = BaseRoll.RollListToDraw.Last();
            BaseRoll.RollListToDraw.Add(new Roll() { id = lastRoll.id + 1, idCrew = id });
        }
    }
}
