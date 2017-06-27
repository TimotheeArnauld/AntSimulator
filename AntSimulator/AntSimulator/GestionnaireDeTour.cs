using AntSimulator.Comportement;
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

        
        public EnvironnementAbstrait environnementFourmiliere;
        public FabriqueAbstraite fabriqueFourmiliere= new FabriqueFourmiliere();
        public List<Evenement> evenements=new List<Evenement>();

        public void ajouterFourmi(int type)
        {
            environnementFourmiliere.AjouterPersonnage((Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi"+FabriqueFourmiliere.id, type, environnementFourmiliere.fourmiliere.position, environnementFourmiliere));
        }
        public void ajouterObjet(int type, int x, int y)
        {
            ZoneAbstraite zoneNourriture = new BoutDeTerrain("zoneNourriture", new Coordonnees(x, y));
            environnementFourmiliere.AjouteObjet(fabriqueFourmiliere.creerObjet("nourriture"+FabriqueFourmiliere.id, type, zoneNourriture, environnementFourmiliere));
        }
        public void init()
        {


            
            environnementFourmiliere = fabriqueFourmiliere.creerEnvironnement();
            ZoneAbstraite zoneFourmiliere = environnementFourmiliere.ZoneAbstraiteList[FourmiliereConstante.fourmiliere.x].zoneAbstraiteList[FourmiliereConstante.fourmiliere.y];
            environnementFourmiliere.fourmiliere = (Fourmiliere)fabriqueFourmiliere.creerObjet("Fourmiliere1", 3, zoneFourmiliere,environnementFourmiliere);

        }
        public void sauvegarde()
        {
            StreamWriter streamWriter = new StreamWriter("sauvegarde.xml");
            List<EnvironnementAbstrait> environnementList = new List<EnvironnementAbstrait>();
            environnementList.Add(environnementFourmiliere);
            XmlSave.saveEnvironnement(environnementList, streamWriter);
            streamWriter.Close();
        }
        public void charger()
        {
            StreamReader streamReader = new StreamReader("sauvegarde.xml");
            List<EnvironnementAbstrait> environnementList = new List<EnvironnementAbstrait>();
            environnementList.Add(environnementFourmiliere);
            environnementFourmiliere=XmlLoader.loadEnvironnement(streamReader)[0];
            streamReader.Close();
        }
        public List<Evenement> executerTour()
        {
            
            foreach(PersonnageAbstrait p in environnementFourmiliere.PersonnagesList)
            {
                if(p.comportement!=null)
                    this.evenements.AddRange(p.comportement.executer(p, environnementFourmiliere));
            }
            foreach (Evenement e in evenements)
                Console.WriteLine(e.o.GetType() + " : " + e.ValeurEvenement);
            return this.evenements;
        }
    public static void Main()
     {
            GestionnaireDeTour g = new GestionnaireDeTour();
            g.init();
            g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiOuvriere);
            g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.fourmiGuerriere));
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture),1,1);
            g.sauvegarde();
            g.charger();
            for (int i = 0; i < 5; i++)
            {
                g.executerTour();
                g.evenements = new List<Evenement>();
            }
     }
    }
    
}
