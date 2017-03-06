using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Failures;
namespace Crud
{
    public class CrudFailure
    {
        public static List<Failure> getAll()
        {
            List<Failure> list = new List<Failure>();
            foreach (Failure item in BaseFailure.FailureList)
            {
                list.Add(item);
            }
            return list;
        }

        public static Failure getOne(int id)
        {
            Failure res = null;
            foreach (Failure item in BaseFailure.FailureList)
            {
                if (item.id == id)
                {
                    res = item;
                }
            }
            return res;
        }

        public static Failure Update(int id, int life)
        {
            Failure item = getOne(id);
            item.life = life;
            return item;
        }
        
        public static void create(string typeOfFailure, int id, int week)
        {
            if (typeOfFailure == "small")
                BaseFailure.FailureList.Add(new Small() { id = id, week = week });
            else if (typeOfFailure == "medium")
                BaseFailure.FailureList.Add(new Medium() { id = id, week = week });
            else if (typeOfFailure == "big")
                BaseFailure.FailureList.Add(new Big() { id = id, week = week });
        }

    }
}
