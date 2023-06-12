using System.ComponentModel.DataAnnotations;

namespace WebAppCarrozzeriaAuto.Models
{
    public class Marca
    {
        //ATTRIBUTI
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Il campo può contenere al massimo 100 caratteri")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Il campo può contenere al massimo 100 caratteri")]
        public string PaeseOrigine { get; set; }

        //RELAZIONI
        public List<Auto> Auto { get; set; }


        //COSTRUTTORI
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
