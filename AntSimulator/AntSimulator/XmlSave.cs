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
        public static void saveEnvironnement(EnvironnementAbstrait environnement, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(environnement.GetType());
            xmlSerializer.Serialize(streamWriter, environnement);
        }

        public static void Main()
        {
     
            List<PersonnageAbstrait> fourmis = new List<PersonnageAbstrait>();
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();

            EnvironnementAbstrait environnementFourmiliere = fabriqueFourmiliere.creerEnvironnement();
            ZoneAbstraite zone = environnementFourmiliere.ZoneAbstraiteList[0].zoneAbstraiteList[0];

            Fourmiliere fourmiliere = (Fourmiliere)fabriqueFourmiliere.creerObjet("Fourmiliere1",3,zone);
            
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
            Console.WriteLine(oeuf.nom);
            EnvironnementConcret environnement = (EnvironnementConcret)fabriqueFourmiliere.creerEnvironnement();
            environnement.PersonnagesList = fourmis;
            environnement.ObjetsList = objets;

            StreamWriter streamWriter = new StreamWriter("test.xml");
            /*StreamWriter streamWriter2 = new StreamWriter("test2.xml");
            XmlSave.savePersonnage(fourmis, streamWriter);
            XmlSave.saveObject(objets, streamWriter2);*/
            XmlSave.saveEnvironnement(environnement, streamWriter);
            streamWriter.Close();
            //streamWriter2.Close();
           /*treamReader streamReader = new StreamReader("test.xml");
            StreamReader streamReader2 = new StreamReader("test2.xml");
            List<PersonnageAbstrait>fourmisTest = XmlLoader.loadPersonnage(streamReader);
           foreach(Fourmi f in fourmis){
                Console.Write(f.nom + "  " + f.pointDeVie + "  "+ f.GetType()+"  ");
                if (f.comportement != null)
                    Console.WriteLine(f.comportement.GetType().ToString());
                else
                    Console.WriteLine();
            }
            List<ObjetAbstrait> objetsTest = XmlLoader.loadObject(streamReader2);
            foreach (ObjetAbstrait o in objetsTest)
            {
                Console.WriteLine(o.nom + " " +o.GetType() );
                
            }*/
        }
    }
}
