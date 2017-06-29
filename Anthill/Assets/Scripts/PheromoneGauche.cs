using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntSimulator.Objet.Pheromone
{
    public class PheromoneGauche : PheromoneActive
    {
        public PheromoneGauche()
        {

        }
        public PheromoneGauche(string nom, ZoneAbstraite position, int id) : base(nom, position,id)
        {
            AccesAbstrait acces = null;
            foreach (PaireDirection p in position.AccesAbstraitList)
            {
                if (p.direction == (int)FourmiliereConstante.direction.gauche)
                {
                    acces = p.accesAbstrait;
                }
            }
            this.direction = new PaireDirection((int)FourmiliereConstante.direction.gauche, acces);
        }
    }
}
