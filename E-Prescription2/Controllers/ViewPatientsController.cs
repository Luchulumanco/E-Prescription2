using E_Prescription2.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Prescription2.Controllers
{
    public class ViewPatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViewPatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           

            var applicationDbContext = await _context.Users.Where(m=>m.IdNumber!=null).ToListAsync();
            
            
            return View(applicationDbContext);
       }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var ViewPatients = await _context.Users
               .FirstOrDefaultAsync(m => m.Id == id.ToString());

            if (ViewPatients == null)
            {
                return NotFound();
            }

            return View(ViewPatients);
        }
       

    }
}
