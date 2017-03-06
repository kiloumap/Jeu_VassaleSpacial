using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Starship;

namespace Crud
{
    public class CrudStarship
    {
        public static Starship getOne()
        {
            return BaseStarship.starship;
        }

        public static void modify(int life)
        {
            BaseStarship.starship.life = life;
        }
    }
}
