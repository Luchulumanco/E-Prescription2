using Microsoft.AspNetCore.Mvc;

namespace E_Prescription2.Controllers
{
    public class PharmacistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
