using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Model;
namespace Server
{
    public class Serveur
    {
        Metier metier = new Metier();
        public void getAll()
        {
            foreach (string character in metier.getAll())
            {
                Console.WriteLine(character);
            }
        }
    }
}
