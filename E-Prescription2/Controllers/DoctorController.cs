using Microsoft.AspNetCore.Mvc;

namespace E_Prescription2.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
