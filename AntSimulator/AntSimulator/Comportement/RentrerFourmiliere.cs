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
        public override List<Evenement> executer(PersonnageAbstrait personnage)
        {
            List<Evenement> evenements = new List<Evenement>();
            //j'ai pas encore utilisé les phéromone, dois-je(en allant vers la bouffe) poser les actif ou ceux des directions?!!
            if (personnage.position.coordonnes.x < FourmiliereConstante.fourmiliere.x)
            {
                ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.fin;
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                }
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.executerComportement();
                }
            }
            else if (personnage.position.coordonnes.x > FourmiliereConstante.fourmiliere.x)
            {
                ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.fin;
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                }
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.executerComportement();
                }
            }
            else if (personnage.position.coordonnes.y < FourmiliereConstante.fourmiliere.y)
            {
                //haut
                ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.fin;
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                }
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.executerComportement();
                }
            }
            else if (personnage.position.coordonnes.y > FourmiliereConstante.fourmiliere.y)
            {
                ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.fin;
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                }
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.executerComportement();
                }
            }

            if (personnage.position.coordonnes.equals(FourmiliereConstante.fourmiliere))
            {
                evenements.Add(depotNourriture(personnage));
                
            }
            return evenements;

        }

        public Evenement depotNourriture(PersonnageAbstrait personnage)
        {
            if (personnage.GetType() == typeof(Fourmi))
            {
                ((Fourmi)personnage).nourriturePortee = null;
                personnage.comportement = new ChercherAManger();
              
            }
            return new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour);

        }
    }
}
