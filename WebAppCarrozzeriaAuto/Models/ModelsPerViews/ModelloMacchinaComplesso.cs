namespace WebAppCarrozzeriaAuto.Models.ModelsPerViews
{
    public class ModelloMacchinaComplesso
    {
        public List<Tipo> Tipo { get; set; }
        public List<Marca> Marca { get; set; }
        public List<Modello> Modello { get; set; }
        public SpecificheTecniche Specifiche { get; set; }
        public Auto Auto { get; set; }
    }
}
