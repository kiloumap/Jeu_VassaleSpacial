using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FausseDb;
using Classes.Failures;
using Classes.Starship;
namespace Jeu
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Failure> list = new List<Failure>();
            foreach(Failure item in BaseFailure.FailureList)
            {
                string res = string.Format(" | Semaine n°{0} | Nom : {1} | Dommage sur : {2} | Dommage : {3} | vie : {4} |", item.numSemaine, item.name, item.typeDamage, item.damage, item.life);
                Console.WriteLine(res);
            }
            Starship starship = new Starship();
            string Vaisseau = string.Format(Environment.NewLine + " | Nom du vaisseau : {0} | Vie restante {1} | ", starship.name, starship.life);

            Console.WriteLine(Vaisseau);
            Console.Read();
        }
    }
}
