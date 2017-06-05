using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{

    public class Coordonnees
    {
        [XmlElement("coordonneeX")]
        internal int x { get; set; }
        [XmlElement("coordonneeY")]
        internal int y { get; set; }

        public Coordonnees(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordonnees()
        {
            Random r = new Random();
            this.x = r.Next(0, 100);
            this.y = r.Next(0, 100);
        }
    }
}
