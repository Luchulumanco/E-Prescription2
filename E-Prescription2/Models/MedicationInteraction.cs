using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class MedicationInteraction
    {
        [Key]
        public int MediInteractionId { get; set; }

        [ForeignKey("ActiveIngredientRecord")]
        public int? ActiveOne { get; set; }
        public  ActiveIngredientRecord? ActiveIngredientOne { get; set; }

        [ForeignKey("ActiveIngredientRecord")]
        public int? ActiveTwo { get; set; }
        public  ActiveIngredientRecord? ActiveIngredientTwo { get; set; }
    }
}
