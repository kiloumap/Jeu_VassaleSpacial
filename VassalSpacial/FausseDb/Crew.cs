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
            Random rand = new Random();
            Data = new List<Character>();
            Data.Add(new Character() { name = "Captain", life = rand.Next(4, 7), rolls = rand.Next(2, 5) });
            Data.Add(new Character() { name = "Mechanic", life = rand.Next(4, 7), rolls = rand.Next(2, 5) });
            Data.Add(new Character() { name = "Commander", life = rand.Next(4, 7), rolls = rand.Next(2, 5) });
            Data.Add(new Character() { name = "Doctor", life = rand.Next(4, 7), rolls = rand.Next(2, 5) });
            Data.Add(new Doctor() { name = "Thrall thrall", life = rand.Next(4, 7), rolls = rand.Next(2, 5) });
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
