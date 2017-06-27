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

        public void init()
        {


            ZoneAbstraite zoneNourriture = new BoutDeTerrain("zoneNourriture",new Coordonnees(1,1));
            environnementFourmiliere = fabriqueFourmiliere.creerEnvironnement();
            ZoneAbstraite zoneFourmiliere = environnementFourmiliere.ZoneAbstraiteList[FourmiliereConstante.fourmiliere.x].zoneAbstraiteList[FourmiliereConstante.fourmiliere.y];
      

            Fourmiliere fourmiliere = (Fourmiliere)fabriqueFourmiliere.creerObjet("Fourmiliere1", 3, zoneFourmiliere,environnementFourmiliere);

            Fourmi fourmi1 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi1", (int)FourmiliereConstante.typeFourmie.fourmiOuvriere, fourmiliere.position, environnementFourmiliere);
            Fourmi fourmi2 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi2", (int)FourmiliereConstante.typeFourmie.fourmiGuerriere, fourmiliere.position, environnementFourmiliere);
            Fourmi fourmi3 = (Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi3", (int)FourmiliereConstante.typeFourmie.fourmiReine, fourmiliere.position, environnementFourmiliere);
            List<PersonnageAbstrait> fourmis = new List<PersonnageAbstrait>();
            List<ObjetAbstrait> objets = new List<ObjetAbstrait>();
            fourmis.Add(fourmi1);
           fourmis.Add(fourmi2);
            fourmis.Add(fourmi3);
            
            Nourriture nourriture = (Nourriture)fabriqueFourmiliere.creerObjet("pomme", (int)FourmiliereConstante.typeObjectAbstrait.nourriture, zoneNourriture, environnementFourmiliere);
            objets.Add(nourriture);
            environnementFourmiliere.PersonnagesList = fourmis;
            environnementFourmiliere.ObjetsList = objets;
            environnementFourmiliere.ObjetsList = objets;
            /*for (int i = 0; i < 21; i++)
            {
                fourmi1.comportement.executer(fourmi1,environnementFourmiliere);
                fourmi2.comportement.executer(fourmi2,environnementFourmiliere);
                Console.WriteLine("Fourmi 1 tour :" + i + " " + fourmi1.position.coordonnes.x + " " + fourmi1.position.coordonnes.y + "  " + fourmi1.comportement);

                Console.WriteLine("Fourmi 2 tour :" + i + " " + fourmi2.position.coordonnes.x + " " + fourmi2.position.coordonnes.y + "  " + fourmi2.comportement);

            }*/

            StreamWriter streamWriter = new StreamWriter("test.xml");
            List<EnvironnementAbstrait> environnementList = new List<EnvironnementAbstrait>();
            environnementList.Add(environnementFourmiliere);
            XmlSave.saveEnvironnement(environnementList, streamWriter);
            streamWriter.Close();

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
            for (int i = 0; i < 5; i++)
            {
                g.executerTour();
                g.evenements = new List<Evenement>();
            }
     }
    }
    
}
