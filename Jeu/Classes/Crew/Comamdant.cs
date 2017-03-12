using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes.Crew
{
    /// <summary>
    /// Classe commandant herite de Crew
    /// </summary>
    public class Commandant : Crew
    {
        /// <summary>
        /// On surcharge le nom
        /// </summary>
        public override string name { get; set; }

        /// <summary>
        /// Nom = Commandant
        /// </summary>
        public Commandant()
        {
            name = "commandant";
        }
    }
}
