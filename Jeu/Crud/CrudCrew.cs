using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Crew;
namespace Crud
{
    public class CrudCrew
    {
        public static List<Crew> getAll()
        {
            List<Crew> list = new List<Crew>();
            foreach (Crew item in BaseCrew.CrewList)
            {
                list.Add(item);
            }
            return list;
        }

        public static Crew getOne(int id)
        {
            Crew res = null;
            foreach (Crew item in BaseCrew.CrewList)
            {
                if (item.id == id)
                {
                    res = item;
                }
            }
            return res;
        }

        public static Crew modify(int id, string name, int life, int numberRolls, double room)
        {
            Crew item = getOne(id);
            item.name = name;
            item.life = life;
            item.numberRolls = numberRolls;
            item.room = room;
            return item;
        }

        
    }
}
