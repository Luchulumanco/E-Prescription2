using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class ChronicMedication
    {
        [Key]
        public int ChronicMedi { get; set; }

        [ForeignKey("ApplicatiionUser")]
        public string? UserId { get; set; }
        public ApplicationUser? PatientUser { get; set; }

        [ForeignKey("MedicationActiveIngredient")]
        public int? MedicationId { get; set; }
        public MedicationActiveIngredient? MediActiveIngredient { get; set; }

        public DateTime Date { get; set; }  


    }
}
