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
    [Authorize(Roles = "Admin")]
    public class MedicationInteractionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationInteractionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicationInteractions
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewBag.mssg = TempData["mssg"] as string;
            ViewData["CurrentFilter"] = SearchString;

            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewData["CurrentFilter"] = SearchString;
                var applicationDbContexts = _context.MedicationInteractions
                .Include(m => m.ActiveIngredientOne)
                .Include(m => m.ActiveIngredientTwo)
                .Where(b=>b.ActiveIngredientTwo.ActiveIngredientName.Contains(SearchString));
                return View(await applicationDbContexts.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.MedicationInteractions
                .Include(m => m.ActiveIngredientOne)
                .Include(m => m.ActiveIngredientTwo);
                return View(await applicationDbContext.ToListAsync());
            }
                
        }

        // GET: MedicationInteractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicationInteractions == null)
            {
                return NotFound();
            }

            var medicationInteraction = await _context.MedicationInteractions
                .Include(m => m.ActiveIngredientOne)
                .Include(m => m.ActiveIngredientTwo)
                .FirstOrDefaultAsync(m => m.MediInteractionId == id);
            if (medicationInteraction == null)
            {
                return NotFound();
            }

            return View(medicationInteraction);
        }

        // GET: MedicationInteractions/Create
        public IActionResult Create()
        {
            ViewData["ActiveOne"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName");
            ViewData["ActiveTwo"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName");
            return View();
        }

        // POST: MedicationInteractions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediInteractionId,ActiveOne,ActiveTwo")] MedicationInteraction medicationInteraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationInteraction);
                await _context.SaveChangesAsync();
                TempData["mssg"] = "Medication Interactions Added, Thank you ";
                return RedirectToAction(nameof(Index));

            }
            ViewData["ActiveOne"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationInteraction.ActiveOne);
            ViewData["ActiveTwo"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationInteraction.ActiveTwo);
            return View(medicationInteraction);
        }

        // GET: MedicationInteractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicationInteractions == null)
            {
                return NotFound();
            }

            var medicationInteraction = await _context.MedicationInteractions.FindAsync(id);
            if (medicationInteraction == null)
            {
                return NotFound();
            }
            ViewData["ActiveOne"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationInteraction.ActiveOne);
            ViewData["ActiveTwo"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationInteraction.ActiveTwo);
            return View(medicationInteraction);
        }

        // POST: MedicationInteractions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MediInteractionId,ActiveOne,ActiveTwo")] MedicationInteraction medicationInteraction)
        {
            if (id != medicationInteraction.MediInteractionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationInteraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationInteractionExists(medicationInteraction.MediInteractionId))
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
            ViewData["ActiveOne"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationInteraction.ActiveOne);
            ViewData["ActiveTwo"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationInteraction.ActiveTwo);
            return View(medicationInteraction);
        }

        // GET: MedicationInteractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicationInteractions == null)
            {
                return NotFound();
            }

            var medicationInteraction = await _context.MedicationInteractions
                .Include(m => m.ActiveIngredientOne)
                .Include(m => m.ActiveIngredientTwo)
                .FirstOrDefaultAsync(m => m.MediInteractionId == id);
            if (medicationInteraction == null)
            {
                return NotFound();
            }

            return View(medicationInteraction);
        }

        // POST: MedicationInteractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicationInteractions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicationInteractions'  is null.");
            }
            var medicationInteraction = await _context.MedicationInteractions.FindAsync(id);
            if (medicationInteraction != null)
            {
                _context.MedicationInteractions.Remove(medicationInteraction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationInteractionExists(int id)
        {
          return _context.MedicationInteractions.Any(e => e.MediInteractionId == id);
        }
    }
}
