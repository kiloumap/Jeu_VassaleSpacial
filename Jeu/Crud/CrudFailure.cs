using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Failures;
namespace Crud
{
    /// <summary>
    /// Crud panne
    /// </summary>
    public class CrudFailure
    {

        /// <summary>
        /// Fonction qui return la totalité des pannes
        /// </summary>
        /// <returns>List Panne</returns>
        public static List<Failure> getAll()
        {
            List<Failure> list = new List<Failure>();
            foreach (Failure item in BaseFailure.FailureList)
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Fonction qui return un panne
        /// </summary>
        /// <param name="id">id panne</param>
        /// <returns>panne</returns>
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

        /// <summary>
        /// Fonction qui mets à jour les pannes
        /// </summary>
        /// <param name="id">id panne</param>
        /// <param name="life">vie panne</param>
        public static void Update(int id, int life)
        {
            Failure item = getOne(id);
            item.life = life;
        }
        
        /// <summary>
        /// Fonction qui créé des pannes
        /// </summary>
        /// <param name="typeOfFailure">type de pann</param>
        /// <param name="id">id panne</param>
        /// <param name="week">semaine</param>
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
