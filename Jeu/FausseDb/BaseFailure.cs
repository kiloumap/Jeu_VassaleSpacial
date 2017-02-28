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
            Random rand = new Random();
            FailureList.Add(new Big()       { id = 1, numSemaine = 1 });
            FailureList.Add(new Small()     { id = 2, numSemaine = 1 });
            FailureList.Add(new Small()     { id = 3, numSemaine = 2 });
            FailureList.Add(new Medium()    { id = 4, numSemaine = 2 });
            FailureList.Add(new Big()       { id = 5, numSemaine = 3 });
            FailureList.Add(new Small()     { id = 6, numSemaine = 3 });
            FailureList.Add(new Small()     { id = 7, numSemaine = 3 });
            FailureList.Add(new Medium()    { id = 8, numSemaine = 4 });
            FailureList.Add(new Medium()    { id = 9, numSemaine = 4 });
            FailureList.Add(new Big()       { id = 10, numSemaine = 5 });
            FailureList.Add(new Medium()    { id = 11, numSemaine = 5 });
            FailureList.Add(new Big()       { id = 12, numSemaine = 6 });
            FailureList.Add(new Small()     { id = 13, numSemaine = 6 });
            FailureList.Add(new Big()       { id = 14, numSemaine = 7 });
            FailureList.Add(new Big()       { id = 15, numSemaine = 7 });
            FailureList.Add(new Small()     { id = 16, numSemaine = 7 });
            FailureList.Add(new Medium()    { id = 20, numSemaine = 9 });
            FailureList.Add(new Medium()    { id = 17, numSemaine = 8 });
            FailureList.Add(new Medium()    { id = 18, numSemaine = 8 });
            FailureList.Add(new Small()     { id = 19, numSemaine = 8 });
            FailureList.Add(new Medium()    { id = 21, numSemaine = 9 });
            FailureList.Add(new Medium()    { id = 22, numSemaine = 9 });
            FailureList.Add(new Medium()    { id = 23, numSemaine = 10 });
        }
    }
}
