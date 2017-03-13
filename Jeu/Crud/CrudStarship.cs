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
    /// Crud starship
    /// </summary>
    public class CrudStarship
    {
        /// <summary>
        /// fonction qui recupere le vaisseau
        /// </summary>
        /// <returns>vaisseau</returns>
        public static Starship getOne()
        {
            return BaseStarship.starship;
        }

        /// <summary>
        /// Fonction qui modifie le vaisseau
        /// </summary>
        /// <param name="life">Vie vaisseau</param>
        public static void modify(int life)
        {
            BaseStarship.starship.life = life;
        }
    }
}
