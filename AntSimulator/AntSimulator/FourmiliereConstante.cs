namespace AntSimulator
{
    public static class FourmiliereConstante
    {
        public enum typeFourmie{ fourmiOuvriere = 1, fourmiGuerriere = 2, fourmiReine = 3 };
        public enum direction { gauche,droite,haut,bas };
        public enum typeObjectAbstrait { nourriture = 1, oeuf = 2, fourmiliere = 3 };

        public static int pointDeVieOuvriere = 5;
        public static int pointDeVieGuerriere = 10;
        public static int pointDeVieReine = 20;
        public static int NbCase = 10;
    }
}
