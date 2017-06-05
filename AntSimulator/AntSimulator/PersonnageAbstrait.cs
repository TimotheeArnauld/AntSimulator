using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(Fourmi))]
    [XmlInclude(typeof(FourmiGuerriere))]
    [XmlInclude(typeof(FourmiOuvriere))]
    [XmlInclude(typeof(FourmiReine))]

    public abstract class PersonnageAbstrait : IObservateur
    {
        [XmlElement("positionPersonnage")]
        public ZoneAbstraite position;
        [XmlAttribute("nomPersonnage")]
        public String nom {get; set;}
        [XmlElement("viePersonnage")]
        public int pointDeVie{get; set;}
        public Comportement comportement { get; set; }

        public PersonnageAbstrait(String nom)
        {
            this.nom = nom;
        }

        public PersonnageAbstrait()
        {
            this.nom = "test";
        }

        public abstract ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList);

        public abstract void executerComportement();
        public abstract void actualiser(bool etatPluie);
    }
}
