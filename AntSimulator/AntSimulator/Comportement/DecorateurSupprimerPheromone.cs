using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Personnage;

namespace AntSimulator.Comportement
{
    public class DecorateurSupprimerPheromone : DecorateurComportement
    {
        public DecorateurSupprimerPheromone() : base()
        {

        }
       
        public override List<Evenement> executer(PersonnageAbstrait personnage)
        {
            List<Evenement> evenements=base.executer(personnage);
            personnage.position.SupprimerPheromone();
            return evenements;

        }
    }
}
