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
            throw new NotImplementedException();
        }

        public override ObjetAbstrait creerObjet(string nom, int TypeObjet)
        {
            switch (TypeObjet)
            {
                case (int)FourmiliereConstante.typeObjectAbstrait.nourriture:
                    return new Nourriture(nom);
                case (int)FourmiliereConstante.typeObjectAbstrait.oeuf:
                    return new Oeuf(nom);   
                default:
                    return null;

            }
        }

        public override PersonnageAbstrait creerPersonnage(string nom, int typeFourmi)
        {
            switch(typeFourmi)
            {
                case (int)FourmiliereConstante.typeFourmie.fourmiOuvriere:
                    return new FourmiOuvriere(nom, creerZone(""));
                case (int)FourmiliereConstante.typeFourmie.fourmiGuerriere:
                    return new FourmiGuerriere(nom, creerZone(""));
                case (int) FourmiliereConstante.typeFourmie.fourmiReine: 
                    return new FourmiReine(nom, creerZone(""));
                default:
                    return null;
            }
        }

        public override ZoneAbstraite creerZone(string nom)
        {
            ZoneAbstraite zone = new BoutDeTerrain(nom);
            return zone;
        }
    }
}
