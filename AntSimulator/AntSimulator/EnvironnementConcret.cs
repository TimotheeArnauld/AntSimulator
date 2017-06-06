using System;
using System.Reflection;

namespace AntSimulator
{
    public class EnvironnementConcret : EnvironnementAbstrait
    {
        private FabriqueAbstraite fabriqueAbstraite = null;

        public EnvironnementConcret(): base()
        {
            InitZones();
            InitChemins();
            
        }
        public void InitZones()
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
        public void InitChemins()
        {
            foreach(ZoneAbstraite zone in ZoneAbstraiteList)
            {
                int x = zone.coordonnes.x;
                int y = zone.coordonnes.y;
                Console.WriteLine(zone.coordonnes.x);
                if (x >= 1)
                    zone.AccesAbstraitList.Add(new PaireDirection(FourmiliereConstante.direction.gauche, new Chemin(zone, ZoneAbstraiteList[x - 1, y])));
                /*if(x<FourmiliereConstante.NbCase-1)
                    zone.AccesAbstraitList.Add(FourmiliereConstante.direction.droite, new Chemin(zone, ZoneAbstraiteList[x + 1, y]));
                if (y >= 1)
                    zone.AccesAbstraitList.Add(FourmiliereConstante.direction.haut, new Chemin(zone, ZoneAbstraiteList[x, y-1]));
                if (y < FourmiliereConstante.NbCase - 1)
                    zone.AccesAbstraitList.Add(FourmiliereConstante.direction.bas, new Chemin(zone, ZoneAbstraiteList[x, y+1]));
*/
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
