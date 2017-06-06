﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    class DeplacementAleatoire : Comportement
    {
        public override void executer(PersonnageAbstrait personnage)
        {
            Random r = new Random();
            while (true)
            {
                int max = personnage.position.AccesAbstraitList.Count;
                int rnd = r.Next(0, max);
                personnage.position = personnage.position.AccesAbstraitList[rnd].fin;
            }
        }
    }
}
