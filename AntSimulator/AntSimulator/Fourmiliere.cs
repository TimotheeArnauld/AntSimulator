using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class Fourmiliere : ObjetAbstrait
    {

        private FabriqueAbstraite fabriqueFourmiliere = null;
        public List<PersonnageAbstrait> PersonnagesList { get; set; }
        public List<Oeuf> listOeuf { get; set; }
        public List<Nourriture> listNourriture { get; set; }

        public Fourmiliere() : base()
        {
            fabriqueFourmiliere = new FabriqueFourmiliere();
        }

        public Fourmiliere(String nom, ZoneAbstraite position) : base(nom,position)
        {
            this.PersonnagesList = new List<PersonnageAbstrait>();
            this.listOeuf = new List<Oeuf>();
            this.listNourriture = new List<Nourriture>(); 
        }



    }
}
