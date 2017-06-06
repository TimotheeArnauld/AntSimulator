using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class PaireDirection
    {
        public Enum direction { get; set; }
        public Chemin chemin { get; set; }

        public PaireDirection(Enum direction, Chemin chemin)
        {
            this.direction = direction;
            this.chemin = chemin;

        }
    }
}
