using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppCarrozzeriaAuto.Models.ValidazioniCustom;

namespace WebAppCarrozzeriaAuto.Models
{
    public class AcquisizioneAuto
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DataAcquisto { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(150, ErrorMessage = "Il campo può contenere al massimo 150 caratteri")]
        public string NomeFornitore { get; set; }
        [Required]
        public bool Usata { get; set; }
        [ValidazionePrezzo]
        [Column(TypeName = "DECIMAL(15, 4)")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public float PrezzoUnitarioMacchina { get; set; }
        [ValidazionePrezzo]
        [Column(TypeName = "DECIMAL(15, 4)")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public float PrezzoTotale { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Column(TypeName = "tinyint")]
        public int NumeroMacchineAcquistate { get; set; }

        //RELAZIONI
        public List<Auto> AutoDaAcquisire { get; set; }


        public AcquisizioneAuto()
        {
            
        }

        public AcquisizioneAuto(string nomeFornitore, float prezzoUnitarioMacchina, float prezzoTotale, int numeroMacchineAcquistate, bool usata = false)
        {
            NomeFornitore = nomeFornitore;
            PrezzoUnitarioMacchina = prezzoUnitarioMacchina;
            PrezzoTotale = prezzoTotale;
            NumeroMacchineAcquistate = numeroMacchineAcquistate;
        }

    }
}
