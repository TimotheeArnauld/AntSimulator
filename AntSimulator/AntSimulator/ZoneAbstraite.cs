using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AntSimulator
{
    public abstract class ZoneAbstraite
    {
        [XmlElement("coordonnees")]
        Coordonnees coordonnes { get; set; }
        [XmlElement("nomZone")]
        string nom { get; set; }
        [XmlElement("listeObjets")]
        List<ObjetAbstrait> ObjetsList { get; set; }
        [XmlElement("listeAcces")]
        List<AccesAbstrait> AccesAbstraitList { get; set; }
        [XmlElement("listePersonnages")]
        List<PersonnageAbstrait> PersonnagesList { get; set; }
        
        public ZoneAbstraite(string unNom)
        {
            nom = unNom;
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