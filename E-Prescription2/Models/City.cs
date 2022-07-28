using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.Models
{
    public class City
    {
        
        public int CityId { get; set; }
        public string? CityName { get; set; }

        //[Required]
        [ForeignKey("Province")]
        public int ProvinceId { get; set; }

        public virtual Province? Provinces { get; set; }

    }
}
