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
        
        
        //euh je sais pas ce que la fonction doit faire à la base mais là j'ai fait a peu près une fonction pour repérer la bouffe
        // pour aller chercher la bouffe suffit de faire : if(personnage.position.coordonnee.x-positiondelabouffe.coordonnee.x>0)aller a acces gauche
        public override void executer(PersonnageAbstrait personnage)
        {
            // repérage : 

            ZoneAbstraite zoneNourriture = this.repererNourriture(personnage);

           //déplacement jusqu'a la nourriture : 

             int diffX = personnage.position.coordonnes.x - zoneNourriture.coordonnes.x;
             int diffY = personnage.position.coordonnes.y - zoneNourriture.coordonnes.y;
             if(diffX < 0)
             {
                 //droite
                 personnage.position = personnage.position.AccesAbstraitList[1].accesAbstrait.fin;
             }else if(diffX > 0)
             {
                 //gauche
                 personnage.position = personnage.position.AccesAbstraitList[0].accesAbstrait.fin;
             }
             else if(diffY < 0)
             {
                 //haut
                 personnage.position = personnage.position.AccesAbstraitList[2].accesAbstrait.fin;
             }
             else if (diffY > 0)
             {
                 //bas
                 personnage.position = personnage.position.AccesAbstraitList[3].accesAbstrait.fin;
             }

             //porter la nourriture : 

             if (personnage.position.coordonnes.equals(zoneNourriture.coordonnes))
             {
                 if(personnage.GetType() == typeof(FourmiOuvriere))
                 {
                    FourmiOuvriere f = (FourmiOuvriere)personnage;
                    Nourriture nou = zoneNourriture.getNourriture(); 
                    f.nourriturePortee = nou;

                 }
             }

             //ramener la bouffe a la fourmiliere !!!

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
        
        public void rentrerAvecNourriture(PersonnageAbstrait personnage)
        {
            if(personnage.position.coordonnes.x < FourmiliereConstante.fourmiliere.x)
            {
                //droite
                personnage.position = personnage.position.AccesAbstraitList[1].accesAbstrait.fin;
            }
            if (personnage.position.coordonnes.x > FourmiliereConstante.fourmiliere.x)
            {
                //gauche
                personnage.position = personnage.position.AccesAbstraitList[0].accesAbstrait.fin;
            }
            if (personnage.position.coordonnes.y < FourmiliereConstante.fourmiliere.y)
            {
                //haut
                personnage.position = personnage.position.AccesAbstraitList[2].accesAbstrait.fin;
            }
            if (personnage.position.coordonnes.y > FourmiliereConstante.fourmiliere.y)
            {
                //bas
                personnage.position = personnage.position.AccesAbstraitList[3].accesAbstrait.fin;
            }
        }
    }
}
