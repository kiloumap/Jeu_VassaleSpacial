using Classes.Starship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Classes.Failures
{
    public abstract class Failure
    {
        public int id { get; set; }
        public int week { get; set; }
        public string typeDamage { get; set; }
        public int damage { get; set; }
        public abstract int life { get; set; }
        public abstract string name { get; set; }
        public double room { get; set; }
        public int active { get; set; }
        public Failure()
        {
            typeDamage = randomType();
            room = randomRoom();
            damage = randDamage(typeDamage);
            active = 1;
        }

        private string randomType()
        {
            string[] type = Enum.GetNames(typeof(TypeDamage));
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int randomEnum = rand.Next(type.Length);
            var res = Enum.Parse(typeof(TypeDamage), type[randomEnum]);
            return res.ToString();
        }

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

    public enum TypeDamage
    {
        DamageToCrew,
        DamageToStarship,
        DamageToRolls
    }
}
