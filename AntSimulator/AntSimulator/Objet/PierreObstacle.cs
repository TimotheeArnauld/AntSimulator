using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet
{
    class PierreObstacle : ObjetAbstrait
    {
        public PierreObstacle()
        {

        }
        public PierreObstacle(String nom, ZoneAbstraite position)
        {
            this.position = position;
            this.nom = nom;
        }
    }
}
