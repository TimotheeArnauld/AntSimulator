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
        
        public static void loadPersonnage(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PersonnageAbstrait));
            xmlSerializer.Deserialize(streamReader);

        }
        public static void loadZone(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ZoneAbstraite));
            xmlSerializer.Deserialize(streamReader);

        }
        public static void loadObject(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObjetAbstrait));
            xmlSerializer.Deserialize(streamReader);

        }
        public static void loadEnvironnement(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(EnvironnementAbstrait));
            xmlSerializer.Deserialize(streamReader);

        }
    }
}
