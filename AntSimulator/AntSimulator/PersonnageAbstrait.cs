using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public abstract class PersonnageAbstrait
    {
        ZoneAbstraite position;
        String nom { get; set; }
        
        public PersonnageAbstrait()
        {

        }

        public abstract ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList);


    }
}
