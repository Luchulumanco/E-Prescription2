using E_Prescription2.Areas.Identity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class DispenseDetails
    {
        [Key]
        public int DispenseId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public DateTime Date { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? PharmacistId { get; set; }
        public ApplicationUser PharmacistUser { get; set; }

        [ForeignKey("PharmacyRecord")]
        public int? PharmacyId { get; set; }
        public PharmacyRecord PharmacyRecords { get; set; }

        public int? RepeatsLeft { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status
        {
            get
            {
                return this.Statuses.ToString();
            }
            set
            {
                Statuses = (StatusEnum)Enum.Parse(typeof(StatusEnum), value, true);
            }
        }

        public StatusEnum Statuses { get; set; }
    }
}
