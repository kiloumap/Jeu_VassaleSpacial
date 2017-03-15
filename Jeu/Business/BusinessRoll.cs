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
    /// <summary>
    /// Classe business dés.
    /// Gére tout les traitements spécifiques des dés
    /// </summary>
    public class BusinessRoll
    {
        
        /// <summary>
        /// Fonction qui supprime des dés au personnage. Dabord les dés non utilisés, ensuite les dés utiliser du plus ancien au plus recent
        /// </summary>
        /// <param name="damage">nombre de dés à supprimer</param>
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

        /// <summary>
        /// Fonction qui affiche le total des dés que possède le personnage
        /// </summary>
        /// <param name="id">id equipier</param>
        /// <returns>le nombre de dés total</returns>
        public int showNbRollSpecificCharac(int id)
        {
            int toDraw = showNbRollToDrawPerCharac(id);
            int drawed = showNbRollDrawedPerCharac(id);
            return toDraw + drawed;
        }

        /// <summary>
        /// Fonction qui affiche le nombre de dés non lancé que possède le personnage
        /// </summary>
        /// <param name="id"></param>
        /// <returns>le nombre de dés non lancé</returns>
        private int showNbRollToDrawPerCharac(int id)
        {
            int i = 0;
            foreach (Roll roll in getRollsToDrawSpecificCharac(id))
            {
                    i++;
            }
            return i;
        }

        /// <summary>
        /// Fonction qui affiche le nombre de dés lancés que possède le personnage
        /// </summary>
        /// <param name="id"></param>
        /// <returns>le nombre de dés lancé</returns>
        private int showNbRollDrawedPerCharac(int id)
        {
            int i = 0;
            foreach (Roll roll in getRollsDrawedSpecificCharac(id))
            {
                i++;
            }
            return i;
        }

        /// <summary>
        /// Fonction qui recupére la liste des dés pas encore lancé
        /// </summary>
        /// <param name="id">id équipier</param>
        /// <returns>Liste des dés pas encore lancé</returns>
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

        /// <summary>
        /// Fonction qui recupére la liste des dés lancés d'un équipier
        /// </summary>
        /// <param name="id">équipier</param>
        /// <returns>Liste des dés lancés au moins une fois</returns>
        public List<Roll> getRollsDrawedSpecificCharac(int id)
        {
            List<Roll> result = new List<Roll>();
            foreach (Roll roll in CrudRollDrawed.getAll())
            {
                if (roll.idCrew == id && roll.NumberOfDrawed < 3)
                    result.Add(roll);
            }
            return result;
        }

        /// <summary>
        /// Fonction qui stock les dés dans la liste des dés stockés, et supprime le dé de la liste des dés non lancés
        /// </summary>
        /// <param name="id">id équipier</param>
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

        /// <summary>
        /// Fonction qui affiche tout les dés du personnage
        /// </summary>
        /// <param name="id">id équipier</param>
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
                Console.WriteLine(" Ce personnage n'a plus de dés");
        }

        /// <summary>
        /// Fonction qui affiche les dés pas encore lancé
        /// </summary>
        /// <param name="id">id équipier</param>
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
                Console.WriteLine(" Ce personnage n'a plus de dés à jouer");
        }

        /// <summary>
        /// Fonction pour afficher les dés stockés
        /// </summary>
        /// <param name="id">id équipier</param>
        public void showRollsdrawed(int id)
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
                Console.WriteLine(" Ce personnage n'a plus de dés");
        }

        /// <summary>
        /// Fonction appelée pour relancer les dés
        /// </summary>
        /// <param name="id">id équipier</param>
        private void drawRollDrawed(int id)
        {
            Console.WriteLine(" Quel dés voulez vous relancer ?");
            int i = 0;
            foreach (Roll roll in getRollsDrawedSpecificCharac(id))
            {
                i++;
                Console.WriteLine(" " + i + " : || dés n° : " + roll.id + " || valeur : " + roll.value + " ||nombre de fois relancé : " + roll.NumberOfDrawed);
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
                        Console.WriteLine(" Le dés {0} à déjà été lancé 3 fois", roll.id);
                }
            }
        }

        /// <summary>
        /// Fonction qui verifie si les dés ont été lancé 3 fois
        /// </summary>
        /// <param name="id">id du mate</param>
        /// <returns>false : tout les dés joués 3 fois, true les dés ont été joué - de 3 fois</returns>
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
                Console.WriteLine(" Tout les dés ont déja été joué 3 fois");
                return false;
            }
            else
                return true;
        }
    }
}
