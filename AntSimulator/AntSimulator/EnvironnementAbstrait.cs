using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlRoot("environnement")]
    [XmlInclude(typeof(BoutDeTerrain))]
    public abstract class EnvironnementAbstrait
    {
        [XmlElement("listeAccesEnvironnement")]
        internal List<AccesAbstrait> AccesAbstraitList { get; set; }
        [XmlElement("listeZoneEnvironnement")]
        internal ZoneAbstraite[,] ZoneAbstraiteList { get; set; }
        [XmlElement("listeObjetEnvironnement")]
        internal List<ObjetAbstrait> ObjetsList { get; set; }
        [XmlElement("listePersonnagesEnvironnement")]
        internal List<PersonnageAbstrait> PersonnagesList { get; set; }

        public EnvironnementAbstrait()
        {
            AccesAbstraitList = new List<AccesAbstrait>();
            ZoneAbstraiteList = new ZoneAbstraite[10, 10];
            ObjetsList = new List<ObjetAbstrait>();
            PersonnagesList = new List<PersonnageAbstrait>();
        }
        public abstract void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray);
        public void AjouteObjet(ObjetAbstrait unObjet)
        {
            ObjetsList.Add(unObjet);
        }
        public void AjouterPersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }
        public void AjouterZoneAbstraite(ZoneAbstraite zoneAbstraite)
        {
            ZoneAbstraiteList[zoneAbstraite.coordonnes.x, zoneAbstraite.coordonnes.y] = zoneAbstraite;
        }
        public abstract void ChargerEnvironnement(FabriqueAbstraite fabrique);
        public abstract void ChargerObjets(FabriqueAbstraite fabrique);
        public abstract void ChargerPersonnages(FabriqueAbstraite fabrique);
        public abstract void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite source,
            ZoneAbstraite destination);
        public abstract string Simuler();
        public abstract string Statistiques();

    }
}
