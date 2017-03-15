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
    /// <summary>
    /// Classe business du vaisseau 
    /// Gère tout les traitements du vaisseau
    /// </summary>
    public class BusinessStarship
    {
        /// <summary>
        /// Fonction qui affiche l'état du vaisseau
        /// </summary>
        public void ShowStarShip()
        {
            Starship starship = CrudStarship.getOne();
            BusinessFailure businessFail = new BusinessFailure();
            Console.WriteLine(" Le {0} a {1} point de vie restant", starship.name, starship.life);
            foreach(Failure item in CrudFailure.getAll())
            {
                if(item.active == true)
                {
                    Room room = CrudRoom.getOne(item.room);
                    Console.WriteLine(" Panne n°{0} : {1} panne avec {2} point de vie, occasionne des {3} dans la salle {4}", item.id, item.name, item.life, businessFail.displayNameFailure(item.typeDamage), room.name);
                }
            }
        }

        /// <summary>
        /// Fonction qui verifie si le vaisseau est toujours en vie
        /// </summary>
        /// <returns>true : vaisseau mort, false : vaisseau en vie</returns>
        public bool CheckStarship()
        {
            Starship starship = CrudStarship.getOne();
            if (starship.life <= 0)
                return true;
            else
                return false;
        }
        
    }
}
