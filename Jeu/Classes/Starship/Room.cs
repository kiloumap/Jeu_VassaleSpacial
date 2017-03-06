using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Starship
{
    public class Room
    {
        public Rooms room { get; set; }
        public enum Rooms
        {
            Cockpit,
            Serre,
            Infirmary,
            Laboratory,
            Relax,
            Survival,
            Mainteannce
        }
    }
}