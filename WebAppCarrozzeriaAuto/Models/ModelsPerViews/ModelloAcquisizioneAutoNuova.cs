namespace WebAppCarrozzeriaAuto.Models.ModelsPerViews
{
    public class ModelloAcquisizioneAutoNuova
    {
        public List<Marca> Marche { get; set; }
        public List<Tipo> Tipi { get; set; }
        public Auto Auto { get; set; }
        public AcquistoAuto AcquistoAuto { get; set; }
    }
}
