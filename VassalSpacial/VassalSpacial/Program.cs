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
            showMenu();

            Console.ReadLine();
        }

        static void showMenu()
        {
            Serveur Serveur = new Serveur();
            string menu1 = "1 : Voir l'état de son vaisseau";
            string menu2 = "2 : Voir les membres de l'équipage";
            string menu3 = "3 : Assigner un membre d'équipage à un module";
            string menu4 = "4 : Lancer les dés";
            string menu5 = "5 : Activer une capacité spécial";
            Console.WriteLine("Que voulez vous faire : ");
            Console.WriteLine(menu1 + Environment.NewLine + menu2 + Environment.NewLine + menu3 + Environment.NewLine + menu4 + Environment.NewLine + menu5);
            string menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                    break;
                case "2":
                    Serveur.getAll();
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            }
        }
    }
}
