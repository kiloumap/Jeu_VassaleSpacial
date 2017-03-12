using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Failures
{
    /// <summary>
    /// Classe grosse panne (herite de Failure)
    /// </summary>
    public class Big : Failure
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
        public Big()
        {
            name = "grosse";
            life = randLife();
        }

        /// <summary>
        /// Aléatoire pour la vie 24 - 35
        /// </summary>
        /// <returns>life</returns>
        private int randLife()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int life = rand.Next(24, 36);
            return life;
        }

       
    }
}
