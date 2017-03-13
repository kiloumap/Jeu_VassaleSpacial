using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.Failures;
namespace FausseDb
{
    /// <summary>
    /// Base panne
    /// </summary>
    public static class BaseFailure
    {
        /// <summary>
        /// Liste des pannes
        /// </summary>
        public static List<Failure> FailureList { get; set; }
        static BaseFailure()
        {
            FailureList = new List<Failure>();
            
        }
    }
}
