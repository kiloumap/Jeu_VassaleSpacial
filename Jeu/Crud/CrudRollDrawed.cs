using Classes.Roll;
using FausseDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    public class CrudRollDrawed
    {
        public static List<Roll> getAll()
        {
            List<Roll> list = new List<Roll>();
            foreach (Roll item in BaseRoll.RollListDrawed)
            {
                list.Add(item);
            }
            return list;
        }

        public static Roll getOne(int id)
        {
            Roll res = null;
            foreach (Roll item in BaseRoll.RollListDrawed)
            {
                if (item.id == id)
                {
                    res = item;
                }
            }
            return res;
        }

        public static void modify(int id, int value, int NumberOfDrawed, int idCrew)
        {
            Roll item = getOne(id);
            item.value = value;
            item.NumberOfDrawed = NumberOfDrawed;
            item.idCrew = idCrew;
        }

        public static void deleteOne (int id)
        {
            Roll item = getOne(id);
            BaseRoll.RollListDrawed.RemoveAll(x => x.id == id);
        }

        public static void addOne(int idCharac, Roll roll)
        {
            int idRoll;
            if (BaseRoll.RollListDrawed.Count() > 0)
                idRoll = BaseRoll.RollListDrawed.Last().id + 1;
            else
                idRoll = 1;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            BaseRoll.RollListDrawed.Add(new Roll() { id = idRoll, idCrew = idCharac, value = rand.Next(1, 7) });
        }
    }
}
