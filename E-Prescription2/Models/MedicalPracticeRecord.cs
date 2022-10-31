using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class MedicalPracticeRecord
    {
        [Key]
        public int PracticeNumberId { get; set; }
        public string? PracticeName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        [ForeignKey("Province")]
        public int? ProvinceId { get; set; }
        public virtual Province? Provinces { get; set; }

        [ForeignKey("Suburb")]
        public int? SuburbId { get; set; }
        public virtual Suburb? Suburbs { get; set; }

        //[Required]
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City? Cities { get; set; }

        //[Required]
        [ForeignKey("PostalCode")]
        public int? PostalCodeId { get; set; }
        public virtual PostalCode? PostalCodes { get; set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }

        [Required]
        [MaxLength(8)]
        [MinLength(8, ErrorMessage = "A minimum of 8 characters is needed for a Practice Number")]
        [RegularExpression("^([P-Rp-r0-9])*$", ErrorMessage = "Only Practice Numbers starting with letters P,R and six succeeding numbers are valid")]
        public string PracticeNumber { get; set; }


    }
}
