using E_Prescription2.Models;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Prescription2.ViewModel
{
    public class IndexViewModel
    {
       public List<MedicationActiveIngredient> Ingredients { get; set; }



    }
}
