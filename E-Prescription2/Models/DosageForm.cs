using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Models
{
    public class DosageForm
    {
        [Key]
        public int DosageFormId { get; set; }
        public string? DosageFormName { get; set; }
    }
}
