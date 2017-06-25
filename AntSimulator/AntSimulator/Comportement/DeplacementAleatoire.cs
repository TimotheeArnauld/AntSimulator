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
        Random r = new Random();
        public override List<Evenement> executer(PersonnageAbstrait personnage)
        {
            List<Evenement> evenements = new List<Evenement>();
            if (!personnage.position.TousAccesBloque())
            {
                
                bool zoneTrouvee = false;
                int rnd = 0;
                while (!zoneTrouvee)
                {
                    rnd = r.Next(0, 3);
                    if (personnage.position.AccesAbstraitList[rnd] != null && !personnage.position.AccesAbstraitList[rnd].accesAbstrait.fin.ZoneBloquee())
                    {
                        zoneTrouvee = true;

                    }
                }
                
                personnage.Bouger(personnage.position.AccesAbstraitList[rnd].accesAbstrait.fin);
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
                if(((Fourmi)personnage).nourriturePortee==null)
                    personnage.comportement = new ChercherAManger();
                else
                {
                    personnage.comportement = new RentrerFourmiliere();
                }
            }
            return evenements;
        }
    }
}
