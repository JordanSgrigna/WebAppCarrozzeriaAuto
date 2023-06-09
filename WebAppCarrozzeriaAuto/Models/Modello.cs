﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCarrozzeriaAuto.Models
{
    public class Modello
    {
        //ATTRIBUTI
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(70, ErrorMessage = "Il campo può contenere al massimo 70 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(1990, 3000, ErrorMessage = "Il campo deve esssere compreso tra il 1990 e 3000")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Il campo deve avere quattro cifre")]
        public int AnnoInizioProduzione { get; set; }

        [Range(1990, 3000, ErrorMessage = "Il campo deve esssere compreso tra 1990 e 3000")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Il campo deve avere quattro cifre")]
        public int? AnnoFineProduzione { get; set; }

        //RELAZIONI
        public List<Auto> Auto { get; set; }

        //COSTRUTTORI
        public Modello()
        {

        }

        public Modello(string nome, int annoInizioProduzione, int? annoFineProduzione)
        {
            Nome = nome;
            AnnoInizioProduzione = annoInizioProduzione;
            AnnoFineProduzione = 0;
        }
    }
}
