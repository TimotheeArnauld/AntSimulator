using AntSimulator.Objet;
using AntSimulator.Personnage;
using System.Xml.Serialization;

namespace AntSimulator.Fabrique
{
    [XmlInclude(typeof(FabriqueFourmiliere))]
    public abstract class FabriqueAbstraite
    {
        public abstract string Titre { get; }
        public static int id = 0;
        public abstract EnvironnementAbstrait creerEnvironnement();
        public abstract ZoneAbstraite creerZone(string nom, Coordonnees coordonnees);
        public abstract AccesAbstrait creerAcces(ZoneAbstraite debut, ZoneAbstraite fin);
        public abstract PersonnageAbstrait creerPersonnage(string nom,int typeFourmi, ZoneAbstraite zoneFourmiliere);
        public abstract ObjetAbstrait creerObjet(string nom, int TypeObjet, ZoneAbstraite coordonnes);


    }
}