using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    class XmlLoader
    {
        
        public static List<PersonnageAbstrait> loadPersonnage(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PersonnageAbstrait>));
            return (List<PersonnageAbstrait>)xmlSerializer.Deserialize(streamReader);

        }
        public static List<ZoneAbstraite> loadZone(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ZoneAbstraite>));
            return (List<ZoneAbstraite>)xmlSerializer.Deserialize(streamReader);

        }
        public static List<ObjetAbstrait> loadObject(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ObjetAbstrait>));
            return (List<ObjetAbstrait>)xmlSerializer.Deserialize(streamReader);

        }
        public static List<EnvironnementAbstrait> loadEnvironnement(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<EnvironnementAbstrait>));
            return (List<EnvironnementAbstrait>)xmlSerializer.Deserialize(streamReader);

        }
    }
}
