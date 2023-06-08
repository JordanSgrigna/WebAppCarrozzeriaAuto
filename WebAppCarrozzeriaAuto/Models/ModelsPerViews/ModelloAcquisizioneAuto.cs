namespace WebAppCarrozzeriaAuto.Models.ModelsPerViews
{
    public class ModelloAcquisizioneAuto
    {
        public List<Auto> Auto { get; set; }
        public List<Modello> Modello { get; set; }
        public List<Marca> Marca { get; set; }
        public List<Tipo> Tipo { get; set; }
        public AcquisizioneAuto AcquisizioneAuto { get; set; }
    }
}
