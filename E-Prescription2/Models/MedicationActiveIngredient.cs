using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class MedicationActiveIngredient
    {
        [Key]
        public int MediActiveId { get; set; }

        
      

        public string? Strength { get; set; }

        public string? Strength2 { get; set; }

        public string? Strength3 { get; set; }

        public string? Strength4 { get; set; }

        [ForeignKey("ActiveIngredientRecord")]
        public int? ActiveIngredientId1 { get; set; }
        public virtual ActiveIngredientRecord? ActiveIngredientRecord1 { get; set; }

        [ForeignKey("ActiveIngredientRecord")]
        public int? ActiveIngredientId2 { get; set; }
        public virtual ActiveIngredientRecord? ActiveIngredientRecord2 { get; set; }

        [ForeignKey("ActiveIngredientRecord")]
        public int? ActiveIngredientId3 { get; set; }
        public virtual ActiveIngredientRecord? ActiveIngredientRecord3 { get; set; }

        [ForeignKey("ActiveIngredientRecord")]
        public int? ActiveIngredientId4 { get; set; }
        public virtual ActiveIngredientRecord? ActiveIngredientRecord4 { get; set; }

        [ForeignKey("Schedule")]
        public int? ScheduleId { get; set; }
        public virtual Schedule? Schedules { get; set; }

        [ForeignKey("DosageForm")]
        public int? DosageFormId { get; set; }
        public virtual DosageForm? DosageForms { get; set; }
        
       public string? MedicationName { get; set; }


        
        

    }
}
