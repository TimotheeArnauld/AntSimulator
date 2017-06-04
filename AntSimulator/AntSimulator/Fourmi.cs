using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlRoot("Fourmi")]
    public class Fourmi : PersonnageAbstrait
    {
        public Fourmi(string nom) : base(nom)
        {

        }

        public override void actualiser(bool etatPluie)
        {
            if (etatPluie == true)
                this.comportement = new ComportementPluie();
            else
                this.comportement = this.comportementBase;

            this.executerComportement();
        }

        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            throw new NotImplementedException();
        }

        public override void executerComportement()
        {
            this.comportement.executer();
        }
    }
}
