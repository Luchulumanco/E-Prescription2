using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public string ScheduleName { get; set; }
    }
}
