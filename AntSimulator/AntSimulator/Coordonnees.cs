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
        int x { get; set; }
        [XmlElement("coordonneeY")]
        int y { get; set; }
    }
}
