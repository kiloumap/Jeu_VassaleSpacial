using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.Crew;

namespace FausseDb
{
    /// <summary>
    /// Base équipier
    /// </summary>
    public static class BaseCrew
    {
        /// <summary>
        /// Liste des équipiers
        /// </summary>
        public static List<Crew> CrewList { get; set; }
        static BaseCrew()
        {
            CrewList = new List<Crew>();
            CrewList.Add(new Doctor()      { id = 1 });
            CrewList.Add(new Mechanic()    { id = 2 });
            CrewList.Add(new Captain()     { id = 3 });
            CrewList.Add(new Commandant()  { id = 4 });
        }
    }
}
