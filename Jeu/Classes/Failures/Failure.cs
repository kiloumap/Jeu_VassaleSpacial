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
        public int numSemaine { get; set; }
        public string typeDamage { get; set; }
        public int damage { get; set; }
        public abstract int life { get; set; }
        public abstract string name { get; set; }
        public string nameRoom { get; set; }

        public Failure()
        {
            typeDamage = randomType();
            damage = randDamage(typeDamage);
        }

        private string randomType()
        {
            string[] type = Enum.GetNames(typeof(TypeDamage));
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int randomEnum = rand.Next(type.Length);
            var res = Enum.Parse(typeof(TypeDamage), type[randomEnum]);
            return res.ToString();
        }
        
        private string randomRoom()
        {
            string[] type = Enum.GetNames(typeof(Rooms));
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int randomEnum = rand.Next(type.Length);
            var res = Enum.Parse(typeof(Rooms), type[randomEnum]);
            return res.ToString();
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

    public enum Rooms
    {
        Cockpit = 0,
        Serre = 0,
        Infirmary = 0,
        Laboratory = 1,
        Relax = 0,
        Survival = 1,
        Mainteannce = 0
    }
}

