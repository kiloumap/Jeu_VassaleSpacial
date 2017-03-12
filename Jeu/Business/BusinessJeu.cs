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
    public static class BusinessJeu
    {
        public static void round(int week)
        {
            /*
             * On instancie une valeur à 1 avant. 
            Chaque tours on incrémentente cette valeur (=> num semaine)
            On a plusieurs verification à faire : 
                 - Check les pannes existantes
                 - Faire les effets négatifs en fonction des pannes existantes (pertes vie vaisseaux / pertes vie equipages / pertes dés)
                 - Check pdv du vaisseaux
     
            on affiche un speech disant les nouvelles pannes etc...
            */
            BusinessFailure failure = new BusinessFailure();

            failure.checkFailure();

            gameOver();
            failure.setFailure(week);
        }

        public static void gameOver()
        {
            // Methode pour verifier si la partie est perdue ou pas
            // si over = true c'est perdu
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
