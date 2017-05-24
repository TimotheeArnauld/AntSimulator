using System;
using System.Collections.Generic;

namespace AntSimulator
{
    public abstract class ZoneAbstraite
    {
        string nom { get; set; }
        List<ObjetAbstrait> ObjetsList { get; set; }
        List<AccesAbstrait> AccesAbstraitList { get; set; }
        List<PersonnageAbstrait> PersonnagesList { get; set; }

        public ZoneAbstraite(string unNom)
        {
            nom = unNom;
        }
        public void AjouteAcces(AccesAbstrait acces)
        {
            AccesAbstraitList.Add(acces);
        }
        public void AjouteObjet(ObjetAbstrait objet)
        {
            ObjetsList.Add(objet);
        }
        public void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }
        public void RetirePersonnage(PersonnageAbstrait unPersonnage)
        {
            if (!PersonnagesList.Contains(unPersonnage))
            {
                Console.WriteLine("Ce Personnage n'existe pas dans la liste");
            }
            PersonnagesList.Remove(unPersonnage);
        }

    }
}