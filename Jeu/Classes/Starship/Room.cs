using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Starship
{
    public class Room
    {
        public string name { get; set; }
        public double position { get; set; }
        public double nextPosition { get; set; }
        public double prevPosition { get; set; }
        public double backRoom { get; set; }
    }
}