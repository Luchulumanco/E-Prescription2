using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class DrugAllergy
    {
        [Key]
        public int DrugId { get; set; }
        [ForeignKey("ActiveIngredient")]
        public int? ActiveIngredientId { get; set; }
        public ActiveIngredientRecord? ActiveIngredientRecords { get; set; }
        [ForeignKey("ApplicatiionUser")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

    }
}
