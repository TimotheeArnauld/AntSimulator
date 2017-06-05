using System;
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
        public BoutDeTerrain(string unNom) : base(unNom)
        {

        }
        public BoutDeTerrain() : base()
        {

        }
        public List<AccesAbstrait> getChemins()
        {
            return this.AccesAbstraitList;
        }
    }
}
