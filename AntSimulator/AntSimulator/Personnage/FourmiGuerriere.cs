using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Personnage
{
    public class FourmiGuerriere : Fourmi
    {
        public FourmiGuerriere(string nom, ZoneAbstraite b) : base(nom, b)
        {
            this.champDeVision = 20;
        }
        public FourmiGuerriere() : base()
        {
            this.champDeVision = 20;
        }
    }
}
