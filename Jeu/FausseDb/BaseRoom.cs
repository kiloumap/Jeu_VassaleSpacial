using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Starship;
namespace FausseDb
{
    class BaseRoom
    {
        public static Room room{ get; set; }
        static BaseRoom()
        {
            room = new Room();
        }
    }
}
