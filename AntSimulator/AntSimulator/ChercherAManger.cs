using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class ChercherAManger : Comportement
    {
        public override void executer(PersonnageAbstrait personnage, ObjetAbstrait objet)
        {
            int diffX = personnage.position.coordonnes.x - objet.position.coordonnes.x;
            int diffY = personnage.position.coordonnes.y - objet.position.coordonnes.y;
            if(diffX < 0)
            {

            }
            
        }
    }
}
