using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes.Crew
{
    public class Captain : Crew
    {
        public override string name { get; set; }

        public Captain()
        {
            name = "Captain";
        }
    }
}
