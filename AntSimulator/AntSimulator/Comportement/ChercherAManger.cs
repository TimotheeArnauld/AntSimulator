using AntSimulator.Objet;
using AntSimulator.Objet.Pheromone;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public class ChercherAManger : ComportementAbstrait
    {
        public ChercherAManger() : base()
        {

        }   
        public override List<Evenement> executer(PersonnageAbstrait personnage,EnvironnementAbstrait env)
        {
            List<Evenement> evenements = new List<Evenement>();
            if (personnage.position.containsObjet(typeof(Nourriture)))
            {
                Console.WriteLine("in");
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
                
            ZoneAbstraite zoneOuAller = this.repererZone(personnage, typeof(PheromoneDroite), env);
            if (zoneOuAller == null)
                    zoneOuAller = this.repererZone(personnage, typeof(PheromoneGauche), env);
            if (zoneOuAller == null)
                    zoneOuAller = this.repererZone(personnage, typeof(PheromoneHaut), env);
            if (zoneOuAller == null)
                    zoneOuAller = this.repererZone(personnage, typeof(PheromoneBas), env);
            if (zoneOuAller==null)
                zoneOuAller=this.repererZone(personnage, typeof(Nourriture),env);
                else
                {
                    personnage.comportement = new SuivrePheromone();
                }
            if (zoneOuAller == null)
            {
                personnage.comportement = new DeplacementAleatoire();
                personnage.executerComportement(env);
            }
            else
            {
                
                    int diffX = personnage.position.coordonnes.x - zoneOuAller.coordonnes.x;
                    int diffY = personnage.position.coordonnes.y - zoneOuAller.coordonnes.y;
                    if (diffX < 0)
                    {
                        //droite
                        ZoneAbstraite pos = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.getFin(env);
                        if (!pos.ZoneBloquee())
                        {
                            personnage.Bouger(pos);
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                        }
                        else
                        {
                            personnage.comportement = new DeplacementAleatoire();
                            personnage.executerComportement(env);
                        }
                    }
                    else if (diffX > 0)
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
                        };
                    }
                    else if (diffY < 0)
                    {
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
                    else if (diffY > 0)
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


                }
            }
            return evenements;

        }

        
        public ZoneAbstraite repererZone(PersonnageAbstrait personnage,Type type,EnvironnementAbstrait env)
        {
            //champs de vision
            int champsVision = personnage.champDeVision;
            ZoneAbstraite pos = personnage.position;
            ZoneAbstraite zoneTrouvee = null;
            if (pos.containsObjet(type))
            {
                zoneTrouvee = pos;
            }
            for (int i = -1 * champsVision; i <= champsVision && i >= -1 * champsVision && zoneTrouvee == null; i++)
            {
                bool iOk = false;
                if (i < 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche] != null)
                {
                    pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.getFin(env);
                    iOk = true;
                }
                else if (i > 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.droite] != null)
                {
                    pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.getFin(env);
                    iOk = true;
                }
                else if (i == 0)
                {
                    iOk = true;
                }
                if (pos.containsObjet(type)|| pos.containsObjet(type.BaseType))
                    zoneTrouvee = pos;
                if (iOk)
                {
                    for (int j = -1 * champsVision; j <= champsVision && j >= -1 * champsVision && zoneTrouvee == null; j++)
                    {
                        if (j < 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas] != null)
                        {
                            pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.getFin(env);
                        }
                        else if (j > 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut] != null)
                        {
                            pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.getFin(env);
                        }
                         if (pos.containsObjet(type))
                            zoneTrouvee = pos;

                    }
                }
            }
            /*if(zoneNourriture!=null)
                personnage.position = zoneNourriture;*/

            return zoneTrouvee;
        }
       

    }
}
