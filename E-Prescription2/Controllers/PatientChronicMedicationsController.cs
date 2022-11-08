using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Prescription2.Areas.Identity.Data;
using E_Prescription2.Models;
using E_Prescription2.Areas.Identity.Enums;
using Microsoft.AspNetCore.Authorization;

namespace E_Prescription2.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientChronicMedicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientChronicMedicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientChronicMedications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChronicMedications.Include(c => c.MediActiveIngredient).Include(c => c.PatientUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PatientChronicMedications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChronicMedications == null)
            {
                return NotFound();
            }

            var chronicMedication = await _context.ChronicMedications
                .Include(c => c.MediActiveIngredient)
                .Include(c => c.PatientUser)
                .FirstOrDefaultAsync(m => m.ChronicMedi == id);
            if (chronicMedication == null)
            {
                return NotFound();
            }

            return View(chronicMedication);
        }

        // GET: PatientChronicMedications/Create
        public IActionResult Create()
        {
            ViewData["MedicationId"] = new SelectList(_context.MedicationActiveIngredient, "MediActiveId", "MedicationName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: PatientChronicMedications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChronicMedi,UserId,MedicationId,Date")] ChronicMedication chronicMedication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chronicMedication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicationId"] = new SelectList(_context.MedicationActiveIngredient, "MediActiveId", "MedicationName", chronicMedication.MedicationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", chronicMedication.UserId);
            return View(chronicMedication);
        }

        // GET: PatientChronicMedications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChronicMedications == null)
            {
                return NotFound();
            }

            var chronicMedication = await _context.ChronicMedications.FindAsync(id);
            if (chronicMedication == null)
            {
                return NotFound();
            }
            ViewData["MedicationId"] = new SelectList(_context.MedicationActiveIngredient, "MediActiveId", "MedicationName", chronicMedication.MedicationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", chronicMedication.UserId);
            return View(chronicMedication);
        }

        // POST: PatientChronicMedications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChronicMedi,UserId,MedicationId,Date")] ChronicMedication chronicMedication)
        {
            if (id != chronicMedication.ChronicMedi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chronicMedication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChronicMedicationExists(chronicMedication.ChronicMedi))
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
            ViewData["MedicationId"] = new SelectList(_context.MedicationActiveIngredient, "MediActiveId", "MedicationName", chronicMedication.MedicationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", chronicMedication.UserId);
            return View(chronicMedication);
        }

        // GET: PatientChronicMedications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChronicMedications == null)
            {
                return NotFound();
            }

            var chronicMedication = await _context.ChronicMedications
                .Include(c => c.MediActiveIngredient)
                .Include(c => c.PatientUser)
                .FirstOrDefaultAsync(m => m.ChronicMedi == id);
            if (chronicMedication == null)
            {
                return NotFound();
            }

            return View(chronicMedication);
        }

        // POST: PatientChronicMedications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChronicMedications == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChronicMedications'  is null.");
            }
            var chronicMedication = await _context.ChronicMedications.FindAsync(id);
            if (chronicMedication != null)
            {
                _context.ChronicMedications.Remove(chronicMedication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChronicMedicationExists(int id)
        {
          return _context.ChronicMedications.Any(e => e.ChronicMedi == id);
        }
    }
}
