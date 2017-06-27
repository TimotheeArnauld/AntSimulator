using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Personnage
{
    public class FourmiGuerriere : Fourmi
    {
        public FourmiGuerriere(string nom, ZoneAbstraite b,int id,EnvironnementAbstrait env) : base(nom, b,id,env)
        {
            this.champDeVision = 10;
        }
        public FourmiGuerriere() : base()
        {
            this.champDeVision = 10;
        }
    }
}
