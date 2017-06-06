﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlRoot("BoutDeTerrain")]
    public class BoutDeTerrain : ZoneAbstraite
    {
        public BoutDeTerrain(string unNom, Coordonnees coord) : base(unNom)
        {
            this.coordonnes = coord;
        }
        public BoutDeTerrain(string unNom) : base(unNom)
        {
            coordonnes = new Coordonnees();
        }

        public BoutDeTerrain() : base()
        {

        }
        public Dictionary<Enum,AccesAbstrait> getChemins()
        {
            return this.AccesAbstraitList;
        }
    }
}
