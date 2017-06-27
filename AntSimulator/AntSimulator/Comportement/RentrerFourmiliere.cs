using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Personnage;
using AntSimulator.Objet.Pheromone;

namespace AntSimulator.Comportement
{
    public class RentrerFourmiliere : ComportementAbstrait
    {
        public RentrerFourmiliere() : base()
        {

        }
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements = new List<Evenement>();
                     
            if (personnage.position.coordonnes.x < FourmiliereConstante.fourmiliere.x)
            {
                ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.getFin(env);
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    pos.AjouteObjet(new PheromoneGauche());
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                }
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.executerComportement(env);
                }
            }
            else if (personnage.position.coordonnes.x > FourmiliereConstante.fourmiliere.x)
            {
                ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.getFin(env);
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                }
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.executerComportement(env);
                }
            }
            else if (personnage.position.coordonnes.y < FourmiliereConstante.fourmiliere.y)
            {
                //haut
                ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.getFin(env);
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                }
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.executerComportement(env);
                }
            }
            else if (personnage.position.coordonnes.y > FourmiliereConstante.fourmiliere.y)
            {
                ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.getFin(env);
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                }
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.executerComportement(env);
                }
            }

            if (personnage.position.coordonnes.equals(FourmiliereConstante.fourmiliere)&&((Fourmi)personnage).nourriturePortee==true)
            {
                evenements.Add(depotNourriture(personnage,env));
                ((Fourmi)personnage).nourriturePortee = false;
                personnage.comportement = new ChercherAManger();
                env.fourmiliere.valeurNutritiveTotalFourmiliere++;

            }
            return evenements;

        }

        public Evenement depotNourriture(PersonnageAbstrait personnage,EnvironnementAbstrait env)
        {
            
            if (personnage.GetType() == typeof(Fourmi))
            {
                ((Fourmi)personnage).nourriturePortee = false;
                personnage.comportement = new ChercherAManger();
                //env.fourmiliere.valeurNutritiveTotalFourmiliere++;
              
            }
            return new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour);

        }
    }
}
