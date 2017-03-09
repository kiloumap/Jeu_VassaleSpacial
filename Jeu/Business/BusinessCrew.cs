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
            int id = int.Parse(charac);
            Crew mate = CrudCrew.getOne(id);
            List<Room> listRoom = CrudRoom.getAll();
          
            double startingPosition = mate.room;
            Console.WriteLine(mate.room.ToString());
            double lastRoom = Convert.ToDouble(Console.ReadLine());
            double currentRoom = 0;
            Regex reg = new Regex(@"\.\d{0,2}");
            while (lastRoom != mate.room)
            {
                foreach(Room rRoom in listRoom)
                {
                    if (mate.room == rRoom.position)
                    {
                        currentRoom = rRoom.position;
                        if (Regex.IsMatch(currentRoom.ToString(), reg.ToString())){
                            mate.room = rRoom.nextPosition;
                        }
                        // On gere le cas où il est en bout de piste
                        if(rRoom.prevPosition == 0)
                        {
                            mate.room = rRoom.nextPosition;
                        }
                        // on gere le cas où il est à la derniere position
                        else if(rRoom.nextPosition == 0)
                        {
                            mate.room = rRoom.prevPosition;
                        }
                        else
                        {
                            if(lastRoom > currentRoom)
                            {
                                mate.room += 1;
                            }
                            else
                            {
                                mate.room -= 1;
                            }
                        }
                    }
                }
            }
        }

        private string showRoom()
        {
            Console.WriteLine("Où voulez vous deplacer votre personnage ? ");
            string choice = Console.ReadLine();
            return choice;
        }

        public void ShowListCrew()
        {
            List<Crew> list = CrudCrew.getAll();
            foreach(Crew item in list)
            {
                Room rRoom = CrudRoom.getOne(item.room);
                Console.WriteLine(string.Format("Le {0} a {1} pdv restant, il est dans la salle de {2}", item.name, item.life, rRoom.name));
            }
        }
    }
}
