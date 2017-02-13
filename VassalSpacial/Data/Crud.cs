using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using FausseDb;

namespace Data
{
    public static class Crud
    {
        public static List<Character> getAll()
        {
            List<Character> liste = new List<Character>();
            foreach(Character charac in Crew.Data)
            {
                liste.Add(charac);
            }
            return liste;
        }

        public static Character getOne(string name)
        {
            Character res = null;
            foreach (Character charac in Crew.Data)
            {
                if (charac.name == name)
                    res = charac;
            }
            return res;
        }
    }
}
