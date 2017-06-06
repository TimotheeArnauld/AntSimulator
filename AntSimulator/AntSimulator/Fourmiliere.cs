using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class Fourmiliere : EnvironnementAbstrait
    {

        FabriqueAbstraite fabriqueFourmiliere = null;

        public Fourmiliere() : base()
        {
           fabriqueFourmiliere = new FabriqueFourmiliere();
           for(int i=0; i<10; i++)
            {
                for(int j=0; j<10; j++)
                {
                    AjouterZoneAbstraite(new BoutDeTerrain("", new Coordonnees(i, j)));
                }
            } 
        }
        public override void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray)
        {
            throw new NotImplementedException();
        }

        public override void ChargerEnvironnement(FabriqueAbstraite fabrique)
        {
            throw new NotImplementedException();
        }

        public override void ChargerObjets(FabriqueAbstraite fabrique)
        {
            throw new NotImplementedException();
        }

        public override void ChargerPersonnages(FabriqueAbstraite fabrique)
        {
            throw new NotImplementedException();
        }

        public override void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite source, ZoneAbstraite destination)
        {
            throw new NotImplementedException();
        }

        public override string Simuler()
        {
            throw new NotImplementedException();
        }

        public override string Statistiques()
        {
            throw new NotImplementedException();
        }
    }
}
