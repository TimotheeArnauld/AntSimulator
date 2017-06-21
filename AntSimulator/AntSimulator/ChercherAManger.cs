using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class ChercherAManger : Comportement
    {
        
        public override void executer(PersonnageAbstrait personnage, ObjetAbstrait objet)
        {
            int diffX = personnage.position.coordonnes.x - objet.position.coordonnes.x;
            int diffY = personnage.position.coordonnes.y - objet.position.coordonnes.y;
            if(diffX < 0)
            {
                //droite
                //personnage.position.coordonnes.x++;
                personnage.position = personnage.position.AccesAbstraitList[2].accesAbstrait.fin;
            }else if(diffX > 0)
            {
                //gauche
                //personnage.position.coordonnes.x--;
                personnage.position = personnage.position.AccesAbstraitList[1].accesAbstrait.fin;
            }
            else if(diffY < 0)
            {
                //haut
                //personnage.position.coordonnes.y++;
                personnage.position = personnage.position.AccesAbstraitList[3].accesAbstrait.fin;
            }
            else if (diffY > 0)
            {
                //bas
                //personnage.position.coordonnes.y--;
                personnage.position = personnage.position.AccesAbstraitList[4].accesAbstrait.fin;
            }

            if (personnage.position.coordonnes.equals(objet.position.coordonnes))
            {
                if(personnage.GetType() == typeof(FourmiOuvriere))
                {
                    FourmiOuvriere f = (FourmiOuvriere)personnage;
                    f.nourriturePortee = (Nourriture)objet;
                    
                }
            }
            
        }
    }
}
