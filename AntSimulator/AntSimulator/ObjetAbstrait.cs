using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(Oeuf))]
    [XmlInclude(typeof(Pheromone))]
    [XmlInclude(typeof(Nourriture))]
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