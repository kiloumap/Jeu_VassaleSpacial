using Classes.Starship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Crew
{
    /// <summary>
    /// Classe generique d'équipage
    /// </summary>
    public abstract class Crew
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// nom
        /// </summary>
        public abstract string name { get; set; }
        /// <summary>
        /// vie
        /// </summary>
        public int life { get; set; }
        /// <summary>
        /// Position aléatoire d'apparition
        /// </summary>
        public double room { get; set; }
        /// <summary>
        /// Etat de l'équipier true : en vie, false : mort
        /// </summary>
        public bool alive { get; set; }
        /// <summary>
        /// Vie aleatoire 2 - 4
        /// Position de la salle aléatoire
        /// En vie
        /// </summary>
        
        public Crew()
        {
            life = randomize();
            room = randRoom();
            alive = true;
        }

        /// <summary>
        /// Aléatoire pour les points de vie 2 à 4
        /// </summary>
        /// <returns>vie</returns>
        private int randomize()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int life = rand.Next(2,5);
            return life;
        }

        /// <summary>
        /// Aléatoire de la posiitons des salles
        /// </summary>
        /// <returns></returns>
        private double randRoom()
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
            var res = rand.Next(1,rooms.Count-1);
            return Convert.ToDouble(res);
        }
    }
}
