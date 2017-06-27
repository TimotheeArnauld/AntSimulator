using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public class SuivrePheromone : ComportementAbstrait
    {
        public SuivrePheromone() : base()
        {

        }
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements = new List<Evenement>();
            if (personnage.position.containsObjet(typeof(Nourriture))) {
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
                if (personnage.position.containsObjet(typeof(Nourriture)))
                    personnage.comportement = new RentrerFourmiliere();
                else
                {
                    DecorateurSupprimerPheromone deco = new DecorateurSupprimerPheromone();
                    deco.ajouterComportement(new RentrerFourmiliere());
                    personnage.comportement = deco;
                }
                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour));
            }

            else
            {
                if (!personnage.position.AccesAbstraitList[personnage.position.getPheromone().direction.direction]
                    .accesAbstrait.getFin(env).ZoneBloquee())
                    personnage.Bouger(
                      personnage.position.AccesAbstraitList[personnage.position.getPheromone().direction.direction]
                         .accesAbstrait.getFin(env));
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.comportement.executer(personnage,env);
                }
                switch (personnage.position.getPheromone().direction.direction)
                {
                    case ((int)FourmiliereConstante.direction.bas): {
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                            break;
                        }

                    case ((int)FourmiliereConstante.direction.haut): {
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                            break;
                        }
                    case ((int)FourmiliereConstante.direction.gauche): {
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                            break;
                        }
                    case ((int)FourmiliereConstante.direction.droite):
                        {
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                            break;
                        }
                       

                }
            }


           return evenements;
        }
    }
}
