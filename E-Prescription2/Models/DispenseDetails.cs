using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class DispenseDetails
    {
        [Key]
        public int DispenseId { get; set; }
 
        public DateTime Date { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? PharmacistId { get; set; }
        public ApplicationUser PharmacistUser { get; set; }

        [ForeignKey("PharmacyRecord")]
        public int? PharmacyId { get; set; }
        public PharmacyRecord PharmacyRecords { get; set; }
    }
}
