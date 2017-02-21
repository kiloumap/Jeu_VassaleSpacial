using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Failures
{
    abstract class Failure
    {
        public string name { get; set; }
        public int damage { get; set; }
        public int damageToDo { get; set; }
    }
}
