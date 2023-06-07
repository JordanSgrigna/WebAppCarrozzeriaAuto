using System.ComponentModel.DataAnnotations;

namespace WebAppCarrozzeriaAuto.Models
{
    public class Tipo
    {
        //ATTRIBUTI
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Il campo può contenere al massimo 100 caratteri")]
        public string Nome { get; set; }

        //RELAZIONI
        List<Modello> Modelli { get; set; }

        //COSTRUTTORI
        public Tipo()
        {

        }

        public Tipo(string nome)
        {
            Nome = nome;
        }
    }
}
