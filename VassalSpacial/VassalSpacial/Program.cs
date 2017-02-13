using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;

namespace VassalSpacial
{
    class Program
    {
        static void Main(string[] args)
        {
            Serveur Serveur = new Serveur();
            Serveur.getAll();

            Console.ReadLine();
        }
    }
}
