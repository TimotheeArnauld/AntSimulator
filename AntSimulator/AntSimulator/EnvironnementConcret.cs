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
            for(int i=0; i< FourmiliereConstante.NbCase;i++)
            {
                for(int j = 0; j < FourmiliereConstante.NbCase; j++)
                {
                    
                    if (i >= 1)
                       ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList.Add(new PaireDirection((int)FourmiliereConstante.direction.gauche, new Chemin(ZoneAbstraiteList[i].zoneAbstraiteList[j], ZoneAbstraiteList[i - 1].zoneAbstraiteList[j])));
                    if(i<FourmiliereConstante.NbCase-1)
                        ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList.Add(new PaireDirection((int)FourmiliereConstante.direction.droite, new Chemin(ZoneAbstraiteList[i].zoneAbstraiteList[j], ZoneAbstraiteList[i + 1].zoneAbstraiteList[j])));
                     if (j >= 1)
                        ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList.Add(new PaireDirection((int)FourmiliereConstante.direction.haut, new Chemin(ZoneAbstraiteList[i].zoneAbstraiteList[j], ZoneAbstraiteList[i].zoneAbstraiteList[j -1])));
                     if (j < FourmiliereConstante.NbCase - 1)
                        ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList.Add(new PaireDirection((int)FourmiliereConstante.direction.bas, new Chemin(ZoneAbstraiteList[i].zoneAbstraiteList[j], ZoneAbstraiteList[i].zoneAbstraiteList[j +1])));
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
