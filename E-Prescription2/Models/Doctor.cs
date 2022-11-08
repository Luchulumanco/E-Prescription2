using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Contact_Number { get; set; }
        public string Email { get; set; }
        public string? HighestQualification { get; set; }
        public int? PracticeNumber { get; set; }
        public string? HealthCouncilRegistrationNumber { get; set; }

    }
}
