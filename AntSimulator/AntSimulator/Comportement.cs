using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public abstract class Comportement
    {
        String nom { get; set; }

        public abstract void executer();
    }
}
