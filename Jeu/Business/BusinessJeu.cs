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
            checkFailure();
            setRolls();
            gameOver();
            setFailure(week);
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

        private static void checkFailure()
        {
            List<Failure> failures = CrudFailure.getAll();
            foreach (Failure failure in failures)
            {
                if(failure.active == 1)
                {
                    int damage = failure.damage;
                    List<Crew> team = CrudCrew.getAll();
                    Starship starship = CrudStarship.getOne();
                    switch (failure.typeDamage.ToString())
                    {
                        case "DamageToCrew":
                            foreach(Crew mate in team)
                            {
                                int lifeCrew = mate.life - damage;
                                CrudCrew.modify(mate.id, mate.name, lifeCrew, mate.numberRolls, mate.room);
                            }
                            Console.WriteLine("L'équipage à perdu {0} points de vie a cause d'une panne non résolue", damage.ToString());
                            break;
                        case "DamageToStarship":
                            int lifeStarship = starship.life - damage;
                            CrudStarship.modify(lifeStarship);
                            Console.WriteLine("Le vaisseau à perdu {0} points de vie a cause d'une panne non résolue", damage.ToString());
                            break;
                        case "DamageToRolls":
                            foreach(Crew mate in team)
                            {
                                int rolls = mate.numberRolls - damage;
                                CrudCrew.modify(mate.id, mate.name, mate.life, rolls, mate.room);
                            }
                            Console.WriteLine("L'équipage à perdu {0} dés a cause d'une panne non résolue", damage.ToString());
                            break;
                    }
                }
            }
        }

        private static void setRolls()
        {
            List<Crew> crew = CrudCrew.getAll();
            foreach(Crew mate in crew)
            {
                if (mate.numberRolls > 1)
                    mate.numberRolls -= 1;
                else
                    mate.numberRolls = 1;
            }
        }

        private static void setFailure(int week)
        {
            switch (week)
            {
                case 1:
                    CrudFailure.create("big", 1, 1);
                    CrudFailure.create("small", 2, 1);
                    break;
                case 2:
                    CrudFailure.create("small", 3, 2);
                    CrudFailure.create("medium", 4, 2);
                    break;
                case 3:
                    CrudFailure.create("big", 5, 3);
                    CrudFailure.create("small", 6, 3);
                    CrudFailure.create("small", 7, 3);
                    break;
                case 4:
                    CrudFailure.create("medium", 8, 4);
                    CrudFailure.create("medium", 9, 4);
                    break;
                case 5:
                    CrudFailure.create("big", 10, 5);
                    CrudFailure.create("medium", 11, 5);
                    break;
                case 6:
                    CrudFailure.create("big", 12, 6);
                    CrudFailure.create("small", 13, 6);
                    break;
                case 7:
                    CrudFailure.create("big", 14, 7);
                    CrudFailure.create("big", 15, 7);
                    break;
                case 8:
                    CrudFailure.create("medium", 16, 8);
                    CrudFailure.create("medium", 17, 8);
                    CrudFailure.create("small", 18, 8);
                    break;
                case 9:
                    CrudFailure.create("medium", 19, 9);
                    CrudFailure.create("medium", 20, 9);
                    CrudFailure.create("medium", 21, 9);
                    break;
                case 10:
                    CrudFailure.create("medium", 22, 10);
                    break;
            }

        }

    }
}
