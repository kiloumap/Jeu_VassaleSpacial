using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Failures;
using Classes.Starship;
namespace Jeu
{
    class Program
    {
        static void Main(string[] args)
        {
            // TO DO : convertir le montant int en decimal
            Console.WriteLine("!! Bonjour !!");
            ShowMenu();
            while (true)
            {
                string operation = Console.ReadLine();
                switch (operation)
                {
                    case "0":
                        ShowMenu();
                        break;
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        ShowMenu();
                        break;
                    case "3":
                        CharacAction();
                        break;
                    case "9":
                        exit();
                        break;
                    default:
                        ShowMenu();
                        break;
                }
            }
        }

        private static bool ShowMenu()
        {
            string Menu1 = "1 : Voir l'état du vaisseau";
            string Menu2 = "2 : Voir l'état des membres d'équipages";
            string Menu3 = "3 : Choisir un membre de l'équipage";
            string Menu9 = "9 : Abandonner la partie";
            Console.WriteLine(string.Format("Quelle opération desirez vous faire ? " + Environment.NewLine + "{0}" + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}", Menu1, Menu2, Menu3, Menu9));
            return true;
        }

        private static bool CharacAction()
        {
            string Action0 = "0 : Retour";
            string Action1 = "1 : Deplacer le personnage";
            string Action2 = "2 : Lancer un dés";
            string Action3 = "3 : Stocker les dés restant";
            string Action4 = "4 : Activer la capacité spécial";
            Console.WriteLine(string.Format("Quelle opération desirez vous faire ? " + Environment.NewLine + "{0}" + Environment.NewLine + "{1}" + Environment.NewLine + "{2}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}" , Action0, Action1, Action2, Action3, Action4 ));
            return true;
        }

        private static bool exit()
        {
            Console.WriteLine(string.Format(Environment.NewLine + "!!! Merci, au revoir !!!"));
            return false;
        }
    }
}