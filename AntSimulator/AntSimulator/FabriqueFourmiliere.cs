using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class FabriqueFourmiliere : FabriqueAbstraite
    {
        public override string Titre
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override AccesAbstrait creerAcces(ZoneAbstraite debut, ZoneAbstraite fin)
        {
            throw new NotImplementedException();
        }

        public override EnvironnementAbstrait creerEnvironnement()
        {
            throw new NotImplementedException();
        }

        public override ObjetAbstrait creerObjet(string nom)
        {
            throw new NotImplementedException();
        }

        public override PersonnageAbstrait creerPersonnage(string nom)
        {
            throw new NotImplementedException();
        }

        public override ZoneAbstraite creerZone(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
