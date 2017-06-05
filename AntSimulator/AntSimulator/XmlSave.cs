﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


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
            
            List<PersonnageAbstrait> fourmis = new List<PersonnageAbstrait>();
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();
            Fourmi fourmi1 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi1", 1);
            Fourmi fourmi2 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi2", 2);
            Fourmi fourmi3= (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi3", 3);
            fourmis.Add(fourmi1);
            Console.WriteLine(fourmi1.nom);
            fourmis.Add(fourmi2);
            fourmis.Add(fourmi3);
            //StreamWriter streamWriter = new StreamWriter("test.xml");
            //XmlSave.savePersonnage(fourmis, streamWriter);
            StreamReader streamReader = new StreamReader("test.xml");
            fourmis = XmlLoader.loadPersonnage(streamReader);
            foreach(Fourmi f in fourmis){
                Console.Write(f.nom + "  " + f.pointDeVie + "  "+ f.GetType()+"  ");
                if (f.comportement != null)
                    Console.WriteLine(f.comportement.GetType().ToString());
                else
                    Console.WriteLine();
            }
        }
    }
}