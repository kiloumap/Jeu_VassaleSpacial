using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud;
using Classes.Crew;
using Classes.Starship;
using System.Text.RegularExpressions;
using Classes.Roll;
using Classes.Failures;

namespace Business
{
    /// <summary>
    /// Classe gérant l'équipage
    /// </summary>
    public class BusinessCrew
    {
        /// <summary>
        /// Function pour verifier que l'équipage soit en vie
        /// </summary>
        /// <returns>true : gameover, false : on continue la partie</returns>
        public bool checkCrewLife()
        {
            int deadMate = 0;
            int numberOfMate = 0;
            foreach (Crew mate in CrudCrew.getAll())
            {
                if (mate.life <= 0)
                    deadMate += 1;
                numberOfMate += 1;
            }
            
            if (deadMate == numberOfMate)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Fonction pour tuer les équipiers
        /// </summary>
        public void killCrew()
        {
            foreach(Crew mate in CrudCrew.getAll())
            {
                if(mate.life <= 0)
                {
                    mate.alive = false;
                    Console.WriteLine(" Le {0} vient est mort",mate.name);
                }
            }
        }

        /// <summary>
        /// Fonction qui affiche un message si on joue un équipier mort
        /// </summary>
        /// <param name="id"></param>
        public void showDeathMate(int id)
        {
            Crew mate = CrudCrew.getOne(id);
            if (mate.alive == false)
                Console.WriteLine(" Ce personnage est mort");
        }

        /// <summary>
        /// Fonction gérant le deplacement de l'équipage
        /// </summary>
        /// <param name="id">l'id de l'équipier à deplacer</param>
        public void mooveCharac(int id)
        {
            // On instancie quelques babioles utile
            Crew mate = CrudCrew.getOne(id);
            BusinessRoom businessRoom = new BusinessRoom();
            BusinessFailure businessFailure = new BusinessFailure();
            List<Room> listRoom = CrudRoom.getAll();
            // On affiche les salles
            businessRoom.showRooms();
            // Et on indique où se trouve le personnage
            int currentRoom = Convert.ToInt32(mate.room);
            if(currentRoom == 3.5)
                currentRoom = 4;
            if (mate.room == 4.5)
                currentRoom = 6;
            Console.WriteLine(" Votre personnage est dans la salle "+ currentRoom);
            // On lance la fonction pour choisir la salle de destination
            double finalRoom = chooseRoom();
            double lastRoom = mate.room;
            // On deplace le personnage
            if (mate.alive == true)
            {
                // tant que le personnage n'arrive pas à destination, il continue (sauf si il meurt :O)
                while (finalRoom != mate.room || mate.alive == false)
                {
                    foreach(Failure failures in businessFailure.getFailureHere(mate.room))
                        businessFailure.setDamage(mate.id, mate.room);
                    // cas où on se rends dans une back room
                    if (finalRoom - Math.Truncate(finalRoom) == 0.5)
                    {
                        if (mate.room - Math.Truncate(mate.room) == 0.5)
                            mate.room -= 0.5;
                        // Une room temporaire pour être sur qu'on s'arrete a la bonne salle avant de tourner dans la back
                        double tempRoom = Math.Truncate(finalRoom);
                        while(mate.room != tempRoom)
                        {
                            // cas où on avance dans le vaisseau
                            if (mate.room < finalRoom)
                                mate.room += 1;
                            // cas où on recule dans le vaisseau
                            else
                                mate.room -= 1;
                        }
                            mate.room += 0.5;
                    }
                    // cas où il part d'une back room
                    else if (mate.room - Math.Truncate(mate.room) == 0.5)
                        mate.room -= 0.5;
                    // cas où cest en ligne droite
                    else
                    {
                        if (mate.room < finalRoom)
                            mate.room += 1;
                        else
                            mate.room -= 1;
                    }
                }
            }
            showDeathMate(id);
        }


        /// <summary>
        /// Fonction privée pour connaître la destination de l'équipier
        /// Converti l'entrée en salle double
        /// </summary>
        /// <returns>le bon format de salle</returns>
        private double chooseRoom()
        {
            Console.WriteLine(" Où voulez vous deplacer votre personnage ? ");
            double result = Convert.ToDouble(Console.ReadLine());
            if (result >= 1 && result <= 7)
            {
                if (result == 4)
                    result = 3.5;
                else if (result == 6)
                    result = 4.5;
                return result;
            }
            else
                Console.WriteLine(" Ce n'est pas une salle valide, veuillez saisir parmis les choix proposés");
            return result;
        }

        /// <summary>
        /// Fonction pour afficher la liste de l'équipage
        /// </summary>
        public void ShowListCrew()
        {
            List<Crew> list = CrudCrew.getAll();
            int i = 0;
            foreach (Crew mate in list)
            {
                if(mate.alive == true)
                {
                    Room room = CrudRoom.getOne(mate.room);
                    BusinessRoll businessRoll = new BusinessRoll();
                    i++;
                    Console.WriteLine(string.Format(" " + i + " Le {0} a {1} pdv restant, il à {2} dés restant, il est dans la salle de {3}", 
                        mate.name, mate.life, businessRoll.showNbRollSpecificCharac(mate.id), room.name));
                }
            }
        }

        /// <summary>
        /// Fonction qui incrémente la propriété skillUsed
        /// </summary>
        /// <param name="id">id équipier</param>
        public void useSkill(int id)
        {
            Crew mate = CrudCrew.getOne(id);
            CrudCrew.modify(mate.id, mate.name, mate.life, mate.room, mate.alive, mate.skillUsed + 1);
        }

        /// <summary>
        /// Fonction qui retourne le nombre de fois où le skill à été utilisé
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int showSkill(int id)
        {
            Crew mate = CrudCrew.getOne(id);
            return mate.skillUsed;
        }

        /// <summary>
        /// Fonction pour reparer les pannes
        /// </summary>
        /// <param name="charac">id du personnage</param>
        public void repair(int charac)
        {
            Crew mate = CrudCrew.getOne(charac);
            BusinessFailure businessFailure = new BusinessFailure();
            BusinessRoll roll = new BusinessRoll();
            businessFailure.displayFailureHere(mate.room);
            if (mate.alive == true)
            {
                if (businessFailure.getFailureHere(mate.room).Count() > 0)
                {
                    if (roll.getRollsDrawedSpecificCharac(charac).Count() > 0)
                    {
                        Console.WriteLine(" Quelle panne voulez vous réparer ?");
                        int choice = int.Parse(Console.ReadLine());
                        roll.showRollsdrawed(charac);
                        Console.WriteLine(" Quelle dés voulez vous utiliser ?");
                        char[] array = Console.ReadLine().ToCharArray();
                        for (int index = 0; index < array.Length; index++)
                        {
                            int idRoll = (int)Char.GetNumericValue(array[index]);
                            Roll rollToSpend = CrudRollDrawed.getOne(idRoll);
                            Failure failure = CrudFailure.getOne(choice);
                            CrudFailure.Update(failure.id, failure.life - rollToSpend.value);
                        }
                    }
                    else if (roll.getRollsToDrawSpecificCharac(charac).Count() > 0)
                    {
                        roll.showRollstoDraw(charac);
                        Console.WriteLine(" Vous n'avez plus de dés stocké, il faut en relancer.");
                    }
                    else
                    {
                        Console.WriteLine(" Vous n'avez plus de dés à utiliser avec ce personnage");
                    }
                }
                else
                    Console.WriteLine(" Il n'y a pas de panne à reparer ici");
            }
            else
                showDeathMate(charac);
        }
       
        /// <summary>
        /// Fonction qui prends en paramètre l'id de l'équipier et qui fait appel au skill spécial de ce dernier
        /// </summary>
        /// <param name="charac">id de l'équipier</param>
        public void specialSkill(int charac)
        {
            Crew mate = CrudCrew.getOne(charac);
            string typeCharac = mate.GetType().ToString();
            if (mate.alive == true)
            {
                switch (typeCharac)
                {
                    case "Classes.Crew.Captain":
                        captainSkill(charac);
                        break;
                    case "Classes.Crew.Commandant":
                        commandantSkill(charac);
                        break;
                    case "Classes.Crew.Doctor":
                        healPlease(charac);
                        break;
                    case "Classes.Crew.Mechanic":
                        repairThis(charac);
                        break;
                }
            }
            else
                showDeathMate(charac);
        }

        /// <summary>
        /// Pouvoir spécial du Mécanicien
        /// Fonction qui répare le vaisseau
        /// </summary>
        private void repairThis(int id)
        {
            Crew mate = CrudCrew.getOne(3);
            if (showSkill(id) >= 2)
                Console.WriteLine(" Ce personnage à déjà lancé sa capacité spécial 3 fois durant ce tour");
            else
            {
                Starship starship = CrudStarship.getOne();
                CrudStarship.modify(starship.life + 1);
                Console.WriteLine(" Féliciation, votre vaisseau a gagné un point de vie, il a maitenant {0}", starship.life);
            }
        }

        /// <summary>
        /// Pouvoir spécial du Docteur
        /// Fonction qui soigne l'équipe
        /// </summary>
        private void healPlease(int id)
        {
            if (showSkill(id) >= 2)
                Console.WriteLine(" Ce personnage à déjà lancé sa capacité spécial 3 fois durant ce tour");
            else
            {
                foreach (Crew mate in CrudCrew.getAll())
                {
                    if(mate.alive == true)
                        CrudCrew.modify(mate.id, mate.name, mate.life + 1, mate.room, mate.alive, mate.skillUsed);
                }
                Console.WriteLine(" Féliciation, chaque équipier à gagner 1 point de vie :");
                ShowListCrew();
            }
        }

        /// <summary>
        /// Pouvoir spécial du Capitaine
        /// Fonction qui rends 1 dés vierge à l'équipage
        /// </summary>
        private void captainSkill(int id)
        {
            if (showSkill(id) >= 2)
                Console.WriteLine(" Ce personnage à déjà lancé sa capacité spécial 3 fois durant ce tour");
            else
            {
                foreach (Crew crew in CrudCrew.getAll())
                {
                    CrudRollToDraw.addOne(crew.id);
                }
                Console.WriteLine(" Féliciation, chaque équipier à gagner un dés :");
                ShowListCrew();
            }
        }

        /// <summary>
        /// Pouvoir spécial du commandant
        /// Fonction qui permet de réparer une panne : inflige 10 de réparation sur la panne
        /// </summary>
        /// <param name="id">id du commandant pour retrouver les pannes atteignables</param>
        private void commandantSkill(int id)
        {
            if (showSkill(id) >= 2)
                Console.WriteLine(" Ce personnage à déjà lancé sa capacité spécial 3 fois durant ce tour");
            else
            {
                Crew mate = CrudCrew.getOne(id);
                double position = mate.room;
                List<Failure> reachableFailure = new List<Failure>();
                foreach (Failure failure in CrudFailure.getAll())
                {
                    if (failure.room == position)
                        reachableFailure.Add(failure);
                }
                foreach (Failure failure in reachableFailure)
                {
                    Room room = CrudRoom.getOne(failure.room);
                    Console.WriteLine(" Il y a la panne n° {0} de type : {1} panne dans la salle {2}", failure.id, failure.name, room.name);
                }
                Console.WriteLine(" Quelle panne voulez vous réparer ?");
                int idFailure = int.Parse(Console.ReadLine());
                Failure toRepair = CrudFailure.getOne(idFailure);
                CrudFailure.Update(idFailure, toRepair.life - 10);
                if (toRepair.life <= 0)
                    Console.WriteLine(" Félicitation, vous avez complétement réparer la panne");
                else
                    Console.WriteLine(" Bon boulot, il reste {0} réparation à faire sur cette panne", toRepair.life);
        }
        }
    }
}