﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet.Pheromone
{
    public abstract class PheromoneActive : PheromoneAbstraite
    {
        public PaireDirection direction;
        
        public PheromoneActive()
        {
            this.activePheromone = true;
        }
        public PheromoneActive(string nom, ZoneAbstraite position) : base(nom, position)
        {
            this.activePheromone = true;
        }

    }
}
