using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace FausseDb
{
    public static class Crew
    {
        public static List<Character> Data { get; set; }

        static Crew()
        {
            Data = new List<Character>();
            //Data.Add(new Character() { name = "Captain", life = getLife(), rolls = getRolls()});
            //Data.Add(new Character() { name = "Mechanic", life = getLife(), rolls = getRolls()});
            //Data.Add(new Character() { name = "Commander", life = getLife(), rolls = getRolls()});
            //Data.Add(new Character() { name = "Doctor", life = getLife(), rolls = getRolls()});
            Data.Add(new Doctor() { getName = Doctor.name, life = getLife(), rolls = getRolls()});
        }

        private static int getLife()
        {
            Random rand = new Random();
            int life = rand.Next(4, 7);
            return life;
        }

        private static int getRolls()
        {
            Random rand = new Random();
            int rolls = rand.Next(2, 5);
            return rolls;
        }
    }
}
