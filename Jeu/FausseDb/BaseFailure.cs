using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.Failures;
namespace FausseDb
{
    public static class BaseFailure
    {
        public static List<Failure> FailureList { get; set; }
        static BaseFailure()
        {
            FailureList = new List<Failure>();
            
        }
    }
}
