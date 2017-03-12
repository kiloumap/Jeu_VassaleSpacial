using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Failures
{
    /// <summary>
    /// Classe petite panne (herite de Failure)
    /// </summary>
    public class Small : Failure
    {
        /// <summary>
        /// Nom
        /// </summary>
        public override string name { get; set; }
        /// <summary>
        /// Vie
        /// </summary>
        public override int life { get; set; }
        /// <summary>
        /// On surcharge le nom et la vie (car pas meme point de vie initial selon le type de panne)
        /// </summary>
        public Small()
        {
            name = "petite";
            life = randLife();
        }

        /// <summary>
        /// Aléatoire pour la vie 1 - 11
        /// </summary>
        /// <returns>life</returns>
        private int randLife()
        {
            int life = 0;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            life = rand.Next(1,12);
            return life;
        }
    }
}
