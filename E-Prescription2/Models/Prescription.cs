using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? DoctorId { get; set; }
        public ApplicationUser DoctorUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? PatientID { get; set; }
        public ApplicationUser PatientUser { get; set; }

        public DateTime DateTime { get; set; } 


        
    }
}
