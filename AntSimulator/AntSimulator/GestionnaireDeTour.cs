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

        public void GererPersonnage()
        {
            foreach(PersonnageAbstrait p in environnementFourmiliere.PersonnagesList)
            {
                Console.WriteLine(p.nom + ", Position" + p.position.coordonnes.x + ":" + p.position.coordonnes.y+", Prochain tour : "+p.comportement);
                this.evenements.AddRange(p.comportement.executer(p, environnementFourmiliere));
                p.pointDeVie--;
            }
            
        }
        public void MiseAJourPersonnage()
        {
            List<PersonnageAbstrait> PersonnageASupprimer = new List<PersonnageAbstrait>();
            foreach (PersonnageAbstrait p in environnementFourmiliere.PersonnagesList)
            {
                    if (p.pointDeVie <= 0)
                    {
                        evenements.Add(new Evenement(p, (int)FourmiliereConstante.typeEvenement.destruction));
                        PersonnageASupprimer.Add(p);
                    }
            }
            foreach (PersonnageAbstrait p in PersonnageASupprimer)
            {
                environnementFourmiliere.ZoneAbstraiteList[p.position.coordonnes.x].zoneAbstraiteList[p.position.coordonnes.y].PersonnagesList.Remove(p);
                environnementFourmiliere.PersonnagesList.Remove(p);
            }
        }
        public List<Evenement> executerTour()
        {
            GererPersonnage();
            MiseAJourPersonnage();
            List<ObjetAbstrait> objetsASupprimer = new List<ObjetAbstrait>();
            foreach(ObjetAbstrait o in environnementFourmiliere.ObjetsList)
            {
                if (o.GetType() == typeof(Nourriture))
                {
                    if (((Nourriture)o).valeurNutritive == 0)
                    {
                        evenements.Add(new Evenement(o, (int)FourmiliereConstante.typeEvenement.destruction));
                        objetsASupprimer.Add(o);                      
                    }
                }
            }
            foreach(ObjetAbstrait o in objetsASupprimer)
            {

                        environnementFourmiliere.ZoneAbstraiteList[((Nourriture)o).position.coordonnes.x].zoneAbstraiteList[((Nourriture)o).position.coordonnes.y].ObjetsList.Remove(o);
                        environnementFourmiliere.ObjetsList.Remove(o);
            } 
            
            return this.evenements;
        }
    public static void Main()
     {
            GestionnaireDeTour g = new GestionnaireDeTour();
            g.init();
            g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiOuvriere);
            g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.fourmiGuerriere));
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture),5,5);
            for (int i = 0; i < 27; i++)
            {
                Console.WriteLine("Tour : " + (i + 1));
                g.executerTour();
                g.evenements = new List<Evenement>();
            }
            g.sauvegarde();
     }
    }
    
}
