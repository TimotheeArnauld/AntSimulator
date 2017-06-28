using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public class DeplacementAleatoire : ComportementAbstrait
    {
        public DeplacementAleatoire() : base()
        {

        }
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements = new List<Evenement>();
            if (!personnage.position.TousAccesBloque(env))
            {
                
                bool zoneTrouvee = false;
                int rnd = 0;
                while (!zoneTrouvee)
                {
                    Random r = new Random((int)DateTime.Now.Ticks);
                    rnd = r.Next(0, 3);
                    if (personnage.position.AccesAbstraitList[rnd] != null && !personnage.position.AccesAbstraitList[rnd].accesAbstrait.getFin(env).ZoneBloquee())
                    {
                        zoneTrouvee = true;

                    }
                }
                
                personnage.Bouger(personnage.position.AccesAbstraitList[rnd].accesAbstrait.getFin(env));
                switch (rnd)
                {
                    case (int)FourmiliereConstante.direction.bas:
                        evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                        break;
                    case (int)FourmiliereConstante.direction.haut:
                        evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                        break;
                    case (int)FourmiliereConstante.direction.gauche:
                        evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                        break;
                    case (int)FourmiliereConstante.direction.droite:
                        evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                        break;
                }
            }
            else
                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour));
            if (personnage.GetType().BaseType == typeof(Fourmi))
            {
                if(((Fourmi)personnage).nourriturePortee==false && personnage.GetType() != typeof(FourmiChaman))
                    personnage.comportement = new ChercherAManger();
                else if(personnage.GetType() == typeof(FourmiChaman))
                {
                    personnage.comportement = new ComportementChaman();
                }
                else
                {
                    personnage.comportement = new RentrerFourmiliere();
                }
            }
            return evenements;
        }
    }
}
