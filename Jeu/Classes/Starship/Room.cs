using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Starship
{
    public class Room
    {
        public string l1 { get; set; }
        public string l2 { get; set; }
        public string l3 { get; set; }
        public string l4 { get; set; }
        public string l5 { get; set; }
        public Room()
        {
            l1 = " ---------";
            l2 = "|         |";
            l3 = "|         |";
            l4 = "|         |";
            l5 = " ---------";
        }
    }

    public enum Rooms
    {
        Cockpit = 0,
        Serre = 0,
        Infirmary = 0,
        Laboratory = 1,
        Relax = 0,
        Survival = 1,
        Mainteannce = 0
    }
}
