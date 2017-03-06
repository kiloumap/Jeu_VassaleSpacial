using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Crew
{
    public abstract class Crew
    {
        public int id { get; set; }
        public abstract string name { get; set; }
        public int life { get; set; }
        public int numberRolls { get; set; }
        public string room { get; set; }

        public Crew()
        {
            life = randomize();
            numberRolls = randomize();
            room = randomRoom();
        }

        private int randomize()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int res = rand.Next(2,5);
            return res;
        }
        private string randomRoom()
        {
            string[] room = Enum.GetNames(typeof(Rooms));
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int randomEnum = rand.Next(room.Length);
            var res = Enum.Parse(typeof(Rooms), room[randomEnum]);
            return res.ToString();
        }
        public enum Rooms
        {
            Cockpit,
            Serre,
            Infirmary,
            Laboratory,
            Relax,
            Survival,
            Mainteannce
        }

    }
}
