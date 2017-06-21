﻿using AntSimulator.Objet;
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
        public override void executer(PersonnageAbstrait personnage, ObjetAbstrait objet)
        {
            Random r = new Random();
            bool zoneTrouvee = false;
            int rnd=0;
            while (!zoneTrouvee)
            {
                rnd = r.Next(1, 4);
                if (personnage.position.AccesAbstraitList[rnd] != null)
                {
                    zoneTrouvee = true;

                }
            }
                ZoneAbstraite z = personnage.position.AccesAbstraitList[rnd].accesAbstrait.fin;
            /*for (int j = 0, j< z.ObjetsList.Count; j++)
            {
                if (z.ObjetsList[j].GetType() == typeof(PierreObstacle))
                {
                    
                }
            }*/

            if(personnage.position.ObjetsList.Count != 0)
            {
               
                for(int i=0; i<personnage.position.ObjetsList.Count; i++)
                {
                    //si elle trouve de la nourriture en se deplaçant aléatoirement...
                    //la fourmi doit detecter la nourriture, pas y aller aléatoirement
                    if (personnage.position.ObjetsList[i].GetType() == typeof(Nourriture) &&
                        personnage.GetType() == typeof(FourmiOuvriere))
                    {
                        FourmiOuvriere f = (FourmiOuvriere)personnage;
                        Nourriture n = (Nourriture)personnage.position.ObjetsList[i];
                        f.nourriturePortee = n;
                        break;
                    }

                }
            }
        }
    }
}
