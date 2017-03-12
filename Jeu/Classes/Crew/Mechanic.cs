using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes.Crew
{
    /// <summary>
    /// Classe mecanicien herite de Crew
    /// </summary>
    public class Mechanic : Crew
    {
        /// <summary>
        /// On surcharge le nom
        /// </summary>
        public override string name { get; set; }

        /// <summary>
        /// nom = Mecanicien
        /// </summary>
        public Mechanic()
        {
            name = "mecanicien";
        }
    }
}
