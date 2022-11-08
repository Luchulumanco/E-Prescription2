using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Models
{
    public class Patient
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? SuburbId { get; set; }
        public int? PostalCodeId { get; set; }
        public string Contact_Number { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
        public string? Gender { get; set; }

    }
}
