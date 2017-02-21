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

    }
}
