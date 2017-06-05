using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlRoot("Oeuf")]
    public class Oeuf : ObjetAbstrait
    {
        public Oeuf() : base()
        {

        }
        public Oeuf(string nom) : base(nom)
        {

        }
    }
}
