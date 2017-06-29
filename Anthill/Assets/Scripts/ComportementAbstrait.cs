using AntSimulator.Comportement;
using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AntSimulator
{
    
    [XmlInclude(typeof(ChercherAManger))]
    [XmlInclude(typeof(DeplacementAleatoire))]
    [XmlInclude(typeof(RentrerFourmiliere))]
    [XmlInclude(typeof(ComportementChaman))]
    [XmlInclude(typeof(ComportementEclore))]
    [XmlInclude(typeof(PondreOeufs))]

    public abstract class ComportementAbstrait
    {
        [XmlElement("nomComportement")]
        public String nom { get; set; }
        public ComportementAbstrait()
        {
        }
        public abstract List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env);
    }
}
