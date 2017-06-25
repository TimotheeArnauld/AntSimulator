using AntSimulator.Fabrique;
using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class GestionnaireDeTour
    {
        public void init()
        {
            List<PersonnageAbstrait> fourmis = new List<PersonnageAbstrait>();
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();

            EnvironnementAbstrait environnementFourmiliere = fabriqueFourmiliere.creerEnvironnement();
            ZoneAbstraite zoneFourmiliere = environnementFourmiliere.ZoneAbstraiteList[0].zoneAbstraiteList[0];
            ZoneAbstraite zone = environnementFourmiliere.ZoneAbstraiteList[5].zoneAbstraiteList[5];

            Fourmiliere fourmiliere = (Fourmiliere)fabriqueFourmiliere.creerObjet("Fourmiliere1", 3, zoneFourmiliere);

            Fourmi fourmi1 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi1", (int)FourmiliereConstante.typeFourmie.fourmiOuvriere, fourmiliere.position);
            Fourmi fourmi2 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi2", (int)FourmiliereConstante.typeFourmie.fourmiGuerriere, fourmiliere.position);
            Fourmi fourmi3 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi3", (int)FourmiliereConstante.typeFourmie.fourmiReine, fourmiliere.position);
            fourmis.Add(fourmi1);
            fourmis.Add(fourmi2);
            fourmis.Add(fourmi3);
            List<ObjetAbstrait> objets = new List<ObjetAbstrait>();
            Nourriture nourriture = (Nourriture)fabriqueFourmiliere.creerObjet("pomme", (int)FourmiliereConstante.typeObjectAbstrait.nourriture, zone);
            Oeuf oeuf = (Oeuf)fabriqueFourmiliere.creerObjet("premierOeuf", (int)FourmiliereConstante.typeObjectAbstrait.oeuf, zone);
            objets.Add(nourriture);
            objets.Add(oeuf);
            environnementFourmiliere.PersonnagesList = fourmis;
            zone.ObjetsList = objets;
            zoneFourmiliere.PersonnagesList = fourmis;
            environnementFourmiliere.ObjetsList = objets;
            environnementFourmiliere.ZoneAbstraiteList[5].zoneAbstraiteList[5] = zone;
            fourmi1.comportement = new ChercherAManger();
            fourmi2.comportement = new ChercherAManger();
            for (int i = 0; i < 21; i++)
            {
                fourmi1.comportement.executer(fourmi1);
                fourmi2.comportement.executer(fourmi2);
                Console.WriteLine("Fourmi 1 tour :" + i + " " + fourmi1.position.coordonnes.x + " " + fourmi1.position.coordonnes.y + "  " + fourmi1.comportement);

                Console.WriteLine("Fourmi 2 tour :" + i + " " + fourmi2.position.coordonnes.x + " " + fourmi2.position.coordonnes.y + "  " + fourmi2.comportement);

            }

            StreamWriter streamWriter = new StreamWriter("test.xml");
            List<EnvironnementAbstrait> environnementList = new List<EnvironnementAbstrait>();
            environnementList.Add(environnementFourmiliere);
            XmlSave.saveEnvironnement(environnementList, streamWriter);
            streamWriter.Close();

        }
        
    }
}
