using System.Xml.Serialization;

namespace AntSimulator
{
    public abstract class ObjetAbstrait
    {
        [XmlElement("zoneObjet")]
        ZoneAbstraite position { get; set; }
        [XmlElement("nomObjet")]
        string nom { get; set; }

        public ObjetAbstrait()
        {

        }
    }
}