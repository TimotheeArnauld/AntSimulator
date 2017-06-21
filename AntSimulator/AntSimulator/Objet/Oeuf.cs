using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator.Objet
{
    [XmlRoot("Oeuf")]
    public class Oeuf : ObjetAbstrait
    {
        public Oeuf() : base()
        {

        }
        public Oeuf(string nom, ZoneAbstraite position) : base(nom, position)
        {

        }
    }
}
