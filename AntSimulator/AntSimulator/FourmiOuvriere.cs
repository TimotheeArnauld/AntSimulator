using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    class FourmiOuvriere : Fourmi
    {

        public Nourriture nourriturePortee;
        
        public FourmiOuvriere(string nom) : base(nom)
        {
            nourriturePortee = null;
            this.comportement = new ChercherAManger();
            this.comportementBase = new ChercherAManger();
        }

    }
}
