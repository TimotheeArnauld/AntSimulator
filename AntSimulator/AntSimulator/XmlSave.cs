using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AntSimulator.Personnage;
using AntSimulator.Objet;
using AntSimulator.Fabrique;
using AntSimulator.Comportement;
using AntSimulator.Objet.Pheromone;

namespace AntSimulator
{
    class XmlSave
    {

        public static void savePersonnage(List<PersonnageAbstrait> personnages, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(personnages.GetType());
            
                xmlSerializer.Serialize(streamWriter, personnages);


        }
        
        public static void saveZone(List<ZoneAbstraite> zone, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(zone.GetType());
            xmlSerializer.Serialize(streamWriter, zone);
            streamWriter.Close();
        }
        public static void saveObject(List<ObjetAbstrait> objet, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objet.GetType());
            xmlSerializer.Serialize(streamWriter, objet);
        }
        public static void saveEnvironnement(List<EnvironnementAbstrait> environnement, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(environnement.GetType());
            xmlSerializer.Serialize(streamWriter, environnement);
        }

        public static void Main()
        {
            /*Console.WriteLine("COUCOU");
            BoutDeTerrain b1 = new BoutDeTerrain("", new Coordonnees());
            Fourmi f = new Fourmi("", b1);
            Console.WriteLine("POSITION fourmi " + f.position.coordonnes.x + " " + f.position.coordonnes.y);
            f.comportement = FourmiliereConstante.deplacementAleatoire;
            
            BoutDeTerrain b2 = new BoutDeTerrain("", new Coordonnees());
            Console.WriteLine("POSITION b2 " + b2.coordonnes.x + " " + b2.coordonnes.y);
            BoutDeTerrain b3 = new BoutDeTerrain("", new Coordonnees());
            Chemin c = new Chemin(b1, b2);
            f.position.AccesAbstraitList[2] = new PaireDirection(2, c);
            f.comportement.executer(f, null);
            Console.WriteLine("NOUVELLE POSITION FOURMI " + f.position.coordonnes.x + " " + f.position.coordonnes.y);*/


            FourmiliereConstante fourmiliereConstante = new FourmiliereConstante();
            List<PersonnageAbstrait> fourmis = new List<PersonnageAbstrait>();
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();

            EnvironnementAbstrait environnementFourmiliere = fabriqueFourmiliere.creerEnvironnement();
            ZoneAbstraite zoneFourmiliere = environnementFourmiliere.ZoneAbstraiteList[6].zoneAbstraiteList[6];
            ZoneAbstraite zone = environnementFourmiliere.ZoneAbstraiteList[5].zoneAbstraiteList[5];

            Fourmiliere fourmiliere = (Fourmiliere)fabriqueFourmiliere.creerObjet("Fourmiliere1",3,zoneFourmiliere);
            
            Fourmi fourmi1 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi1", (int)FourmiliereConstante.typeFourmie.fourmiOuvriere, fourmiliere.position);
            Fourmi fourmi2 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi2", (int)FourmiliereConstante.typeFourmie.fourmiGuerriere, fourmiliere.position);
            Fourmi fourmi3= (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi3", (int)FourmiliereConstante.typeFourmie.fourmiReine, fourmiliere.position);
            fourmis.Add(fourmi1);
            fourmis.Add(fourmi2);
            fourmis.Add(fourmi3);
            List<ObjetAbstrait> objets = new List<ObjetAbstrait>();
            Nourriture nourriture =(Nourriture) fabriqueFourmiliere.creerObjet("pomme", (int)FourmiliereConstante.typeObjectAbstrait.nourriture, zone);
            Oeuf oeuf = (Oeuf)fabriqueFourmiliere.creerObjet("premierOeuf", (int)FourmiliereConstante.typeObjectAbstrait.oeuf,zone);
            objets.Add(nourriture);
            objets.Add(oeuf);
            environnementFourmiliere.PersonnagesList = fourmis;
            zone.ObjetsList = objets;
            zoneFourmiliere.PersonnagesList = fourmis;
            environnementFourmiliere.ObjetsList = objets;
            environnementFourmiliere.ZoneAbstraiteList[6].zoneAbstraiteList[6] = zoneFourmiliere;
            environnementFourmiliere.ZoneAbstraiteList[5].zoneAbstraiteList[5] = zone;
            fourmi1.comportement = new ChercherAManger();
            fourmi2.comportement = new ChercherAManger();
            ZoneAbstraite z = environnementFourmiliere.ZoneAbstraiteList[5].zoneAbstraiteList[6];
            for (int i = 0; i < 42; i++)
            {

                fourmi1.comportement.executer(fourmi1);
                fourmi2.comportement.executer(fourmi2);
                Console.WriteLine(z.ZoneBloquee());
                Console.WriteLine("Fourmi 1 tour :"+i+" "+fourmi1.position.coordonnes.x + " " + fourmi1.position.coordonnes.y+"  "+fourmi1.comportement);
               
                Console.WriteLine("Fourmi 2 tour :"+ i + " " + fourmi2.position.coordonnes.x + " " + fourmi2.position.coordonnes.y + "  " + fourmi2.comportement);

            }

            StreamWriter streamWriter = new StreamWriter("test.xml");
            List<EnvironnementAbstrait> environnementList = new List<EnvironnementAbstrait>();
            environnementList.Add(environnementFourmiliere);
            XmlSave.saveEnvironnement(environnementList, streamWriter);
            streamWriter.Close();

            
            
            //streamWriter2.Close();*/
            /*
            StreamReader streamReader = new StreamReader("test.xml");
             EnvironnementAbstrait env = XmlLoader.loadEnvironnement(streamReader)[0];
            foreach (TableauZoneAbstraite t in env.ZoneAbstraiteList)
            {
                foreach (ZoneAbstraite z in t.zoneAbstraiteList){
                    foreach (Fourmi f in z.PersonnagesList)
                    {
                        Console.Write(f.nom + "  " + f.pointDeVie + "  " + f.GetType() + "  ");
                        if (f.comportement != null)
                            Console.WriteLine(f.comportement.GetType().ToString());
                        else
                            Console.WriteLine();
                    }
                    foreach (ObjetAbstrait o in z.ObjetsList)
                    {
                        Console.WriteLine(o.nom + "  " + o.GetType() + "  ");
                        
                    }
                }
            }*/
        }
    }
}
