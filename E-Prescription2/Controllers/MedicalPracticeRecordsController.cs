using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Prescription2.Areas.Identity.Data;
using E_Prescription2.Models;
using Newtonsoft.Json;
using E_Prescription2.Areas.Identity.Enums;
using Microsoft.AspNetCore.Authorization;

namespace E_Prescription2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MedicalPracticeRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalPracticeRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicalPracticeRecords
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;
            if (!String.IsNullOrEmpty(SearchString))
            {
                var applicationDbContext = _context.MedicalPracticeRecords
                    .Include(m => m.Cities)
                    .Include(m => m.PostalCodes)
                    .Include(m => m.Provinces)
                    .Include(m => m.Suburbs)
                    .Where(m => m.PracticeNumber.Contains(SearchString));
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.MedicalPracticeRecords
                    .Include(m => m.Cities)
                    .Include(m => m.PostalCodes)
                    .Include(m => m.Provinces)
                    .Include(m => m.Suburbs);
                return View(await applicationDbContext.ToListAsync());
            }
                
        }

        // GET: MedicalPracticeRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalPracticeRecords == null)
            {
                return NotFound();
            }

            var medicalPracticeRecord = await _context.MedicalPracticeRecords
                .Include(m => m.Cities)
                .Include(m => m.PostalCodes)
                .Include(m => m.Provinces)
                .Include(m => m.Suburbs)
                .FirstOrDefaultAsync(m => m.PracticeNumberId == id);
            if (medicalPracticeRecord == null)
            {
                return NotFound();
            }

            return View(medicalPracticeRecord);
        }

        // GET: MedicalPracticeRecords/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Provinces = await _context.Provinces.ToListAsync();
            ViewBag.Prov_s = JsonConvert.SerializeObject(_context.Provinces.ToList());
            ViewBag.Cities = await _context.Cities.ToListAsync();
            ViewBag.City_s = JsonConvert.SerializeObject(_context.Cities.ToList());
            ViewBag.Suburbs = await _context.Suburbs.ToListAsync();
            ViewBag.Suburb_s = JsonConvert.SerializeObject(_context.Suburbs.ToList());
            ViewBag.PostalCodes = await _context.PostalCodes.ToListAsync();
            ViewBag.PostalCode_s = JsonConvert.SerializeObject(_context.PostalCodes.ToList());
            return View();
        }

        // POST: MedicalPracticeRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PracticeNumberId,PracticeName,AddressLine1,AddressLine2,ProvinceId,SuburbId,CityId,PostalCodeId,ContactNumber,EmailAddress,PracticeNumber")] MedicalPracticeRecord medicalPracticeRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalPracticeRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", medicalPracticeRecord.CityId);
            ViewData["PostalCodeId"] = new SelectList(_context.PostalCodes, "PostalCodeName", "PostalCodeId", medicalPracticeRecord.PostalCodeId);
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "Province", medicalPracticeRecord.ProvinceId);
            ViewData["SuburbId"] = new SelectList(_context.Suburbs, "SuburbId", "SuburbId", medicalPracticeRecord.SuburbId);
            return View(medicalPracticeRecord);
        }

        // GET: MedicalPracticeRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalPracticeRecords == null)
            {
                return NotFound();
            }

            var medicalPracticeRecord = await _context.MedicalPracticeRecords.FindAsync(id);
            if (medicalPracticeRecord == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", medicalPracticeRecord.CityId);
            ViewData["PostalCodeId"] = new SelectList(_context.PostalCodes, "PostalCodeId", "PostalCodeName", medicalPracticeRecord.PostalCodeId);
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceName", medicalPracticeRecord.ProvinceId);
            ViewData["SuburbId"] = new SelectList(_context.Suburbs, "SuburbId", "SuburbName", medicalPracticeRecord.SuburbId);
            return View(medicalPracticeRecord);
        }

        // POST: MedicalPracticeRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PracticeNumberId,PracticeName,AddressLine1,AddressLine2,ProvinceId,SuburbId,CityId,PostalCodeId,ContactNumber,EmailAddress,PracticeNumber")] MedicalPracticeRecord medicalPracticeRecord)
        {
            if (id != medicalPracticeRecord.PracticeNumberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalPracticeRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalPracticeRecordExists(medicalPracticeRecord.PracticeNumberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", medicalPracticeRecord.CityId);
            ViewData["PostalCodeId"] = new SelectList(_context.PostalCodes, "PostalCodeName", "PostalCodeName", medicalPracticeRecord.PostalCodeId);
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceName", medicalPracticeRecord.ProvinceId);
            ViewData["SuburbId"] = new SelectList(_context.Suburbs, "SuburbId", "SuburbName", medicalPracticeRecord.SuburbId);
            return View(medicalPracticeRecord);
        }

        // GET: MedicalPracticeRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalPracticeRecords == null)
            {
                return NotFound();
            }

            var medicalPracticeRecord = await _context.MedicalPracticeRecords
                .Include(m => m.Cities)
                .Include(m => m.PostalCodes)
                .Include(m => m.Provinces)
                .Include(m => m.Suburbs)
                .FirstOrDefaultAsync(m => m.PracticeNumberId == id);
            if (medicalPracticeRecord == null)
            {
                return NotFound();
            }

            return View(medicalPracticeRecord);
        }

        // POST: MedicalPracticeRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalPracticeRecords == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicalPracticeRecords'  is null.");
            }
            var medicalPracticeRecord = await _context.MedicalPracticeRecords.FindAsync(id);
            if (medicalPracticeRecord != null)
            {
                _context.MedicalPracticeRecords.Remove(medicalPracticeRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalPracticeRecordExists(int id)
        {
            return (_context.MedicalPracticeRecords?.Any(e => e.PracticeNumberId == id)).GetValueOrDefault();
        }
    }
}
