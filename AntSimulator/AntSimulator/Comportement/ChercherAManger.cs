using AntSimulator.Objet;
using AntSimulator.Objet.Pheromone;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class ChercherAManger : Comportement
    {
        
        public override List<Evenement> executer(PersonnageAbstrait personnage)
        {

            List<Evenement> evenements = new List<Evenement>();
            ZoneAbstraite zoneOuAller = this.repererZone(personnage, typeof(PheromoneActive));
            if(zoneOuAller==null)
                zoneOuAller=this.repererZone(personnage, typeof(Nourriture));
            if (zoneOuAller == null)
            {
                personnage.comportement = new DeplacementAleatoire();
                personnage.executerComportement();
            }
            else
            {
                if (personnage.position.coordonnes.equals(zoneOuAller.coordonnes))
                {
                    if (personnage.GetType() == typeof(FourmiOuvriere))
                    {
                        FourmiOuvriere f = (FourmiOuvriere)personnage;

                        f.nourriturePortee = zoneOuAller.getNourriture();
                        zoneOuAller.getNourriture().valeurNutritive--;
                        if (zoneOuAller.getNourriture().valeurNutritive == 0)
                        {
                            evenements.Add(new Evenement(zoneOuAller.getNourriture(), (int)FourmiliereConstante.typeEvenement.destruction));
                            zoneOuAller.ObjetsList.Remove(zoneOuAller.getNourriture());

                        }

                    }
                    personnage.comportement = new RentrerFourmiliere();
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour));
                }
                else
                {
                    int diffX = personnage.position.coordonnes.x - zoneOuAller.coordonnes.x;
                    int diffY = personnage.position.coordonnes.y - zoneOuAller.coordonnes.y;
                    if (diffX < 0)
                    {
                        //droite
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
                    else if (diffX > 0)
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
                        };
                    }
                    else if (diffY < 0)
                    {
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
                    else if (diffY > 0)
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


                }
            }
            return evenements;

        }

        
        public ZoneAbstraite repererZone(PersonnageAbstrait personnage,Type type)
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
                    pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.fin;
                    iOk = true;
                }
                else if (i > 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.droite] != null)
                {
                    pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.fin;
                    iOk = true;
                }
                else if (i == 0)
                {
                    iOk = true;
                }
                if (pos.containsObjet(type))
                    zoneTrouvee = pos;
                if (iOk)
                {
                    for (int j = -1 * champsVision; j <= champsVision && j >= -1 * champsVision && zoneTrouvee == null; j++)
                    {
                        if (j < 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas] != null)
                        {
                            pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.fin;
                        }
                        else if (j > 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut] != null)
                        {
                            pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.fin;
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
