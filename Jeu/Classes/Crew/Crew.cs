using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Crew
{
    public abstract class Crew
    {
        public abstract string name { get; set; }
        public abstract int life { get; set; }
        public abstract int numberRolls { get; set; }
        public string room { get; set; }
    }

}
