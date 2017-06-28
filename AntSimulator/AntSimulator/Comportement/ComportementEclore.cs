using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Personnage;
using AntSimulator.Fabrique;

namespace AntSimulator.Comportement
{
    public class ComportementEclore : ComportementAbstrait
    {
        public ComportementEclore() : base()
        {

        }
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();
            List<Evenement> evenements = new List<Evenement>();
            int type = 0;
            if (personnage.GetType() == typeof(Oeuf))
            {
                Oeuf oeuf = (Oeuf)personnage;
                type = oeuf.type;
            }

            fabriqueFourmiliere.creerPersonnage("Fourmis" + FabriqueFourmiliere.id, type, env.fourmiliere.position, env);
            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.eclore));
            return evenements;
        }
    }
}
