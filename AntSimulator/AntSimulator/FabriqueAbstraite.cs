namespace AntSimulator
{
    public abstract class FabriqueAbstraite
    {
        public abstract string Titre { get; }
        public abstract EnvironnementAbstrait creerEnvironnement();
        public abstract ZoneAbstraite creerZone(string nom);
        public abstract AccesAbstrait creerAcces(ZoneAbstraite debut, ZoneAbstraite fin);
        public abstract PersonnageAbstrait creerPersonnage(string nom);
        public abstract ObjetAbstrait creerObjet(string nom);


    }
}