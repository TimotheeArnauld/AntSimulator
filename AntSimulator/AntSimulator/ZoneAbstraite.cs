using AntSimulator.Objet;
using AntSimulator.Objet.Pheromone;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(BoutDeTerrain))]
    public abstract class ZoneAbstraite
    {
        [XmlElement("coordonneesZone")]
        public Coordonnees coordonnes { get; set; }
        [XmlElement("nomZone")]
        public string nom { get; set; }
        [XmlIgnore]
        public List<ObjetAbstrait> ObjetsList { get; set; }
        [XmlIgnore]
        public PaireDirection[] AccesAbstraitList { get; set; }
        [XmlIgnore]
        public List<PersonnageAbstrait> PersonnagesList { get; set; }

        public ZoneAbstraite(string unNom)
        {
            nom = unNom;
            coordonnes = new Coordonnees();
            PersonnagesList = new List<PersonnageAbstrait>();
            AccesAbstraitList = new PaireDirection[4];
            ObjetsList = new List<ObjetAbstrait>();
        }
        public ZoneAbstraite(string unNom, Coordonnees coordonnees)
        {
            nom = unNom;
            this.coordonnes = coordonnees;
            PersonnagesList = new List<PersonnageAbstrait>();
            AccesAbstraitList = new PaireDirection[4];
            ObjetsList = new List<ObjetAbstrait>();
        }
        public ZoneAbstraite()
        {
            nom = "nom par defaut";
            coordonnes = new Coordonnees();
            PersonnagesList = new List<PersonnageAbstrait>();
            AccesAbstraitList = new PaireDirection[4];
            ObjetsList = new List<ObjetAbstrait>();
        }

        public void AjouteAcces(int direction, AccesAbstrait acces)
        {
            PaireDirection pair = new PaireDirection(direction, acces);
            AccesAbstraitList[direction] = pair;
        }
        public void AjouteObjet(ObjetAbstrait objet)
        {
            ObjetsList.Add(objet);
        }
        public void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }
        public void RetirePersonnage(PersonnageAbstrait unPersonnage)
        {
            if (!PersonnagesList.Contains(unPersonnage))
            {
                Console.WriteLine("Ce Personnage n'existe pas dans la liste");
            }
            PersonnagesList.Remove(unPersonnage);
        }


        public Boolean containsObjet(Type type)
        {
            for (int i = 0; i < this.ObjetsList.Count; i++)
            {
                if (ObjetsList[i].GetType() == type)
                {
                    return true;
                }
            }
            for (int i = 0; i < this.PersonnagesList.Count; i++)
            {
                if (this.PersonnagesList[i].GetType() == type)
                {
                    return true;
                }
            }
            
            return false;
        }

        public Nourriture getNourriture()
        {
            if (this.containsObjet(typeof(Nourriture)))
            {
                for (int i = 0; i < ObjetsList.Count; i++)
                {
                    if (ObjetsList[i].GetType() == typeof(Nourriture))
                    {
                        return (Nourriture)ObjetsList[i];
                    }
                }
            }
            return null;
        }
        public PheromoneActive getPheromone()
        {
           
                foreach(PheromoneActive ph in this.ObjetsList)
                {
                    return ph;
                }
            
            return null;
        }
        public void SupprimerPheromone()
        {

            foreach (PheromoneActive ph in this.ObjetsList)
            {
                this.ObjetsList.Remove(ph);
            }
            
        }
        public bool ZoneBloquee()
        {
            if(this.coordonnes.x== FourmiliereConstante.fourmiliere.x && this.coordonnes.y == FourmiliereConstante.fourmiliere.y)
            {
                return false;
            }
            foreach (ObjetAbstrait o in this.ObjetsList)
            {
                if (o.GetType().GetInterfaces().Contains(typeof(EstObstacle)))
                    return true;
            }
            foreach (PersonnageAbstrait p in this.PersonnagesList)
            {
                if (p.GetType().GetInterfaces().Contains(typeof(EstObstacle)))
                    return true;
            }
            return false;
        }
        public bool TousAccesBloque()
        {
            bool zonesBloquees = true;
            foreach(PaireDirection p in this.AccesAbstraitList)
            {
                if(p!=null)
                if (!p.accesAbstrait.fin.ZoneBloquee())
                    zonesBloquees = false;
            }
            return zonesBloquees;
        }
        
    }
}