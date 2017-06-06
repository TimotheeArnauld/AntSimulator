using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class Fourmiliere : ObjetAbstrait
    {
        FabriqueAbstraite fabriqueFourmiliere = null;

        public Fourmiliere() : base()
        {
            fabriqueFourmiliere = new FabriqueFourmiliere();
           
        }

        public Fourmiliere(String nom, ZoneAbstraite position) : base(nom,position)
        {

        }
    }
}
