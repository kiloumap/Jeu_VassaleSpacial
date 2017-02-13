using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakdown
{
    public abstract class Breakdown
    {
        public abstract string type { get; set; }

        public abstract string damage { get; set; }
    }


} 
