using System.ComponentModel.DataAnnotations;

namespace WebAppCarrozzeriaAuto.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Il campo può contenere al massimo 100 caratteri")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Il campo può contenere al massimo 100 caratteri")]
        public string PaeseOrigine { get; set; }

        public List<Modello> Modelli { get; set; }
        public List<Auto> Auto { get; set; }

        public Marca()
        {

        }

        public Marca(string name, string paeseOrigine)
        {
            Nome = name;
            PaeseOrigine = paeseOrigine;
        }
    }
}
