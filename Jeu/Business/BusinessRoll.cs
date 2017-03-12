using Classes.Crew;
using Classes.Roll;
using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessRoll
    {
        
        public void removeRollsPerRound(int damage)
        {
            foreach(Crew mate in CrudCrew.getAll())
            {
                for(int i = 0; i < damage; i++)
                {
                    if (showNbRollToDrawPerCharac(mate.id) > 1)
                        CrudRollToDraw.deleteOne(getRollsToDrawSpecificCharac(mate.id).Last().id);
                    else if(showNbRollDrawedPerCharac(mate.id) > 1)
                        CrudRollDrawed.deleteOne(getRollsDrawedSpecificCharac(mate.id).First().id);
                }
            }
        }
        public int showNbRollSpecificCharac(int id)
        {
            int toDraw = showNbRollToDrawPerCharac(id);
            int drawed = showNbRollDrawedPerCharac(id);
            return toDraw + drawed;
        }

        private int showNbRollToDrawPerCharac(int id)
        {
            int i = 0;
            foreach (Roll roll in getRollsToDrawSpecificCharac(id))
            {
                    i++;
            }
            return i;
        }

        private int showNbRollDrawedPerCharac(int id)
        {
            int i = 0;
            foreach (Roll roll in getRollsDrawedSpecificCharac(id))
            {
                i++;
            }
            return i;
        }

        public List<Roll> getRollsToDrawSpecificCharac(int id)
        {
            List<Roll> result = new List<Roll>();
            foreach(Roll roll in CrudRollToDraw.getAll())
            {
                if (roll.idCrew == id)
                    result.Add(roll);
            }
            return result;
        }

        public List<Roll> getRollsDrawedSpecificCharac(int id)
        {
            List<Roll> result = new List<Roll>();
            foreach (Roll roll in CrudRollDrawed.getAll())
            {
                if (roll.idCrew == id)
                    result.Add(roll);
            }
            return result;
        }

        public void drawRoll(int id)
        {
            List<Roll> listRoll = getRollsToDrawSpecificCharac(id);
            if(listRoll.Count() > 0)
            { 
                foreach (Roll roll in listRoll)
                {
                    CrudRollDrawed.addOne(id, roll);
                    CrudRollToDraw.deleteOne(roll.id);
                }
            }
            else
            {
                drawRollDrawed(id);
            }
            showRolls(id);
        }

        public void showRolls(int id)
        {
            List<Roll> toDraw = getRollsToDrawSpecificCharac(id);
            List<Roll> drawed = getRollsDrawedSpecificCharac(id);
            if(toDraw.Count() > 0 || drawed.Count() > 0)
            {
                if (toDraw.Count() > 0)
                {
                    foreach (Roll roll in toDraw)
                    {
                        Console.WriteLine(" dés n° : " + roll.id + " || pas encore lancé ");
                    }
                }
                if (drawed.Count() > 0)
                {
                    foreach (Roll roll in drawed)
                    {
                        if(roll.NumberOfDrawed < 3)
                            Console.WriteLine(" dés n° : " + roll.id + " || valeur : " + roll.value);
                    }
                }
            }
            else
                Console.WriteLine("Ce personnage n'a plus de dés");
        }

        public void showRollstoDraw(int id)
        {
            List<Roll> toDraw = getRollsToDrawSpecificCharac(id);

            if (toDraw.Count() != 0)
            {
                foreach (Roll roll in toDraw)
                {
                    Console.WriteLine("dés n° : " + roll.id + " || pas encore lancé ");
                }
            }
            else
                Console.WriteLine("Ce personnage n'a plus de dés à jouer");
        }

        public void showRollstdrawed(int id)
        {
            List<Roll> drawed = getRollsDrawedSpecificCharac(id);

            if (drawed.Count() != 0)
            {
                foreach (Roll roll in drawed)
                {
                    if (roll.NumberOfDrawed < 3)
                        Console.WriteLine("dés n° : " + roll.id + " || valeur : " + roll.value);
                }
            }
            else
                Console.WriteLine("Ce personnage n'a plus de dés");
        }
        public void drawRollDrawed(int id)
        {
            Console.WriteLine("Quel dés voulez vous relancer ?");
            int i = 0;
            foreach (Roll roll in getRollsDrawedSpecificCharac(id))
            {
                i++;
                Console.WriteLine(i + " : || dés n° : " + roll.id + " || valeur : " + roll.value + " ||nombre de fois relancé : " + roll.NumberOfDrawed);
            }
            if(checkIfDrawed(id) == true)
            {
                char[] array = Console.ReadLine().ToCharArray();
                for (int index = 0; index < array.Length; index++)
                {
                    int idRoll = (int)Char.GetNumericValue(array[index]);
                    Roll roll = CrudRollDrawed.getOne(idRoll);
                    if (roll.NumberOfDrawed < 3)
                    {
                        int NumberOfDrawed = roll.NumberOfDrawed + 1;
                        Random rand = new Random(Guid.NewGuid().GetHashCode());
                        int value = rand.Next(1, 7);
                        CrudRollDrawed.modify(idRoll, value, NumberOfDrawed, id);
                    }
                    else
                        Console.WriteLine("Le dés {0} à déjà été lancé 3 fois", roll.id);
                }
            }
        }

        private bool checkIfDrawed(int id)
        {
            int numberOfDisable = 0;
            foreach(Roll roll in getRollsDrawedSpecificCharac(id))
            {
                if(roll.NumberOfDrawed == 3)
                    numberOfDisable++;
            }
            if (numberOfDisable == getRollsDrawedSpecificCharac(id).Count())
            {
                Console.WriteLine("Tout les dés ont déja été joué 3 fois");
                return false;
            }
            else
                return true;
        }
    }
}
