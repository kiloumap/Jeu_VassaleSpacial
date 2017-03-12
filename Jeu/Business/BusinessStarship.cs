using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Classes.Starship;
using Classes.Failures;
using Crud;

namespace Business
{
    public class BusinessStarship
    {
        public void ShowStarShip()
        {
            List<Failure> failure = CrudFailure.getAll();
            Starship starship = CrudStarship.getOne();
            Console.WriteLine("Le {} à {}", starship.name, starship.life);
            foreach(Failure item in failure)
            {
                Room rRoom = CrudRoom.getOne(item.room);
                string damage = "";
                switch (item.typeDamage)
                {
                    case "DamageToCrew":
                        damage = "dégat sur l'équipage";
                        break;
                    case "DamageToRolls":
                        damage = "dégat sur les dés de l'équipage";
                        break;
                    case "DamageToStarship":
                        damage = "dégat sur le vaisseau";
                        break;
                }
                Console.WriteLine(string.Format("Il y a une " + item.name + " panne dans la salle " + rRoom.name + " qui occasionne des " + damage));
            }
        }

        public bool CheckStarship()
        {
            Starship starship = Crud.CrudStarship.getOne();
            if (starship.life <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
