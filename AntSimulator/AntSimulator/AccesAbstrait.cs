namespace AntSimulator
{
    public abstract class AccesAbstrait
    {
        ZoneAbstraite debut { get; set; }
        ZoneAbstraite fin { get; set; }

        public AccesAbstrait(ZoneAbstraite debut, ZoneAbstraite fin)
        {
            this.debut = debut;
            this.fin = fin;
        }
    }
}