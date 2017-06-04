using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    class MeteoObservable : IObservable
    {
        private List<IObservateur> listObservateur;
        private bool etatPluie { get; set; }

        public MeteoObservable()
        {
            this.listObservateur = new List<IObservateur>();
            etatPluie = false;
        }

        public void ajouterObservateur(IObservateur observateur)
        {
            this.listObservateur.Add(observateur);
        }

        public void notifierObservateur()
        {
            foreach(IObservateur personnage in this.listObservateur)
            {
                personnage.actualiser(etatPluie);
            }
        }

        public void supprimerObservateur(IObservateur observateur)
        {
            this.listObservateur.Remove(observateur);
        }
    }
}
