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
    /// Crud dés stocké
    /// </summary>
    public class CrudRollDrawed
    {
        public static List<Roll> getAll()
        {
            List<Roll> list = new List<Roll>();
            foreach (Roll item in BaseRoll.RollListDrawed)
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Fonction qui récupere un dés
        /// </summary>
        /// <param name="id">id dé</param>
        /// <returns>Dé</returns>
        public static Roll getOne(int id)
        {
            Roll res = null;
            foreach (Roll item in BaseRoll.RollListDrawed)
            {
                if (item.id == id)
                {
                    res = item;
                }
            }
            return res;
        }

        /// <summary>
        /// Fonction qui modifie un dé stocké
        /// </summary>
        /// <param name="id">id dé stocké</param>
        /// <param name="value">valeur dé stocké</param>
        /// <param name="NumberOfDrawed">nombre de lancé du dé stocké</param>
        /// <param name="idCrew">id propriétaire dés</param>
        public static void modify(int id, int value, int NumberOfDrawed, int idCrew)
        {
            Roll item = getOne(id);
            item.value = value;
            item.NumberOfDrawed = NumberOfDrawed;
            item.idCrew = idCrew;
        }

        /// <summary>
        /// Fonction supprime un dés
        /// </summary>
        /// <param name="id">id du dé</param>
        public static void deleteOne (int id)
        {
            Roll item = getOne(id);
            BaseRoll.RollListDrawed.RemoveAll(x => x.id == id);
        }

        /// <summary>
        /// Fonction qui stock un dé
        /// </summary>
        /// <param name="idCharac">id du propriétaire</param>
        /// <param name="roll">Dé</param>
        public static void addOne(int idCharac, Roll roll)
        {
            int idRoll;
            if (BaseRoll.RollListDrawed.Count() > 0)
                idRoll = BaseRoll.RollListDrawed.Last().id + 1;
            else
                idRoll = 1;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            BaseRoll.RollListDrawed.Add(new Roll() { id = idRoll, idCrew = idCharac, value = rand.Next(1, 7) });
        }
    }
}
