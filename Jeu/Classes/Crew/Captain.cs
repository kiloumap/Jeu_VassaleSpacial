using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes.Crew
{
    /// <summary>
    /// Classe capitaine herite de crew
    /// </summary>
    public class Captain : Crew
    {
        /// <summary>
        /// On surchage le nom
        /// </summary>
        public override string name { get; set; }

        /// <summary>
        /// Nom = Capitaine
        /// </summary>
        public Captain()
        {
            name = "capitaine";
        }
    }
}
