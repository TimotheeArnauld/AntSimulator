﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet
{
    public class Obstacle : ObjetAbstrait, EstObstacle
    {
        public Obstacle()
        {

        }
        public Obstacle(String nom, ZoneAbstraite position)
        {
            this.nom = nom;
            this.position = position;
        }
    }
}
