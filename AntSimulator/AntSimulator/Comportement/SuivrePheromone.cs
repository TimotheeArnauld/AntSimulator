using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public class SuivrePheromone : Comportement
    {
        public override List<Evenement> executer(PersonnageAbstrait personnage)
        {
            List<Evenement> evenements = new List<Evenement>();
            if (personnage.position.containsObjet(typeof(Nourriture)){
                if (personnage.GetType().BaseType == typeof(Fourmi))
                {
                    Fourmi f = (Fourmi)personnage;

                    f.nourriturePortee = personnage.position.getNourriture();
                    personnage.position.getNourriture().valeurNutritive--;
                    if (personnage.position.getNourriture().valeurNutritive == 0)
                    {
                        evenements.Add(new Evenement(personnage.position.getNourriture(), (int)FourmiliereConstante.typeEvenement.destruction));
                        personnage.position.ObjetsList.Remove(personnage.position.getNourriture());

                    }

                }
                personnage.comportement = new RentrerFourmiliere();
                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour));
            }
            else
            {
                personnage.Bouger(
                    personnage.position.AccesAbstraitList[personnage.position.getPheromone().direction.direction]
                    .accesAbstrait.fin);
                switch (personnage.position.getPheromone().direction.direction)
                {
                    case ((int)FourmiliereConstante.direction.bas){
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                            break;
                        }

                    case ((int)FourmiliereConstante.direction.haut){
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                            break;
                        }
                    case ((int)FourmiliereConstante.direction.gauche){
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                            break;
                        }
                    case ((int)FourmiliereConstante.direction.droite){
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                            break;
                        }
                       

                }
            }


           return evenements;
        }
    }
}
