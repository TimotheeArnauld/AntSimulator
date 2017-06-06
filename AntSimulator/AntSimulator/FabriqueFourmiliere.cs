using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class FabriqueFourmiliere : FabriqueAbstraite
    {
      
        public override string Titre
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override AccesAbstrait creerAcces(ZoneAbstraite debut, ZoneAbstraite fin)
        {
            throw new NotImplementedException();
        }

        public override EnvironnementAbstrait creerEnvironnement()
        {
            return new EnvironnementConcret();
        }

        public override ObjetAbstrait creerObjet(string nom, int TypeObjet, ZoneAbstraite position)
        {
            switch (TypeObjet)
            {
                case (int)FourmiliereConstante.typeObjectAbstrait.nourriture:
                    return new Nourriture(nom, position);
                case (int)FourmiliereConstante.typeObjectAbstrait.oeuf:
                    return new Oeuf(nom, position);
                case (int)FourmiliereConstante.typeObjectAbstrait.fourmiliere:
                        return new Fourmiliere(nom,position);
                default:
                    return null;

            }
        }

        public override PersonnageAbstrait creerPersonnage(string nom, int typeFourmi, ZoneAbstraite zoneFourmiliere)
        {
            switch(typeFourmi)
            {
                case (int)FourmiliereConstante.typeFourmie.fourmiOuvriere:
                    return new FourmiOuvriere(nom, zoneFourmiliere);
                case (int)FourmiliereConstante.typeFourmie.fourmiGuerriere:
                    return new FourmiGuerriere(nom, zoneFourmiliere);
                case (int) FourmiliereConstante.typeFourmie.fourmiReine: 
                    return new FourmiReine(nom, zoneFourmiliere);
                default:
                    return null;
            }
        }

        public override ZoneAbstraite creerZone(string nom, Coordonnees coordonnees)
        {
            ZoneAbstraite zone = new BoutDeTerrain(nom,  coordonnees);
            return zone;
        }
    }
}
