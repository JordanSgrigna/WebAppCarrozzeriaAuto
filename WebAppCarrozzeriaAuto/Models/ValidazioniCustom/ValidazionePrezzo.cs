using System.ComponentModel.DataAnnotations;

namespace WebAppCarrozzeriaAuto.Models.ValidazioniCustom
{
    public class ValidazionePrezzo : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            float fieldValue = (float)value;

            if(fieldValue <= 500f)
            {
                return new ValidationResult("Il campo prezzo deve essere maggiore di 0");
            }

            return ValidationResult.Success;
        }
    }
}
