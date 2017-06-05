using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    public class FourmiOuvriere : Fourmi
    {
        [XmlElement("nourriturePortee")]
        public Nourriture nourriturePortee;
        
        public FourmiOuvriere(string nom, ZoneAbstraite b) : base(nom, b)
        {
            nourriturePortee = null;
            this.comportement = new ChercherAManger();
        }
        public FourmiOuvriere() : base()
        {
            nourriturePortee = null;
            this.comportement = new ChercherAManger();
        }
            
    }
}
