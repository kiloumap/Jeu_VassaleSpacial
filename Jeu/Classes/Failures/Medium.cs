using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Failures
{
    public class Medium : Failure
    {
        public override string name { get; set; }
        public override int life { get; set; }
        public Medium()
        {
            name = "Panne moyenne";
            life = randLife();
        }
        private int randLife()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int res = rand.Next(12,24);
            return res;
        }
    }
}
