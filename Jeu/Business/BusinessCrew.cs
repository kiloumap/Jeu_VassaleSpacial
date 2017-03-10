using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud;
using Classes.Crew;
using Classes.Starship;
using System.Text.RegularExpressions;

namespace Business
{
    public class BusinessCrew
    {
        public bool checkCrew()
        {
            List<Crew> crew = CrudCrew.getAll();
            int deadMate = 0;
            foreach(Crew mate in crew)
            {
                if (mate.life <= 0)
                {
                    deadMate += 1;
                }
            }
            
            if (deadMate == crew.Count())
                return true;
            else
                return false;
        }

        public void mooveCharac(string charac)
        {
            // On instancie quelques babioles utile
            int id = int.Parse(charac);
            Crew mate = CrudCrew.getOne(id);
            BusinessRoom businessRoom = new BusinessRoom();
            BusinessFailure businessFailure = new BusinessFailure();
            List<Room> listRoom = CrudRoom.getAll();
            // On affiche les salles
            businessRoom.showRooms();
            // Et on indique où se trouve le personnage
            Console.WriteLine("Votre personnage est dans la salle "+mate.room);
            // On lance la methode pour choisir la salle de destination
            double finalRoom = chooseRoom();

            // On deplace le personnage
            if (finalRoom >= 1 || finalRoom <= 7)
            {
                // tant que le personnage n'arrive pas à destination, il continue (sauf si il meurt :O)
                while (finalRoom != mate.room)
                {
                    // cas où on se rends dans une back room
                    if (finalRoom - Math.Truncate(finalRoom) == 0.5)
                    {
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
                    businessFailure.setDamage(id, Convert.ToDouble(mate.room));
                }
            }
        }

        private double chooseRoom()
        {
            Console.WriteLine("Où voulez vous deplacer votre personnage ? ");
            double result = Convert.ToDouble(Console.ReadLine());
            if (result == 4)
                result = 3.5;
            else if (result == 6)
                result = 4.5;
            else
                return result;
            return result;
        }

        public void ShowListCrew()
        {
            List<Crew> list = CrudCrew.getAll();
            int i = 0;
            foreach (Crew item in list)
            {
                Room rRoom = CrudRoom.getOne(item.room);
                i++;
                Console.WriteLine(string.Format(i + " Le {0} a {1} pdv restant, il est dans la salle de {2}", item.name, item.life, rRoom.name));
            }
        }
    }
}