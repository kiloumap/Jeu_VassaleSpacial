using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Failures;
using Classes.Starship;
using Business;

namespace Jeu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!! Bonjour !!");
            int week = 1;
            BusinessJeu.round(week);
            while (true)
            {
                ShowMenu();
                string operation = Console.ReadLine();
                switch (operation)
                {
                    case "1":
                        BusinessStarship starship = new BusinessStarship();
                        starship.ShowStarShip();
                        break;
                    case "2":
                        //ShowListCrew();
                        break;
                    case "3":
                        //ShowListCrew();
                        Console.WriteLine("Quel personnage voulez vous jouer ? ");
                        string charac = Console.ReadLine();
                        CharacAction(charac);
                        break;
                    case "4":
                        week += 1;
                        BusinessJeu.round(week);
                        break;
                    case "9":
                        exit();
                        break;
                    default:
                        break;
                }
            }
        }

        private static bool ShowMenu()
        {
            string Menu1 = "1 : Voir l'état du vaisseau";
            string Menu2 = "2 : Voir l'état des membres d'équipages";
            string Menu3 = "3 : Choisir un membre de l'équipage";
            string Menu4 = "4 : Tour suivant";
            string Menu9 = "9 : Abandonner la partie";
            Console.WriteLine(string.Format("Quelle opération desirez vous faire ? " + Environment.NewLine + "{0}" + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}", Menu1, Menu2, Menu3, Menu4, Menu9));
            return true;
        }

        private static void CharacAction(string charac)
        {
            string Action0 = "0 : Retour";
            string Action1 = "1 : Deplacer le personnage";
            string Action2 = "2 : Réparer la panne un dés";
            string Action3 = "3 : Activer la capacité spécial";
            Console.WriteLine(string.Format("Quelle opération desirez vous faire ? " + Environment.NewLine + "{0}" + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}", Action0, Action1, Action2, Action3 ));
            string choice = Console.ReadLine();
            showCharacMenu(choice, charac);
        }

        private static void showCharacMenu(string choice, string charac)
        {
            BusinessCrew crew = new BusinessCrew();
            switch (choice)
            {
                case "0":
                    break;
                case "1":
                    crew.mooveCharac(charac);
                    CharacAction(charac);
                    break;
                case "2":
                    //useRoll(); // Faire la classe dés + prevoir le stockage dans une propriété boolean
                    CharacAction(charac);
                    break;
                case "3":
                    //useSkill();
                    CharacAction(charac);
                    break;
            }
        }
        private static bool exit()
        {
            Console.WriteLine(string.Format(Environment.NewLine + "!!! Merci, au revoir !!!"));
            Environment.Exit(0);
            return false;
        }
    }
}