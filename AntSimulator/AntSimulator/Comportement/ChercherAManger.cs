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
        
        public bool NourriturePresente(ZoneAbstraite position){
            foreach(ObjetAbstrait o in position.ObjetsList){
                if(o.GetType() == typeof(Nourriture))
                    return true;
            }
            return false;
        }
        //euh je sais pas ce que la fonction doit faire à la base mais là j'ai fait a peu près une fonction pour repérer la bouffe
        // pour aller chercher la bouffe suffit de faire : if(personnage.position.coordonnee.x-positiondelabouffe.coordonnee.x>0)aller a acces gauche
        public override void executer(PersonnageAbstrait personnage)
        {
            //champs de vision
            int champsVision = personnage.champDeVision;
            ZoneAbstraite pos = personnage.position;
            Coordonnees coord = pos.coordonnes;
            int x = coord.x;
            int y = coord.y;
            ZoneAbstraite zoneNourriture=null;
            if(NourriturePresente(pos)){
                zoneNourriture=pos;
            }
           for(int i=-champsVision, i<champsVision && zoneNourriture==null; i++)
            {
                bool iOk=false;
                if(i<0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche]!=null){
                    pos=pos.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.fin;
                    iOk=true;
                }
                else if(i>0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.droite]!=null){
                    pos=pos.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.fin;
                    iOk=true;
                }
                else if(i==0){
                    iOk=true;
                }
                if(NourriturePresente(pos))
                    zoneNourriture=pos;
                if(iOk){
                    for(int j=-champsVision; j<champsVision&&zoneNourriture==null; j++)
                    {
                        if(j<0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas]!=null){
                            pos=pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.fin;
                         }
                         else if(j>0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut]!=null){
                             pos=pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.fin;
                          }
               
                        if(NourriturePresente(pos))
                            zoneNourriture=pos;
                    
                    //pas moyen de recupérer une zone selon ses coordonnées !! :'( tqt je gère !!!
                    //faut recuperer l'env ou passer seulement par les accès..
                    }
                }
            }


            /* int diffX = personnage.position.coordonnes.x - objet.position.coordonnes.x;
             int diffY = personnage.position.coordonnes.y - objet.position.coordonnes.y;
             if(diffX < 0)
             {
                 //droite
                 //personnage.position.coordonnes.x++;
                 personnage.position = personnage.position.AccesAbstraitList[1].accesAbstrait.fin;
             }else if(diffX > 0)
             {
                 //gauche
                 //personnage.position.coordonnes.x--;
                 personnage.position = personnage.position.AccesAbstraitList[0].accesAbstrait.fin;
             }
             else if(diffY < 0)
             {
                 //haut
                 //personnage.position.coordonnes.y++;
                 personnage.position = personnage.position.AccesAbstraitList[2].accesAbstrait.fin;
             }
             else if (diffY > 0)
             {
                 //bas
                 //personnage.position.coordonnes.y--;
                 personnage.position = personnage.position.AccesAbstraitList[3].accesAbstrait.fin;
             }

             if (personnage.position.coordonnes.equals(objet.position.coordonnes))
             {
                 if(personnage.GetType() == typeof(FourmiOuvriere))
                 {
                     FourmiOuvriere f = (FourmiOuvriere)personnage;
                     Nourriture nou = (Nourriture)objet;
                     f.nourriturePortee = nou;

                 }
             }

             //ramener la bouffe a la fourmiliere !!!*/

        }

        public ZoneAbstraite algoRechercheAcces(ZoneAbstraite position, int champsVision)
        {
            if (champsVision <= 0)
            {
                return null;
            }
            else
            {
                ZoneAbstraite p = position;
                Random r = new Random();
                int rnd = r.Next(0, 3);
                if (p.AccesAbstraitList[rnd].accesAbstrait.fin.containsNourriture())
                {
                    return p.AccesAbstraitList[rnd].accesAbstrait.fin;
                }
                else
                {
                    return algoRechercheAcces(p.AccesAbstraitList[rnd].accesAbstrait.fin, champsVision--);
                }
            }
            
        }
    }
}
