using System.Xml.Serialization;

namespace AntSimulator
{
    public abstract class AccesAbstrait
    {
        [XmlElement("zoneAccesDebut")]
        ZoneAbstraite debut { get; set; }
        [XmlElement("zoneAccesFin")]
        ZoneAbstraite fin { get; set; }

        public AccesAbstrait(ZoneAbstraite debut, ZoneAbstraite fin)
        {
            this.debut = debut;
            this.fin = fin;
        }
    }
}