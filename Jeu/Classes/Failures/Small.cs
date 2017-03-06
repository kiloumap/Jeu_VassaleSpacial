using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Failures
{
    public class Small : Failure
    {
        public override string name { get; set; }
        public override int life { get; set; }
        public Small()
        {
            name = "petite";
            life = randLife();
        }

        private int randLife()
        {
            int res = 0;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            res = rand.Next(1,12);
            return res;
        }
    }
}
