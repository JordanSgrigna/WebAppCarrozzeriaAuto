
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCarrozzeriaAuto.Models
{
    public class VenditaAutoUtente
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime OrarioVendita { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(70, ErrorMessage = "Il campo può contenere al massimo 70 caratteri")]
        public string NomeUtente { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(70, ErrorMessage = "Il campo può contenere al massimo 70 caratteri")]
        public string CognomeUtente { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(80, ErrorMessage = "Il campo può contenere al massimo 80 caratteri")]
        public string EmailUtente { get; set; }
        [Required(ErrorMessage ="Il campo è obbligatorio")]
        [Column(TypeName = "tinyint")]
        public int QuantitaAuto { get; set; }
        
        public float PrezzoTotale { get; set; }

        public VenditaAutoUtente()
        {
            
        }

        public VenditaAutoUtente(string nomeUtente, string cognomeUtente, string emailUtente, int quantitaAuto, float prezzoTotale)
        {
            NomeUtente = nomeUtente;
            CognomeUtente = cognomeUtente;
            EmailUtente = emailUtente;
            QuantitaAuto = quantitaAuto;
            PrezzoTotale = prezzoTotale;
        }


        //RELAZIONI
        public int AutoId { get; set; }
        public Auto Auto { get; set; }



    }
}
