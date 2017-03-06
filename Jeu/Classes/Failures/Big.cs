using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Failures
{
    public class Big : Failure
    {
        public override string name { get; set; }
        public override int life { get; set; }
        public Big()
        {
            name = "grosse";
            life = randLife();
        }

        private int randLife()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int res = rand.Next(24, 36);
            return res;
        }

       
    }
}
