using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    interface IObservateur
    {
        void actualiser(bool state, EnvironnementAbstrait env);
    }
}
