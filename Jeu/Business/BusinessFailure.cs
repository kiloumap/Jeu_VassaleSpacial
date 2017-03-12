using Classes.Crew;
using Classes.Failures;
using Classes.Starship;
using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessFailure
    {
        public void displayFailureHere(double room)
        {
            BusinessRoom businessRoom = new BusinessRoom();
            foreach(Failure failure in getFailureHere(room))
            {
                Console.WriteLine(string.Format("Panne n° : {0} -> {1} panne qui inflige {2} dégats {3} dans {4}",failure.id, failure.name, failure.damage, failure.typeDamage, businessRoom.showSpecificRoom(room)));
            }
        }


        public List<Failure> getFailureHere(double room)
        {
            List<Failure> failures = new List<Failure>();
            foreach(Failure failure in CrudFailure.getAll())
            {
                if(failure.room == room && failure.active == true)
                    failures.Add(failure);
            }
            return failures;
        }

        public void setDamage(int id, double room)
        {
            Crew charac = CrudCrew.getOne(id);
            BusinessRoll roll = new BusinessRoll();
            List<Failure> failures = CrudFailure.getAll();
            foreach(Failure failure in failures)
            {
                if(room == failure.room && failure.active == true)
                {
                    if (failure.typeDamage == TypeDamage.DamageToCrew.ToString())
                    {
                        charac.life -= failure.damage;
                        Console.WriteLine("Vous avez traversez une salle avec une panne non résolue. Votre personnage à perdu {0} point de vie", failure.damage);
                    }
                    else if(failure.typeDamage == TypeDamage.DamageToRolls.ToString())
                    {
                        roll.removeRollsPerRound(id);
                        Console.WriteLine("Vous avez traversez une salle avec une panne non résolue. Votre personnage à perdu {0} dès", failure.damage);
                    }
                }
            }
        }

        public void checkFailure()
        {
            List<Failure> failures = CrudFailure.getAll();
            foreach (Failure failure in failures)
            {
                if (failure.active == true)
                {
                    int damage = failure.damage;
                    List<Crew> team = CrudCrew.getAll();
                    Starship starship = CrudStarship.getOne();
                    switch (failure.typeDamage.ToString())
                    {
                        case "DamageToCrew":
                            foreach (Crew mate in team)
                            {
                                int lifeCrew = mate.life - damage;
                                CrudCrew.modify(mate.id, mate.name, lifeCrew, mate.room);
                            }
                            Console.WriteLine("L'équipage à perdu {0} points de vie a cause d'une panne non résolue", damage.ToString());
                            break;
                        case "DamageToStarship":
                            int lifeStarship = starship.life - damage;
                            CrudStarship.modify(lifeStarship);
                            Console.WriteLine("Le vaisseau à perdu {0} points de vie a cause d'une panne non résolue", damage.ToString());
                            break;
                        case "DamageToRolls":
                            BusinessRoll roll = new BusinessRoll();
                            roll.removeRollsPerRound(damage);
                            Console.WriteLine("L'équipage à perdu {0} dés a cause d'une panne non résolue", damage.ToString());
                            break;
                    }
                }
            }
        }

        public string displayNameFailure(string typeDamage)
        {
            string damage = "";
            switch (typeDamage)
            {
                case "DamageToCrew":
                    damage = "dégats sur l'équipage";
                    break;
                case "DamageToRolls":
                    damage = "dégats sur les dés de l'équipage";
                    break;
                case "DamageToStarship":
                    damage = "dégats sur le vaisseau";
                    break;
            }
            return damage;
        }


        public void setFailure(int week)
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
