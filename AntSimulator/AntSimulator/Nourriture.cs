using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class Nourriture : ObjetAbstrait
    {
        private int valeurNutritive { get; set; }

        public Nourriture():base()
        {
            valeurNutritive = 1;
            
        }
    }
}
