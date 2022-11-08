using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Prescription2.Areas.Identity.Enums
{
    public enum StatusEnum
    {
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Rejected")]
        Rejected,
        [Display(Name = "Pending")]
        Pending,
        

    }
}
