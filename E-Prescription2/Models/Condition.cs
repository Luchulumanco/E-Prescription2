using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Models
{
    public class Condition
    {
        [Key]
        public int ConditionId { get; set; }
        public string? ICD_10_CODE { get; set; }
        public string? Diagnosis { get; set; }

    }
}
