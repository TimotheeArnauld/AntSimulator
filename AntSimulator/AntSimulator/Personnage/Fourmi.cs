using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator.Personnage
{
    [XmlRoot("Fourmi")]
    
    public class Fourmi : PersonnageAbstrait, Objet.EstObstacle
    {
        public Fourmi(string nom, ZoneAbstraite c) : base(nom)
        {
            this.position = c;
        }
        public Fourmi(): base()
        {
           
        }

        public override void actualiser(bool etatPluie)
        {
            /*if (etatPluie == true)
                this.comportement = new ComportementPluie();
            else
                this.comportement = this.comportementBase;

            this.executerComportement();*/
        }


        public override void executerComportement()
        {
            this.comportement.executer(this);
        }



    }
}
