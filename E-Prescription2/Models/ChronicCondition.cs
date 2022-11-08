using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class ChronicCondition
    {
        [Key]
        public int ChronicId { get; set; }

        [ForeignKey("Condition")]
        public int? ConditionId { get; set; }
        public Condition? Conditions { get; set; }

        [ForeignKey("ApplicatiionUser")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public DateTime Date { get;set; }
    }
}
