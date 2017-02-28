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
        }

        private int randomize()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int res = rand.Next(2,5);
            return res;
        }

    }
}
