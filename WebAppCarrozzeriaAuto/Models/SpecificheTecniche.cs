using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCarrozzeriaAuto.Models
{
    public class SpecificheTecniche
    {
        //ATTRIBUTI
        public int Id { get; set; }

        [Column(TypeName = "smallint")]
        public int? Cilindrata { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il campo può contenere al massimo 50 caratteri")]
        public string Alimentazione { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Column(TypeName = "smallint")]
        [Range(10, 3000, ErrorMessage = "Il campo deve essere compreso tra 10 e 3000")]
        public int Potenza { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il campo può contenere al massimo 50 caratteri")]
        public string Cambio { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il campo può contenere al massimo 50 caratteri")]
        public string Trazione { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il campo può contenere al massimo 100 caratteri")]
        public string ClasseEmissioni { get; set; }

        [Column(TypeName = "DECIMAL(6,2)")]
        public float? ConsumoUrbano { get; set; }

        [Column(TypeName = "DECIMAL(6,2)")]
        public float? ConsumoExtraUrbano { get; set; }

        [Column(TypeName = "DECIMAL(6,2)")]
        public float? ConsumoMisto { get; set; }

        [Column(TypeName = "tinyint")]
        [Range(2, 10)]
        public int NumeroPorte { get; set; }

        [Column(TypeName = "tinyint")]
        public int NumeroPosti { get; set; }


        //RELAZIONI
        [ForeignKey("Auto")]
        public int AutoId { get; set; }
        public Auto Auto { get; set; }

        //COSTRUTTORI
        public SpecificheTecniche()
        {

        }

        public SpecificheTecniche(int? cilindrata, int? numeroCilindri, string alimentazione, int potenza, string cambio, string trazione, string classeEmissioni, float? consumoUrbano, float? consumoExtraUrbano, float? consumoMisto, int autoId, Auto auto)
        {
            Cilindrata = cilindrata;
            Alimentazione = alimentazione;
            Potenza = potenza;
            Cambio = cambio;
            Trazione = trazione;
            ClasseEmissioni = classeEmissioni;
            ConsumoUrbano = consumoUrbano;
            ConsumoExtraUrbano = consumoExtraUrbano;
            ConsumoMisto = consumoMisto;
            AutoId = autoId;
            Auto = auto;
        }
    }
}
