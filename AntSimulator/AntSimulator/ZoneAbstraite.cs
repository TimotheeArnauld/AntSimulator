using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(BoutDeTerrain))]
    public abstract class ZoneAbstraite
    {
        [XmlElement("coordonneesZone")]
        Coordonnees coordonnes { get; set; }
        [XmlElement("nomZone")]
        string nom { get; set; }
        [XmlElement("listeObjetsZone")]
        List<ObjetAbstrait> ObjetsList { get; set; }
        [XmlElement("listeAccesZone")]
        List<AccesAbstrait> AccesAbstraitList { get; set; }
        [XmlElement("listePersonnagesZone")]
        List<PersonnageAbstrait> PersonnagesList { get; set; }
        
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