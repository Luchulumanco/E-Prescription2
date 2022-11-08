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

        [ForeignKey("PrescriptionLine")]
        public int? prescriptionLineId { get; set; }
        public PrescriptionLine? PrescriptionLines { get; set; }  


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public DateTime DateTime { get; set; } 


        
    }
}
