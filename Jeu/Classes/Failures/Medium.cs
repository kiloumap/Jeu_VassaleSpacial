using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Failures
{
    /// <summary>
    /// Classe moyenne panne (herite de Failure)
    /// </summary>
    public class Medium : Failure
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
        public Medium()
        {
            name = "moyenne";
            life = randLife();
        }
        /// <summary>
        /// Aléatoire pour la vie 12 - 23
        /// </summary>
        /// <returns>life</returns>
        private int randLife()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int life = rand.Next(12,24);
            return life;
        }
    }
}
