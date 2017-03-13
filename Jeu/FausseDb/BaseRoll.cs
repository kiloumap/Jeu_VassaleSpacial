using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.Roll;

namespace FausseDb
{
    /// <summary>
    /// Base dé
    /// </summary>
    public static class BaseRoll
    {
        /// <summary>
        /// Liste des dé non lancé
        /// </summary>
        public static List<Roll> RollListToDraw { get; set; }
        /// <summary>
        /// Liste des dé lancé
        /// </summary>
        public static List<Roll> RollListDrawed { get; set; }
        static BaseRoll()
        {
            RollListToDraw = new List<Roll>();
            RollListDrawed = new List<Roll>();
            int x = 0;
            // On créé un jeu de dés pour chaque membre d'équipage
            for (int charac = 1; charac <=  4; charac++){
                // on créé un nombre de dés aleatoire differents pour chacun des membres d'équipage
                for (int i = 0; i < randomRollPerCharac(); i++)
                {
                    // On incrémente l'id des dès
                    x++;
                    RollListToDraw.Add(new Roll() { id = x, idCrew = charac });
                }
            }
        }

        private static int randomRollPerCharac()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int res = rand.Next(2, 5);
            return res;
        }
    }
}
