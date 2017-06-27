using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Personnage;
using AntSimulator.Fabrique;

namespace AntSimulator.Comportement
{
    class PondreOeufs : ComportementAbstrait
    {
        public PondreOeufs() : base()
        {

        }

        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();
            List<Evenement> evenements = new List<Evenement>();
            if (env.fourmiliere.valeurNutritiveTotalFourmiliere >= 5)
            {
                fabriqueFourmiliere.creerPersonnage("oeuf" + FabriqueFourmiliere.id, (int)FourmiliereConstante.typeFourmie.oeufFourmi, env.fourmiliere.position, env);
                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.pondreOeuf));
            }
            return evenements;
        }
    }
}
