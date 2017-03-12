using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Roll
{
    /// <summary>
    /// Classe dés
    /// </summary>
    public class Roll
    {
        /// <summary>
        /// Id 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Valeur
        /// </summary>
        public int value { get; set; }
        /// <summary>
        /// Nombre de fois lancé 0 par défaut
        /// </summary>
        public int NumberOfDrawed { get; set; }
        /// <summary>
        /// Id du posseceur du dés (membre d'équipage)
        /// </summary>
        public int idCrew { get; set; }

        /// <summary>
        /// On mets à 0 la valeur et le nombre de fois lancé
        /// </summary>
        public Roll()
        {
            NumberOfDrawed = 0;
        }
    }

}
