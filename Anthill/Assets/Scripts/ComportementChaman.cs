using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntSimulator.Comportement
{
    public class ComportementChaman : DecorateurComportement
    {
        public ComportementChaman() : base()
        {
            this.ajouterComportement(new DeplacementAleatoire());
        }

        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements = comportement.executer(personnage, env);
            ZoneAbstraite newPosition = personnage.position;
            List<PersonnageAbstrait> listeFourmi = newPosition.ListeFourmiAlentours(env);
            foreach(PersonnageAbstrait f in listeFourmi)
            {
                
                //Console.WriteLine("AUTOUR CHAMAN : " + f.position.coordonnes.x + "," + f.position.coordonnes.y + " , POINT DE VIE:" + f.pointDeVie);
                f.pointDeVie++;
            }
            return evenements;

        }



    }
}
