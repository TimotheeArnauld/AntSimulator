using System.Xml.Serialization;

namespace AntSimulator.Objet
{
    [XmlInclude(typeof(Oeuf))]
    [XmlInclude(typeof(PheromoneAbstraite))]
    [XmlInclude(typeof(Nourriture))]
    public abstract class ObjetAbstrait
    {
        [XmlElement("zoneObjet")]
        public ZoneAbstraite position { get; set; }
        [XmlElement("nomObjet")]
        public string nom { get; set; }
        public static int id;

        public ObjetAbstrait()
        {

        }
        public ObjetAbstrait(string nom, ZoneAbstraite position)
        {
            this.position = position;
            this.nom = nom;
            //this.position = new BoutDeTerrain("", position.coordonnes);
        }
    }
}