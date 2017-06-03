using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    public abstract class PersonnageAbstrait
    {
        [XmlElement("positionPersonnage")]
        ZoneAbstraite position;
        [XmlElement("nomPersonnage")]
        String nom { get; set; }
        
        public PersonnageAbstrait()
        {

        }

        public abstract ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList);


    }
}
