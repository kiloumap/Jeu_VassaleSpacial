﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Starship;
namespace FausseDb
{
    /// <summary>
    /// Base de donné : vaisseau
    /// </summary>
    public static class BaseStarship
    {
        /// <summary>
        /// Vaisseau
        /// </summary>
        public static Starship starship { get; set; }
        static BaseStarship()
        {
            starship = new Starship();
        }
    }
}
