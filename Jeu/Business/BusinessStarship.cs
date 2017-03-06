using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Classes.Starship;
using Classes.Failures;

namespace Business
{
    public class BusinessStarship
    {
        public void ShowStarShip()
        {
            List<Failure> failure = Crud.CrudFailure.getAll();
            foreach(Failure item in failure)
            {
                Console.WriteLine(string.Format(item.name + " " + item.room + " " + item.typeDamage + "\n"));
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
