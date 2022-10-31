using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class PharmacyRecord
    {
        [Key]
        public int PharmacyId { get; set; }
        public string? PharmacyName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? ContactNumber { get; set; }
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
        public string? EmailAddress { get; set; }
        [Required]
        [MaxLength(8)]
        [MinLength(8, ErrorMessage = "A minimum of 8 characters is needed for a Practice Number")]
        [RegularExpression("^([Y-y0-9])*$", ErrorMessage = "Only License Numbers starting with letter Y and seven succeeding numbers are valid")]
        public string? LicenseNumber { get; set; }
       
        [ForeignKey("ApplicatiionUser")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

    }
}
