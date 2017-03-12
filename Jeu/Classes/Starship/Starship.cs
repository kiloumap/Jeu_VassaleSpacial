using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Starship
{
    /// <summary>
    /// Classe Starship
    /// </summary>
    public class Starship
    {
        /// <summary>
        /// Nom du vaisseau
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Vie du vaisseau
        /// </summary>
        public int life { get; set; }

        /// <summary>
        /// Propriété du vaisseau lors de sa création
        /// Nom VassaleSpacial
        /// Vie : aléatoire entre 2 et 5.
        /// </summary>
        public Starship()
        {
            name = "VassaleSpacial";
            life = randLife();
        }

        /// <summary>
        /// Methode pour générer la vie aleatoire du vaisseau
        /// </summary>
        /// <returns>life</returns>
        private int randLife()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int life = rand.Next(2,6);
            return life;
        }


    }
}
