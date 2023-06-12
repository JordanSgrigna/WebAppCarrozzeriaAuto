namespace WebAppCarrozzeriaAuto.Models.ModelsPerViews
{
    public class ModelloListinoMacchine
    {
        public List<Tipo> Tipo { get; set; }
        public List<Marca> Marca { get; set; }
        public List<SpecificheTecniche> Specifiche { get; set; }
        public List<Auto> Auto { get; set; }
    }
}
