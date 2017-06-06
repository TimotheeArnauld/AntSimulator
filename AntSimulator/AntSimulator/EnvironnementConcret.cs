using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
   public class EnvironnementConcret : EnvironnementAbstrait
    {
        private FabriqueAbstraite fabriqueAbstraite = null;

        public EnvironnementConcret(): base()
        {
            fabriqueAbstraite = new FabriqueFourmiliere();
            for (int i = 0; i < FourmiliereConstante.NbCase; i++)
            {
                for (int j = 0; j < FourmiliereConstante.NbCase; j++)
                {
                    AjouterZoneAbstraite(fabriqueAbstraite.creerZone("", new Coordonnees(i, j)));
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
