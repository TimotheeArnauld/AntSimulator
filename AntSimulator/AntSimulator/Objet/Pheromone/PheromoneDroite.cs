using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet.Pheromone
{
    public class PheromoneDroite : PheromoneActive
    {
        public PheromoneDroite()
        {

        }
        public PheromoneDroite(string nom, ZoneAbstraite position) : base(nom, position)
        {
            AccesAbstrait acces = null;
            foreach (PaireDirection p in position.AccesAbstraitList)
            {
                if (p.direction == (int)FourmiliereConstante.direction.droite)
                {
                    acces = p.accesAbstrait;
                }
            }
            this.direction = new PaireDirection((int)FourmiliereConstante.direction.droite, acces);
        }
    }
}
