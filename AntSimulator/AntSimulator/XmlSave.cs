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
            f.comportement = new DeplacementAleatoire();
            
            BoutDeTerrain b2 = new BoutDeTerrain("", new Coordonnees());
            Console.WriteLine("POSITION b2 " + b2.coordonnes.x + " " + b2.coordonnes.y);
            BoutDeTerrain b3 = new BoutDeTerrain("", new Coordonnees());
            Chemin c = new Chemin(b1, b2);
            f.position.AccesAbstraitList[2] = new PaireDirection(2, c);
            f.comportement.executer(f, null);
            Console.WriteLine("NOUVELLE POSITION FOURMI " + f.position.coordonnes.x + " " + f.position.coordonnes.y);*/


            /*
            List<PersonnageAbstrait> fourmis = new List<PersonnageAbstrait>();
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();

            EnvironnementAbstrait environnementFourmiliere = fabriqueFourmiliere.creerEnvironnement();
            ZoneAbstraite zoneFourmiliere = environnementFourmiliere.ZoneAbstraiteList[0].zoneAbstraiteList[0];
            ZoneAbstraite zone = environnementFourmiliere.ZoneAbstraiteList[5].zoneAbstraiteList[5];

            Fourmiliere fourmiliere = (Fourmiliere)fabriqueFourmiliere.creerObjet("Fourmiliere1",3,zoneFourmiliere);
            
            Fourmi fourmi1 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi1", 1, fourmiliere.position);
            Fourmi fourmi2 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi2", 2, fourmiliere.position);
            Fourmi fourmi3= (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi3", 3,fourmiliere.position);
            fourmis.Add(fourmi1);
            fourmis.Add(fourmi2);
            fourmis.Add(fourmi3);
            List<ObjetAbstrait> objets = new List<ObjetAbstrait>();
            Nourriture nourriture =(Nourriture) fabriqueFourmiliere.creerObjet("pomme", (int)FourmiliereConstante.typeObjectAbstrait.nourriture, zone);
            Oeuf oeuf = (Oeuf)fabriqueFourmiliere.creerObjet("premierOeuf", (int)FourmiliereConstante.typeObjectAbstrait.oeuf,zone);
            objets.Add(nourriture);
            objets.Add(oeuf);
            EnvironnementConcret environnement = (EnvironnementConcret)fabriqueFourmiliere.creerEnvironnement();
            environnement.PersonnagesList = fourmis;
            zone.ObjetsList = objets;
            zoneFourmiliere.PersonnagesList = fourmis;
            environnement.ObjetsList = objets;
            environnement.ZoneAbstraiteList[5].zoneAbstraiteList[5] = zone;
            fourmi1.comportement = new ChercherAManger();
            fourmi1.comportement.executer(fourmi1);
            Console.WriteLine(fourmi1.position.coordonnes.x + " " + fourmi1.position.coordonnes.y);
            StreamWriter streamWriter = new StreamWriter("test.xml");
            List<EnvironnementAbstrait> environnementList = new List<EnvironnementAbstrait>();
            environnementList.Add(environnement);
            XmlSave.saveEnvironnement(environnementList, streamWriter);
            streamWriter.Close();

            
            */
            //streamWriter2.Close();*/
            
            StreamReader streamReader = new StreamReader("test.xml");
             EnvironnementAbstrait env = XmlLoader.loadEnvironnement(streamReader)[0];
            foreach(Fourmi f in env.PersonnagesList){
                 Console.Write(f.nom + "  " + f.pointDeVie + "  "+ f.GetType()+"  ");
                 if (f.comportement != null)
                     Console.WriteLine(f.comportement.GetType().ToString());
                 else
                     Console.WriteLine();
             }
            
        }
    }
}
