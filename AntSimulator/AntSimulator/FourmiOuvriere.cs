using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class FourmiOuvriere : Fourmi
    {

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
