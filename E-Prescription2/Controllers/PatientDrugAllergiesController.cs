using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Prescription2.Areas.Identity.Data;
using E_Prescription2.Models;

namespace E_Prescription2.Controllers
{
    public class PatientDrugAllergiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientDrugAllergiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientDrugAllergies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DrugAllergies.Include(d => d.ActiveIngredientRecords).Include(d => d.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PatientDrugAllergies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DrugAllergies == null)
            {
                return NotFound();
            }

            var drugAllergy = await _context.DrugAllergies
                .Include(d => d.ActiveIngredientRecords)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DrugId == id);
            if (drugAllergy == null)
            {
                return NotFound();
            }

            return View(drugAllergy);
        }

        // GET: PatientDrugAllergies/Create
        public IActionResult Create()
        {
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: PatientDrugAllergies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrugId,ActiveIngredientId,UserId")] DrugAllergy drugAllergy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drugAllergy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", drugAllergy.ActiveIngredientId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", drugAllergy.UserId);
            return View(drugAllergy);
        }

        // GET: PatientDrugAllergies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DrugAllergies == null)
            {
                return NotFound();
            }

            var drugAllergy = await _context.DrugAllergies.FindAsync(id);
            if (drugAllergy == null)
            {
                return NotFound();
            }
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", drugAllergy.ActiveIngredientId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", drugAllergy.UserId);
            return View(drugAllergy);
        }

        // POST: PatientDrugAllergies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrugId,ActiveIngredientId,UserId")] DrugAllergy drugAllergy)
        {
            if (id != drugAllergy.DrugId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drugAllergy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugAllergyExists(drugAllergy.DrugId))
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
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", drugAllergy.ActiveIngredientId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", drugAllergy.UserId);
            return View(drugAllergy);
        }

        // GET: PatientDrugAllergies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DrugAllergies == null)
            {
                return NotFound();
            }

            var drugAllergy = await _context.DrugAllergies
                .Include(d => d.ActiveIngredientRecords)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DrugId == id);
            if (drugAllergy == null)
            {
                return NotFound();
            }

            return View(drugAllergy);
        }

        // POST: PatientDrugAllergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DrugAllergies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DrugAllergies'  is null.");
            }
            var drugAllergy = await _context.DrugAllergies.FindAsync(id);
            if (drugAllergy != null)
            {
                _context.DrugAllergies.Remove(drugAllergy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugAllergyExists(int id)
        {
          return _context.DrugAllergies.Any(e => e.DrugId == id);
        }
    }
}
