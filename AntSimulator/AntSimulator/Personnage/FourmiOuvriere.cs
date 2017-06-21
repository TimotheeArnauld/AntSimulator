using AntSimulator.Objet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator.Personnage
{
    public class FourmiOuvriere : Fourmi
    {
        [XmlElement("nourriturePortee")]
        public Nourriture nourriturePortee { get; set; }
        
        public FourmiOuvriere(string nom, ZoneAbstraite b) : base(nom, b)
        {
            nourriturePortee = null;
            this.champDeVision = 10;
            this.comportement = new ChercherAManger();

        }
        public FourmiOuvriere() : base()
        {
            nourriturePortee = null;
            this.champDeVision = 10;
            this.comportement = new ChercherAManger();
        }
            
    }
}
