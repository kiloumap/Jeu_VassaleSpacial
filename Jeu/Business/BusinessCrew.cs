using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud;
using Classes.Crew;

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
            string startingRoom = mate.room;
            string nextRoom;
            string finalRoom = showRoom();
            if(startingRoom == "Laboratory")
            {
                nextRoom = "Infirmary";
            }
            else if (startingRoom == "Survival")
            {
                nextRoom = "Relax";
            }

        }

        private string showRoom()
        {
            Console.WriteLine("Où voulez vous deplacer votre personnage ? ");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
