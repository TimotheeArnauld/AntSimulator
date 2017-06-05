using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{

    class Coordonnees
    {
        [XmlElement("coordonneeX")]
        public int x { get; set; }
        [XmlElement("coordonneeY")]
        public int y { get; set; }
    }
}
