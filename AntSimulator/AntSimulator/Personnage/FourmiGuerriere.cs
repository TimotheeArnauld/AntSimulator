using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Personnage
{
    public class FourmiGuerriere : Fourmi
    {
        public FourmiGuerriere(string nom, ZoneAbstraite b,int id) : base(nom, b,id)
        {
            this.champDeVision = 10;
        }
        public FourmiGuerriere() : base()
        {
            this.champDeVision = 10;
        }
    }
}
