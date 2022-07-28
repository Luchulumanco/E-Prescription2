using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class Suburb
    {
        public int SuburbId { get; set; }
        public string? SuburbName { get; set;}

        //[Required]
        [ForeignKey("City")]
        public int CityId { get; set; }

        public virtual City? Cities { get; set; }

        [ForeignKey("PostalCode")]
        public int PostalCodeId { get; set; }

        public virtual PostalCode? PostalCodes { get; set; }
    }
}
