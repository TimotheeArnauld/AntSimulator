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
        public Fourmi(string nom, ZoneAbstraite c) : base(nom)
        {
            this.position = c;
        }
        public Fourmi(): base()
        {
            FabriqueFourmiliere f = new FabriqueFourmiliere();
            position = f.creerZone("zone");
        }

        public override void actualiser(bool etatPluie)
        {
            /*if (etatPluie == true)
                this.comportement = new ComportementPluie();
            else
                this.comportement = this.comportementBase;

            this.executerComportement();*/
        }

        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            throw new NotImplementedException();
        }

        public override void executerComportement()
        {
            this.comportement.executer(this);
        }

        public void deplacementAlteatoire()
        {
            Random r = new Random();   
            while (true)
            {
                int max = this.position.AccesAbstraitList.Count;
                int rnd = r.Next(0, max);
                this.position = this.position.AccesAbstraitList[rnd].fin;
            }
                
        }


    }
}
