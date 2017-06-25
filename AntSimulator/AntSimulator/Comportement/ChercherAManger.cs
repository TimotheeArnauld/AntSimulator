using AntSimulator.Objet;
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
        
        // pour aller chercher la bouffe suffit de faire : if(personnage.position.coordonnee.x-positiondelabouffe.coordonnee.x>0)aller a acces gauche
        public override void executer(PersonnageAbstrait personnage)
        {
            // repérage : 

            ZoneAbstraite zoneNourriture = this.repererNourriture(personnage);

            //déplacement jusqu'a la nourriture : 
            if (personnage.position.coordonnes.equals(zoneNourriture.coordonnes))
            {
                if (personnage.GetType() == typeof(FourmiOuvriere))
                {
                    FourmiOuvriere f = (FourmiOuvriere)personnage;
                    Nourriture nou = zoneNourriture.getNourriture();
                    f.nourriturePortee = nou;

                }
                personnage.comportement = new RentrerFourmiliere();
            }
            else
            {
                int diffX = personnage.position.coordonnes.x - zoneNourriture.coordonnes.x;
                int diffY = personnage.position.coordonnes.y - zoneNourriture.coordonnes.y;
                if (diffX < 0)
                {
                    //droite

                    personnage.position = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.fin;
                }
                else if (diffX > 0)
                {
                    //gauche
                    personnage.position = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.fin;
                }
                else if (diffY < 0)
                {
                    //haut
                    personnage.position = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.fin;
                }
                else if (diffY > 0)
                {
                    //bas
                    personnage.position = personnage.position.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.fin;
                }
                

            }
            
            

        }



        public ZoneAbstraite repererNourriture(PersonnageAbstrait personnage)
        {
            //champs de vision
            int champsVision = personnage.champDeVision;
            ZoneAbstraite pos = personnage.position;
            ZoneAbstraite zoneNourriture = null;
            if (pos.containsNourriture())
            {
                zoneNourriture = pos;
            }
            for (int i = -1 * champsVision; i <= champsVision && i >= -1 * champsVision && zoneNourriture == null; i++)
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
                if (pos.containsNourriture())
                    zoneNourriture = pos;
                if (iOk)
                {
                    for (int j = -1 * champsVision; j <= champsVision && j >= -1 * champsVision && zoneNourriture == null; j++)
                    {
                        if (j < 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas] != null)
                        {
                            pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.fin;
                        }
                        else if (j > 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut] != null)
                        {
                            pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.fin;
                        }
                        Console.WriteLine("Chercher manger : " + pos.coordonnes.x + " " + pos.coordonnes.y);
                        if (pos.containsNourriture())
                            zoneNourriture = pos;

                    }
                }
            }
            /*if(zoneNourriture!=null)
                personnage.position = zoneNourriture;*/

            return zoneNourriture;
        }
        
        
    }
}
