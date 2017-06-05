using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(Oeuf))]
    [XmlInclude(typeof(Pheromone))]
    [XmlInclude(typeof(Nourriture))]
    public abstract class ObjetAbstrait
    {
        [XmlElement("zoneObjet")]
        public ZoneAbstraite position { get; set; }
        [XmlElement("nomObjet")]
        public string nom { get; set; }

        public ObjetAbstrait()
        {

        }
        public ObjetAbstrait(string nom)
        {
            this.nom = nom;
        }
    }
}