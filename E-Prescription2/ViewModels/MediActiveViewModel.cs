using E_Prescription2.Models;

namespace E_Prescription2.ViewModels
{
    public class MediActiveViewModel
    {
        public MedicationRecord MedRecord { get; set; }
        public ActiveIngredientRecord ActiveRecord { get; set; }
        public string Strength { get; set; }

    }
}
