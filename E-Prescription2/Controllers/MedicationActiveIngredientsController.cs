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
    public class MedicationActiveIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationActiveIngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicationActiveIngredients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MedicationActiveIngredient.Include(m => m.ActiveIngredientRecords).Include(m => m.MedicationRecords);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MedicationActiveIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicationActiveIngredient == null)
            {
                return NotFound();
            }

            var medicationActiveIngredient = await _context.MedicationActiveIngredient
                .Include(m => m.ActiveIngredientRecords)
                .Include(m => m.MedicationRecords)
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (medicationActiveIngredient == null)
            {
                return NotFound();
            }

            return View(medicationActiveIngredient);
        }

        // GET: MedicationActiveIngredients/Create
        public IActionResult Create()
        {
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientId");
            ViewData["MedicationId"] = new SelectList(_context.MedicationRecords, "MedicationId", "MedicationId");
            return View();
        }

        // POST: MedicationActiveIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicationId,ActiveIngredientId,Strength")] MedicationActiveIngredient medicationActiveIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationActiveIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientId", medicationActiveIngredient.ActiveIngredientId);
            ViewData["MedicationId"] = new SelectList(_context.MedicationRecords, "MedicationId", "MedicationId", medicationActiveIngredient.MedicationId);
            return View(medicationActiveIngredient);
        }

        // GET: MedicationActiveIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicationActiveIngredient == null)
            {
                return NotFound();
            }

            var medicationActiveIngredient = await _context.MedicationActiveIngredient.FindAsync(id);
            if (medicationActiveIngredient == null)
            {
                return NotFound();
            }
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientId", medicationActiveIngredient.ActiveIngredientId);
            ViewData["MedicationId"] = new SelectList(_context.MedicationRecords, "MedicationId", "MedicationId", medicationActiveIngredient.MedicationId);
            return View(medicationActiveIngredient);
        }

        // POST: MedicationActiveIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicationId,ActiveIngredientId,Strength")] MedicationActiveIngredient medicationActiveIngredient)
        {
            if (id != medicationActiveIngredient.MedicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationActiveIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationActiveIngredientExists(medicationActiveIngredient.MedicationId))
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
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientId", medicationActiveIngredient.ActiveIngredientId);
            ViewData["MedicationId"] = new SelectList(_context.MedicationRecords, "MedicationId", "MedicationId", medicationActiveIngredient.MedicationId);
            return View(medicationActiveIngredient);
        }

        // GET: MedicationActiveIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicationActiveIngredient == null)
            {
                return NotFound();
            }

            var medicationActiveIngredient = await _context.MedicationActiveIngredient
                .Include(m => m.ActiveIngredientRecords)
                .Include(m => m.MedicationRecords)
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (medicationActiveIngredient == null)
            {
                return NotFound();
            }

            return View(medicationActiveIngredient);
        }

        // POST: MedicationActiveIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicationActiveIngredient == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicationActiveIngredient'  is null.");
            }
            var medicationActiveIngredient = await _context.MedicationActiveIngredient.FindAsync(id);
            if (medicationActiveIngredient != null)
            {
                _context.MedicationActiveIngredient.Remove(medicationActiveIngredient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationActiveIngredientExists(int id)
        {
          return _context.MedicationActiveIngredient.Any(e => e.MedicationId == id);
        }
    }
}
