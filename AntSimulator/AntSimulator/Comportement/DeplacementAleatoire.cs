using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class DeplacementAleatoire : Comportement
    {
        public override void executer(PersonnageAbstrait personnage)
        {
            if (!personnage.position.TousAccesBloque())
            {
                Random r = new Random();
                bool zoneTrouvee = false;
                int rnd = 0;
                while (!zoneTrouvee)
                {
                    rnd = r.Next(1, 4);
                    if (personnage.position.AccesAbstraitList[rnd] != null && !personnage.position.AccesAbstraitList[rnd].accesAbstrait.fin.ZoneBloquee())
                    {
                        zoneTrouvee = true;

                    }
                }
                //changement de la position aléatoirement...testé, ça FONCTIONNE
                personnage.Bouger(personnage.position.AccesAbstraitList[rnd].accesAbstrait.fin);
            }
        }
    }
}
