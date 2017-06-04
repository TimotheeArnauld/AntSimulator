using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    public abstract class PersonnageAbstrait : IObservateur
    {
        [XmlElement("positionPersonnage")]
        ZoneAbstraite position;
        [XmlElement("nomPersonnage")]
        String nom {get; set;}
        int pointDeVie{get; set;}
        protected Comportement comportement { get; set; }

        public PersonnageAbstrait(String nom)
        {
            this.nom = nom;
        }

        public abstract ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList);

        public abstract void executerComportement();
        public abstract void actualiser(bool etatPluie);
    }
}
