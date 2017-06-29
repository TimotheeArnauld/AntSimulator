using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntSimulator.Objet.Pheromone
{
    public abstract class PheromoneActive : PheromoneAbstraite
    {
        public PaireDirection direction;
        
        public PheromoneActive()
        {
            this.activePheromone = true;
        }
        public PheromoneActive(string nom, ZoneAbstraite position, int id) : base(nom, position,id)
        {
            this.activePheromone = true;
        }

    }
}
