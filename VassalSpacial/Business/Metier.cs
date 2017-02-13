using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Model;

namespace Business
{
    public class Metier
    {
        public List<string> getAll()
        {
            List<string> res = new List<string>();
            List<Character> character = new List<Character>();

            foreach(Character charac in Crud.getAll())
            {
                res.Add(string.Format("nom = {0}, vie = {1}, dés = {2}, skill = {3}", charac.name, charac.name, charac.rolls, charac.skill));
            }

            return res;
        }
    }
}
