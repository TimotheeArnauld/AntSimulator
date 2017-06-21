﻿using System.Xml.Serialization;

namespace AntSimulator
{
    public  class FourmiliereConstante
    {
        public enum typeFourmie{
            [XmlEnum("EnumOuvriere")]
            fourmiOuvriere=1,
            [XmlEnum("EnumGuerriere")]
            fourmiGuerriere=2,
            [XmlEnum("EnumReine")]
            fourmiReine=3
        };
        public enum direction {
            [XmlEnum("EnumGauche")]
            gauche=1,
            [XmlEnum("EnumDroite")]
            droite=2,
            [XmlEnum("EnumHaut")]
            haut=3,
            [XmlEnum("EnumBas")]
            bas=4 };
        public enum typeObjectAbstrait {
            [XmlEnum("EnumNourriture")]
            nourriture=1,
            [XmlEnum("EnumOeuf")]
            oeuf=2,
            [XmlEnum("EnumFourmiliere")]
            fourmiliere=3,
            [XmlEnum("EnumPheromoneInactive")]
            pheromoneInactive = 4,
            [XmlEnum("EnumPheromoneGauche")]
            pheromoneGauche = 5,
            [XmlEnum("EnumPheromoneHaut")]
            pheromoneHaut = 6,
            [XmlEnum("EnumPheromoneDroite")]
            pheromoneDroite = 7,
            [XmlEnum("EnumPheromoneBas")]
            pheromoneBas = 8
        };

        public static int pointDeVieOuvriere = 5;
        public static int pointDeVieGuerriere = 10;
        public static int pointDeVieReine = 20;
        public static int NbCase = 10;
    }
}
