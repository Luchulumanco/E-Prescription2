using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class PostalCode
    {
        public int PostalCodeId { get; set; }

        public string? PostalCodeName { get; set; }

        //[Required]
        //[ForeignKey("Suburb")]
        //public int SuburbId { get; set; }

        //public virtual Suburb? Suburbs { get; set; }
    }
}
