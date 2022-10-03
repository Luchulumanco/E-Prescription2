using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class MedicationActiveIngredient
    {
        [Key]
        //[Column(Order = 1)]
        public int MedicationId { get; set; }
        [Key]
        //[Column(Order =2)]
        public int ActiveIngredientId { get; set; }

        public string? Strength { get; set; }

        public virtual ActiveIngredientRecord ActiveIngredientRecords { get; set; }
        public virtual MedicationRecord MedicationRecords { get; set; }

    }
}
