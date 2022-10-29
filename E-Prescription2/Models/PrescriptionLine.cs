using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class PrescriptionLine
    {
        [Key]
        public int PrescriptionLineId { get; set; }

        [ForeignKey("MedicationActiveIngredient")]
        public int? MedicationId { get; set; }
        public MedicationActiveIngredient medicationActive { get; set; }


        [ForeignKey("DispenseDetails")]
        public int? DispenseId { get; set; }
        public DispenseDetails dispenseDetails { get; set; }

    }
}
