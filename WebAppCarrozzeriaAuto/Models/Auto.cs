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
        [StringLength(70, ErrorMessage = "Il campo può contenere al massimo 70 caratteri")]
        public string NomeModello { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(1990, 3000, ErrorMessage = "Il campo deve esssere compreso tra il 1990 e 3000")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Il campo deve avere quattro cifre")]
        public int AnnoInizioProduzione { get; set; }

        [Range(1990, 3000, ErrorMessage = "Il campo deve esssere compreso tra 1990 e 3000")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Il campo deve avere quattro cifre")]
        public int? AnnoFineProduzione { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public bool Usata { get; set; }


        public float? Kilometraggio { get; set; }

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

        [Range(1990, 3000, ErrorMessage = "Il campo deve esssere compreso tra il 1990 e 3000")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Il campo deve avere quattro cifre")]
        public int? AnnoImmatricolazione { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public int NumeroAutoNelConcessionario { get; set; }
        public int NumeroLikeUtenti { get; set; }


        //RELAZIONI
        public Marca MarcaAuto { get; set; }

        public SpecificheTecniche? Specifiche { get; set; }

        public Tipo TipoAuto { get; set; }

        //COSTRUTTORI
        public Auto()
        {

        }

        public Auto(bool usata, string urlImmagine, string nomeModello, string descrizione, string colore, float prezzo, int annoInizioProduzione, int annoFineProduzione, int annoImmatricolazione, int numeroAutoNelConcessionario, int numeroLikeUtenti, float? kilometraggio)
        {
            Usata = usata;
            UrlImmagine = urlImmagine;
            NomeModello = nomeModello;
            Descrizione = descrizione;
            Colore = colore;
            Prezzo = prezzo;
            AnnoInizioProduzione = annoInizioProduzione;
            AnnoFineProduzione = annoFineProduzione;
            AnnoImmatricolazione = 0;
            NumeroAutoNelConcessionario = 0;
            NumeroLikeUtenti = 0;

            if (!usata)
            {
                Kilometraggio = 0;
            }
            else
            {
                Kilometraggio = kilometraggio;
            }

        }


    }
}
