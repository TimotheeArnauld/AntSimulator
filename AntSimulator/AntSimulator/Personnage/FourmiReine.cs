using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Personnage
{
    public class FourmiReine : Fourmi
    {
        public FourmiReine(string nom, ZoneAbstraite b) : base(nom, b)
        {
            this.champDeVision = 0;
        }
        public FourmiReine() : base()
        {
            this.champDeVision = 0;
        }
    }
}
