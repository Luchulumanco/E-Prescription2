using E_Prescription2.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Newtonsoft.Json;

namespace E_Prescription2.Controllers
{
    public class CascadeController : Controller
    {
        private ApplicationDbContext context;
        public CascadeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public JsonResult Province()
        {
            var cnt = context.Provinces.ToList();

            return new JsonResult(cnt);
        }
        public JsonResult City(int id)
        {
            var st = context.Cities.Where(e => e.Provinces.ProvinceId == id).ToList();
            return new JsonResult(st);
        }

        public JsonResult Suburb(int id)
        {
            var ct = context.Suburbs.Where(e => e.Cities.CityId == id).Where(z => z.PostalCodes.PostalCodeId == id).ToList();
            return new JsonResult(ct);
        }

        public JsonResult PostalCode()
        {
            var pt = context.PostalCodes.ToList();
            return new JsonResult(pt);
        }

        public IActionResult CascadeDropdown()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

