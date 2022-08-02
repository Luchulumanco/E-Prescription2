using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Models
{
    public class CustomValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int IdNumbers = (int)value;
                return ValidationResult.Success;
            }
            return new ValidationResult("Please enter Id number ");
        }

    }
}
