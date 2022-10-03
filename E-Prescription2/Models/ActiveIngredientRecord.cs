using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Models
{
    public class ActiveIngredientRecord
    {
        //public ActiveIngredientRecord()
        //{
        //    this.Medications = new HashSet<MedicationRecord>();
        //}
        [Key]
        public int ActiveIngredientId { get; set; }
        public string? ActiveIngredientName { get; set; }

        //public virtual ICollection<MedicationRecord> Medications { get; set; }
        public virtual ICollection<MedicationActiveIngredient> MedicationActiveIngredients { get; set; }
    }
}
