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
        
        public override void executer(PersonnageAbstrait personnage)
        {
            //champs de vision
            int champsVision = personnage.champDeVision;
            ZoneAbstraite pos = personnage.position;
            Coordonnees coord = pos.coordonnes;
            int x = coord.x;
            int y = coord.y;
            for(int i=0, i<champsVision; i++)
            {
                for(int j=-champsVision; j<champsVision; j++)
                {
                    //pas moyen de recupérer une zone selon ses coordonnées !! :'(
                    //faut recuperer l'env ou passer seulement par les accès..
                }
            }

            //selon les accès
            for(int k=0; k<champsVision; k++)
            {
                Random r = new Random();
                int rnd = r.Next(0, 3);
                ZoneAbstraite z = pos.AccesAbstraitList[rnd].accesAbstrait.fin;
                //pas fini
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
    }
}
