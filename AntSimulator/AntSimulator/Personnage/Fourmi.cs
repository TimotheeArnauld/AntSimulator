using AntSimulator.Objet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator.Personnage
{
    

    public class Fourmi : PersonnageAbstrait, Objet.EstObstacle
    {
        [XmlElement("nourriturePortee")]
           public Nourriture nourriturePortee { get; set; }
        public Fourmi(string nom,ZoneAbstraite c, int id) : base(nom,id)
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
