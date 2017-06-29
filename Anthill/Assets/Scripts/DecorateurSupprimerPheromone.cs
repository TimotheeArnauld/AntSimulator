﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntSimulator.Personnage;

namespace AntSimulator.Comportement
{
    public class DecorateurSupprimerPheromone : DecorateurComportement
    {
        public DecorateurSupprimerPheromone() : base()
        {

        }
       
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements=base.executer(personnage,env);
            personnage.position.SupprimerPheromone();
            return evenements;

        }
    }
}
