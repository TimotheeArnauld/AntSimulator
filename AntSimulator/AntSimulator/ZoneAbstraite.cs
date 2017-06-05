using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(BoutDeTerrain))]
    public abstract class ZoneAbstraite
    {
        [XmlElement("coordonneesZone")]
        internal Coordonnees coordonnes { get; set; }
        [XmlElement("nomZone")]
        internal string nom { get; set; }
        [XmlElement("listeObjetsZone")]
        internal List<ObjetAbstrait> ObjetsList { get; set; }
        [XmlElement("listeAccesZone")]
        internal List<AccesAbstrait> AccesAbstraitList { get; set; }
        [XmlElement("listePersonnagesZone")]
        internal List<PersonnageAbstrait> PersonnagesList { get; set; }
        
        public ZoneAbstraite(string unNom)
        {
            nom = unNom;
        }
        public ZoneAbstraite()
        {
            nom = "nom par defaut";
        }
       
        public void AjouteAcces(AccesAbstrait acces)
        {
            AccesAbstraitList.Add(acces);
        }
        public void AjouteObjet(ObjetAbstrait objet)
        {
            ObjetsList.Add(objet);
        }
        public void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }
        public void RetirePersonnage(PersonnageAbstrait unPersonnage)
        {
            if (!PersonnagesList.Contains(unPersonnage))
            {
                Console.WriteLine("Ce Personnage n'existe pas dans la liste");
            }
            PersonnagesList.Remove(unPersonnage);
        }

    }
}