using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(Chemin))]
    public abstract class AccesAbstrait
    {
        [XmlElement("zoneAccesDebut")]
        internal ZoneAbstraite debut { get; set; }
        [XmlElement("zoneAccesFin")]
        internal ZoneAbstraite fin { get; set; }

        public AccesAbstrait(ZoneAbstraite debut, ZoneAbstraite fin)
        {
            this.debut = debut;
            this.fin = fin;
        }
        public AccesAbstrait()
        {

        }
    }
}