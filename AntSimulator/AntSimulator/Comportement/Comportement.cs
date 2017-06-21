using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(ChercherAManger))]
    [XmlInclude(typeof(DeplacementAleatoire))]
    public abstract class Comportement
    {
        [XmlElement("nomComportement")]
        public String nom { get; set; }

        public abstract void executer(PersonnageAbstrait personnage, ObjetAbstrait objet);
    }
}
