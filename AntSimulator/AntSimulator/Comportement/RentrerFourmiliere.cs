using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Personnage;

namespace AntSimulator
{
    public class RentrerFourmiliere : Comportement
    {
        public override void executer(PersonnageAbstrait personnage)
        {

            //j'ai pas encore utilisé les phéromone, dois-je(en allant vers la bouffe) poser les actif ou ceux des directions?!!
            if (personnage.position.coordonnes.x < FourmiliereConstante.fourmiliere.x)
            {
                //droite
                personnage.position = personnage.position.AccesAbstraitList[1].accesAbstrait.fin;
            }
            else if (personnage.position.coordonnes.x > FourmiliereConstante.fourmiliere.x)
            {
                //gauche
                personnage.position = personnage.position.AccesAbstraitList[0].accesAbstrait.fin;
            }
            else if (personnage.position.coordonnes.y < FourmiliereConstante.fourmiliere.y)
            {
                //haut
                personnage.position = personnage.position.AccesAbstraitList[2].accesAbstrait.fin;
            }
            else if (personnage.position.coordonnes.y > FourmiliereConstante.fourmiliere.y)
            {
                //bas
                personnage.position = personnage.position.AccesAbstraitList[3].accesAbstrait.fin;
            }

            if (personnage.position.coordonnes.equals(FourmiliereConstante.fourmiliere))
            {

            }


        }

        public void depotNourriture(PersonnageAbstrait personnage)
        {
            if(personnage.GetType() == typeof(FourmiOuvriere))
            {
                FourmiOuvriere f = (FourmiOuvriere)personnage;
                if(f.nourriturePortee != null)
                {
                    //avois accès a la fourmiliere pour déposer ...
                }
            }

        }
    }
}
