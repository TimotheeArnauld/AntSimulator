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
            
            personnage.position = personnage.position.AccesAbstraitList[rnd].accesAbstrait.fin;

            if(personnage.position.ObjetsList.Count != 0)
            {
                //si elle trouve de la nourriture en se deplaçant aléatoirement...
                for(int i=0; i<personnage.position.ObjetsList.Count; i++)
                {
                    if(personnage.position.ObjetsList[i].GetType() == typeof(Nourriture) &&
                        personnage.GetType() == typeof(FourmiOuvriere))
                    {
                        FourmiOuvriere f = (FourmiOuvriere)personnage;
                        Nourriture n = (Nourriture)personnage.position.ObjetsList[i];
                        f.nourriturePortee = n;
                    }
                }
            }
        }
    }
}
