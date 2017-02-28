using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes.Crew
{
    public class Commandant : Crew
    {
        public override string name { get; set; }

        public Commandant()
        {
            name = "Commandant";
        }
    }
}
