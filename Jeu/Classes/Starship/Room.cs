using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Starship
{
    /// <summary>
    /// Classe des salles du vaisseau
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Nom de la salle
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Position de la salle (1 : cockpit, 7 : Maintenance)
        /// </summary>
        public double position { get; set; }
        /// <summary>
        /// position de la salle suivante
        /// </summary>
        public double nextPosition { get; set; }
        /// <summary>
        /// position de la salle précedente
        /// </summary>
        public double prevPosition { get; set; }
        /// <summary>
        /// Position d'une salle qui necessite de traverser une premiere salle (4.1 = necessite de traverser la salle 4)
        /// </summary>
        public double backRoom { get; set; }
       
    }
}