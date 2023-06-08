using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppCarrozzeriaAuto.Models.ValidazioniCustom;

namespace WebAppCarrozzeriaAuto.Models
{
    public class Auto
    {
        //ATTRIBUTI
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public bool Usata { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Url(ErrorMessage = "Inserisci un URL valido")]
        public string UrlImmagine { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Descrizione { get; set; }

        [StringLength(100, ErrorMessage = "Il campo può contenere al massimo 100 caratteri")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Colore { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [ValidazionePrezzo]
        [Column(TypeName = "DECIMAL(15, 4)")]
        public float Prezzo { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(1990, 3000, ErrorMessage = "Il campo deve esssere compreso tra il 1990 e 3000")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Il campo deve avere quattro cifre")]
        public int AnnoProduzione { get; set; }

        [Range(1990, 3000, ErrorMessage = "Il campo deve esssere compreso tra il 1990 e 3000")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Il campo deve avere quattro cifre")]
        public int? AnnoImmatricolazione { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public int NumeroAutoNelConcessionario { get; set; }
        public int NumeroLikeUtenti { get; set; }


        //RELAZIONI
        public int IdMarca { get; set; }
        public Marca MarcaAuto { get; set; }
        public int idSpecificaTecnica { get; set;}
        public SpecificheTecniche Specifiche { get; set; }
        public List<VenditaAutoUtente> AutoDaVendere { get; set; }
        public int IdAcquisizione { get; set; }
        public AcquisizioneAuto AutoDaAcquisire { get; set; }

        //COSTRUTTORI
        public Auto()
        {

        }

        public Auto(bool usata, string urlImmagine, string descrizione, string colore, float prezzo, int annoProduzione, int annoImmatricolazione, int numeroAutoNelConcessionario, int numeroLikeUtenti)
        {
            Usata = usata;
            UrlImmagine = urlImmagine;
            Descrizione = descrizione;
            Colore = colore;
            Prezzo = prezzo;
            AnnoProduzione = annoProduzione;
            AnnoImmatricolazione = 0;
            NumeroAutoNelConcessionario = 0;
            NumeroLikeUtenti = 0;
        }


    }
}
