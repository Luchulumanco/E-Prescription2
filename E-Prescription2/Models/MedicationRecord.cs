
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class MedicationRecord
    {
        //public MedicationRecord()
        //{
        //    this.ActiveIngredients = new HashSet<ActiveIngredientRecord>();
        //}
         
        [Key]
        public int MedicationId { get; set; }
        public string? MedicationName { get; set; }

        [ForeignKey("Schedule")]
        public int? ScheduleId { get; set; }
        public virtual Schedule? Schedules { get; set; }

        [ForeignKey("DosageForm")]
        public int? DosageFormId { get; set; }
        public virtual DosageForm? DosageForms { get; set; }

        //public virtual ICollection<ActiveIngredientRecord> ActiveIngredients { get; set; }
        




    }
}
