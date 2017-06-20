using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class DeplacementAleatoire : Comportement
    {
        public override void executer(PersonnageAbstrait personnage, ObjetAbstrait objet)
        {
            Random r = new Random();
            int max = personnage.position.AccesAbstraitList.Count;
            int rnd = r.Next(0, max);
            
            personnage.position = personnage.position.AccesAbstraitList[rnd].accesAbstrait;
        }
    }
}
