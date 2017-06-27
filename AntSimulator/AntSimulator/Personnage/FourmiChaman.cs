using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Personnage
{
    class FourmiChaman : Fourmi
    {
        public FourmiChaman() : base()
        {

        }

        public FourmiChaman(String nom, ZoneAbstraite c, int id, EnvironnementAbstrait env) : base(nom, c, id, env)
        {

        }
    }
}
