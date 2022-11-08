using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Areas.Identity.Enums
{
    public enum HighestQualificationEnum
    {
        [Display(Name ="Bachelors Degree")]
        Bachelors_Degree,
        [Display(Name = "Honours Degree")]
        Honours_Degree,
        [Display(Name = "Masters Degree")]
        Masters_Degree,
        [Display(Name = " Doctorate")]
        Doctorate,

    }
}
