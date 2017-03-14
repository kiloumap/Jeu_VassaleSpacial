using Classes.Crew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud;
using Classes;
using Classes.Failures;
using Classes.Starship;
using Classes.Roll;

namespace Business
{
    /// <summary>
    /// Classe business du jeu
    /// Gere le traitement du jeu (tour par tour / gameover)
    /// </summary>
    public static class BusinessJeu
    {

        /// <summary>
        /// Fonction start
        /// </summary>
        public static bool start()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Mayday Mayday, ici le commandant Jay Lapoisse du Vassale Spaciale, nous avons perdus 2 gars,");
            Console.WriteLine("nous sommes en en orbite. Nous avons plus de carburants... A vous");
            Console.WriteLine("Tour de contrôle à commandant Lapoisse, reçu, nous envoyons une capsule de ravitaillement.");
            Console.WriteLine("Elle arrive dans 10 semaines. A vous.");
            Console.WriteLine("Reçu, tour de contrôle, nous avons assez de vivre pour tenir 10 semaines. Depechez vous.");
            Console.WriteLine("Capitaine Jay Lapoisse. Terminé.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("A tout l'équipage, ici capitaine Lapoisse, la tour de contrôle nous envois une capsule,");
            Console.WriteLine("nous devons tenir 10 semaines.");
            Console.WriteLine("Restez vigilan, nous sommes hautement exposés. Nous ne pouvons pas eviter les astéroïdes...");
            Console.WriteLine(" On va y arriver les gars !\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----- Demarrer la partie -----");
            string start = Console.ReadLine();
            if (start == null || start != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Fonction qui gére le tour par tour
        /// </summary>
        /// <param name="week">le numero de la semaine pour créér les panness</param>
        public static void round(int week)
        {
            BusinessFailure failure = new BusinessFailure();
            failure.checkFailure();
            failure.setFailure(week);
            failure.showFailure(week);
            gameOver();

        }
        /// <summary>
        /// Fonction qui verifie si la partie continue 
        /// Si over = true : gameover
        /// </summary>
        public static void gameOver()
        {
            BusinessStarship Starship = new BusinessStarship();
            BusinessCrew Crew = new BusinessCrew();
            bool starShipOver = Starship.CheckStarship();
            bool crewOver = Crew.checkCrew();
            if (starShipOver == true || crewOver == true)
                Console.WriteLine("GAME OVER !!!!!");
                // TO DO : Console.Application.Close(0);
        }
    }
}
