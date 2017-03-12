using Classes.Starship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Failures
{
    /// <summary>
    /// Classe abstraite des pannes
    /// </summary>
    public abstract class Failure
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Semaine d'apparition de la panne
        /// </summary>
        public int week { get; set; }
        /// <summary>
        /// Type de dégat (dégat vaisseau / équipage (vie ou dés))
        /// </summary>
        public string typeDamage { get; set; }
        /// <summary>
        /// dégat de la panne
        /// </summary>
        public int damage { get; set; }
        /// <summary>
        /// vie
        /// </summary>
        public abstract int life { get; set; }
        /// <summary>
        /// nom
        /// </summary>
        public abstract string name { get; set; }
        /// <summary>
        /// Salle d'apparission
        /// </summary>
        public double room { get; set; }
        /// <summary>
        /// status de la panne : default : 1 (1 : panne non corrigée, 0 : panne corrigée)
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// Valeur par défaut :
        /// Type de dégat (aléatoire)
        /// Posiiton de la salle d'apparition (aléatoire) 
        /// Valeur des dégats (aléatoire)
        /// status de la panne (défault 1 pour active)
        /// </summary>
        public Failure()
        {
            typeDamage = randomType();
            room = randomRoom();
            damage = randDamage(typeDamage);
            active = true;
        }

        /// <summary>
        /// Aleatoire du type de dégats
        /// </summary>
        /// <returns>type de degat</returns>
        private string randomType()
        {
            string[] type = Enum.GetNames(typeof(TypeDamage));
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int randomEnum = rand.Next(type.Length);
            var res = Enum.Parse(typeof(TypeDamage), type[randomEnum]);
            return res.ToString();
        }

        /// <summary>
        /// Aléatoire pour la salle
        /// </summary>
        /// <returns>position de la salle</returns>
        private double randomRoom()
        {
            List<double> rooms = new List<double>();
            rooms.Add(1);
            rooms.Add(2);
            rooms.Add(3);
            rooms.Add(3.50);
            rooms.Add(4);
            rooms.Add(4.50);
            rooms.Add(5);
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var res = rand.Next(1, rooms.Count - 1);
            return Convert.ToDouble(res);
        }

        /// <summary>
        /// Aléatoire des dégats
        /// </summary>
        /// <param name="type"></param>
        /// <returns>dégats</returns>
        private int randDamage(string type)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int res = 0;
            if (type == "DamageToCrew" || type == "DamageToStarship")
                res = rand.Next(1, 4);
            else
                res = rand.Next(1, 3);
            return res;
        }
    }

    /// <summary>
    /// Enumeration pour le type de dégats
    /// </summary>
    public enum TypeDamage
    {
        /// <summary>
        /// Dégats sur les membres d'équipage
        /// </summary>
        DamageToCrew,
        /// <summary>
        /// Dégats sur le vaisseau
        /// </summary>
        DamageToStarship,
        /// <summary>
        /// Dégats sur les dés de l'équipage
        /// </summary>
        DamageToRolls
    }
}
