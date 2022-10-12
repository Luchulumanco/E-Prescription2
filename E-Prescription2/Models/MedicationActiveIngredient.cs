using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class MedicationActiveIngredient
    {
        [Key]
        public int MediActiveId { get; set; }

        [ForeignKey("MedicationRecord")]
        public int? MedicationId { get; set; }
        public virtual MedicationRecord? MedicationRecords { get; set; }

        public string Strength { get; set; }

        [ForeignKey("ActiveIngredientRecord")]
        public int? ActiveIngredientId { get; set; }
        public virtual ActiveIngredientRecord? ActiveIngredientRecords { get; set; }


        [ForeignKey("Schedule")]
        public int? ScheduleId { get; set; }
        public virtual Schedule? Schedules { get; set; }

        [ForeignKey("DosageForm")]
        public int? DosageFormId { get; set; }
        public virtual DosageForm? DosageForms { get; set; }
        
       


        
        

    }
}
