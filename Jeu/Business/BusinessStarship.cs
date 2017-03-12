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
            BusinessFailure fail = new BusinessFailure();
            Console.WriteLine("Le {0} a {1} point de vie restant", starship.name, starship.life);
            foreach(Failure item in failure)
            {
                Room rRoom = CrudRoom.getOne(item.room);
                Console.WriteLine("{0} panne avec {1} point de vie, occasionne des {2} dans la salle {3}", item.name, item.life, fail.displayNameFailure(item.typeDamage), rRoom.name);
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
