namespace WebAppCarrozzeriaAuto.Models.ModelsPerViews
{
    public class ModelloMacchinaPerUser
    {
        public List<Tipo> Tipo { get; set; }
        public List<Marca> Marca { get; set; }
        public List<Modello> Modello { get; set; }
        public List<SpecificheTecniche> SpecificheTecniche { get; set; }
        public List<Auto> Auto { get; set; }
    }
}
