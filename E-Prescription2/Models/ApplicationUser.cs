using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        
        public string? IdNumber { get; set; }

        [ForeignKey("Gender")]
        public int? GenderId { get; set; }
        public virtual Gender? Genders { get; set; }

        public string? PhoneNumber { get; set; }
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

        //[Required]
        
        public string? RegistrationNumber { get; set; }

        public string? HighestQualification { get; set; }

        [ForeignKey("MedicalPracticeRecord")]
        public int? PracticeNumber { get; set; }
        public virtual MedicalPracticeRecord? MedicalPracticeRecords { get; set; }

        public string? HealthCouncilRegistrationNumber { get; set; }

        [ForeignKey("PharmacyRecord")]
        public int? PharmacyId { get; set; }
        public virtual PharmacyRecord? PharmacyRecords { get; set; }

        public int UsernameChangeLimit { get; set; } = 10;
        public byte[]? ProfilePicture { get; set; }

    }
}
