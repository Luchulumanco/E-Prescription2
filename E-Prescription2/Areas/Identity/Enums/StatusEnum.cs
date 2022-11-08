using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Prescription2.Areas.Identity.Enums
{
    public enum StatusEnum
    {
        [Display(Name = "Pending")]
        Pending,

        [Display(Name = "Rejected")]
        Rejected,
       
        [Display(Name = "Approved")]
        Approved,


    }
}
