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
        List<AccesAbstrait> AccesAbstraitList { get; set; }
        [XmlElement("listeZoneEnvironnement")]
        List<ZoneAbstraite> ZoneAbstraiteList { get; set; }
        [XmlElement("listeObjetEnvironnement")]
        List<ObjetAbstrait> ObjetsList { get; set; }
        [XmlElement("listePersonnagesEnvironnement")]
        List<PersonnageAbstrait> PersonnagesList { get; set; }

        public EnvironnementAbstrait()
        {

        }
        public void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray)
        {

        }
        public void AjouteObjet(ObjetAbstrait unObjet)
        {
            ObjetsList.Add(unObjet);
        }
        public void AjouterPersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }
        public void AjouterZoneAbstraite(params ZoneAbstraite[] zoneAbstraiteArray)
        {

        }
        public void ChargerEnvironnement(FabriqueAbstraite fabrique)
        {

        }
        public void ChargerObjets(FabriqueAbstraite fabrique)
        {

        }
        public void ChargerPersonnages(FabriqueAbstraite fabrique)
        {

        }
        public void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite source, 
            ZoneAbstraite destination)
        {
            
        }
        public string Simuler()
        {
            return "";
        }
        public string Statistiques()
        {
            return "";
        }

    }
}
