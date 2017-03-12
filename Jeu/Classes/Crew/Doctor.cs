using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes.Crew
{
    /// <summary>
    /// Classe Docteur herite de Crew
    /// </summary>
    public class Doctor : Crew
    {
        /// <summary>
        /// On surcharge le nom
        /// </summary>
        public override string name { get; set; }

        /// <summary>
        /// nom = Docteur
        /// </summary>
        public Doctor()
        {
            name = "docteur";
        }
    }
}
