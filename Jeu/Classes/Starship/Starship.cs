using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Starship
{
    public class Starship
    {
        public string name { get; set; }
        public int life { get; set; }

        public Starship()
        {
            name = "VassaleSpacial";
            life = randLife();
        }

        private int randLife()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int res = rand.Next(2,6);
            return res;
        }


    }
}
