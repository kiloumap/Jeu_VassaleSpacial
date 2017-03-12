using Classes.Roll;
using FausseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    public class CrudRollToDraw
    {
        public static List<Roll> getAll()
        {
            List<Roll> list = new List<Roll>();
            foreach (Roll item in BaseRoll.RollListToDraw)
            {
                    list.Add(item);
            }
            return list;
        }

        public static Roll getOne(int id)
        {
            Roll res = null;
            foreach (Roll item in BaseRoll.RollListToDraw)
            {
                if (item.id == id)
                {
                    res = item;
                }
            }
            return res;
        }

        public static Roll modify(int id, int value, int NumberOfDrawed, int idCrew)
        {
            Roll item = getOne(id);
            return item;
        }

        public static void deleteOne(int id)
        {
            Roll item = getOne(id);
            BaseRoll.RollListToDraw.RemoveAll(x => x.id == id);
        }

        public static void addOne(int id)
        {
            Roll lastRoll = BaseRoll.RollListToDraw.Last();
            BaseRoll.RollListToDraw.Add(new Roll() { id = lastRoll.id + 1, idCrew = id });
        }
    }
}
