using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class ContraIndication
    {
        [Key]
        public int ContraId { get; set; }
        [ForeignKey("ActiveIngredient")]
        public int ActiveIngredientId { get; set; }
        public ActiveIngredientRecord? ActiveIngredientRecords { get; set; }
        [ForeignKey("Condition")]
        public int ConditionId { get; set; }
        public Condition? Conditions { get; set; }

    }
}
