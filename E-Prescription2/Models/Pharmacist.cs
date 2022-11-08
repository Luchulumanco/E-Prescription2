using System.ComponentModel.DataAnnotations;

namespace E_Prescription2.Models
{
    public class Pharmacist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Contact_Number { get; set; }
        public string EmailAddress { get; set; }
        public string Registration_Number { get; set; }
        public int PharmacyId { get; set; }
    }
}
