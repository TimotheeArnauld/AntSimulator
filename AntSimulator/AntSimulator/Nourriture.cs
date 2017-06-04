using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    public class Nourriture : ObjetAbstrait
    {
        [XmlElement("valeurNutritiveNourriture")]
        int valeurNutritive { get; set; }

        public Nourriture():base()
        {
            valeurNutritive = 1;
        }
    }
}
