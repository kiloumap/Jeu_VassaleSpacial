using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Starship;
namespace FausseDb
{
    public static class BaseStarship
    {
        public static Starship starship { get; set; }
        static BaseStarship()
        {
            starship = new Starship();
        }
    }
}
