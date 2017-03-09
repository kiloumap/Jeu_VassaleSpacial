using Classes.Starship;
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
        public double room { get; set; }

        public Crew()
        {
            life = randomize();
            numberRolls = randomize();
            room = randRoom();
        }

        private int randomize()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int res = rand.Next(2,5);
            return res;
        }

        private double randRoom()
        {
            List<double> rooms = new List<double>();
            rooms.Add(1);
            rooms.Add(2);
            rooms.Add(3);
            rooms.Add(3.10);
            rooms.Add(4);
            rooms.Add(4.10);
            rooms.Add(5);
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var res = rand.Next(1,rooms.Count-1);
            return Convert.ToDouble(res);
        }

        /*
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
            Cockpit = 1,
            Greenhouse = 2,
            Infirmary = 3,
            Laboratory = 31,
            Relaxation = 4,
            Survival = 41,
            Maintenance = 5
        }
        */
    }
}
