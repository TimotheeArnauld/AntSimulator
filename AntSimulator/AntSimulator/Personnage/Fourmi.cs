using AntSimulator.Objet;
using AntSimulator.Comportement;
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
        public Fourmi(string nom,ZoneAbstraite c, int id, EnvironnementAbstrait env) : base(nom,id,env)
        {
            this.position = c;
        }
        public Fourmi(): base()
        {
           
        }

        public override void actualiser(bool etatPluie,EnvironnementAbstrait env)
        {
            if (etatPluie == true)
            {
                this.comportement = new RentrerFourmiliere();
                this.executerComportement(env);
            }
        }


        public override void executerComportement(EnvironnementAbstrait env)
        {
            this.comportement.executer(this,env);
        }



    }
}
