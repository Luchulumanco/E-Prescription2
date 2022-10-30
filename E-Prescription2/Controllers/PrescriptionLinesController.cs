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
    public class PrescriptionLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrescriptionLines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PrescriptionLines.Include(p => p.dispenseDetails).Include(p => p.medicationActive);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PrescriptionLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrescriptionLines == null)
            {
                return NotFound();
            }

            var prescriptionLine = await _context.PrescriptionLines
                .Include(p => p.dispenseDetails)
                .Include(p => p.medicationActive)
                .FirstOrDefaultAsync(m => m.PrescriptionLineId == id);
            if (prescriptionLine == null)
            {
                return NotFound();
            }

            return View(prescriptionLine);
        }

        // GET: PrescriptionLines/Create
        public IActionResult Create()
        {
            ViewData["DispenseId"] = new SelectList(_context.DispenseDetails, "DispenseId", "DispenseId");
            ViewData["MedicationId"] = new SelectList(_context.MedicationActiveIngredient, "MediActiveId", "MediActiveId");
            return View();
        }

        // POST: PrescriptionLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescriptionLineId,MedicationId,DispenseId")] PrescriptionLine prescriptionLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescriptionLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DispenseId"] = new SelectList(_context.DispenseDetails, "DispenseId", "DispenseId", prescriptionLine.DispenseId);
            ViewData["MedicationId"] = new SelectList(_context.MedicationActiveIngredient, "MediActiveId", "MediActiveId", prescriptionLine.MedicationId);
            return View(prescriptionLine);
        }

        // GET: PrescriptionLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrescriptionLines == null)
            {
                return NotFound();
            }

            var prescriptionLine = await _context.PrescriptionLines.FindAsync(id);
            if (prescriptionLine == null)
            {
                return NotFound();
            }
            ViewData["DispenseId"] = new SelectList(_context.DispenseDetails, "DispenseId", "DispenseId", prescriptionLine.DispenseId);
            ViewData["MedicationId"] = new SelectList(_context.MedicationActiveIngredient, "MediActiveId", "MediActiveId", prescriptionLine.MedicationId);
            return View(prescriptionLine);
        }

        // POST: PrescriptionLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrescriptionLineId,MedicationId,DispenseId")] PrescriptionLine prescriptionLine)
        {
            if (id != prescriptionLine.PrescriptionLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescriptionLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionLineExists(prescriptionLine.PrescriptionLineId))
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
            ViewData["DispenseId"] = new SelectList(_context.DispenseDetails, "DispenseId", "DispenseId", prescriptionLine.DispenseId);
            ViewData["MedicationId"] = new SelectList(_context.MedicationActiveIngredient, "MediActiveId", "MediActiveId", prescriptionLine.MedicationId);
            return View(prescriptionLine);
        }

        // GET: PrescriptionLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrescriptionLines == null)
            {
                return NotFound();
            }

            var prescriptionLine = await _context.PrescriptionLines
                .Include(p => p.dispenseDetails)
                .Include(p => p.medicationActive)
                .FirstOrDefaultAsync(m => m.PrescriptionLineId == id);
            if (prescriptionLine == null)
            {
                return NotFound();
            }

            return View(prescriptionLine);
        }

        // POST: PrescriptionLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrescriptionLines == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PrescriptionLines'  is null.");
            }
            var prescriptionLine = await _context.PrescriptionLines.FindAsync(id);
            if (prescriptionLine != null)
            {
                _context.PrescriptionLines.Remove(prescriptionLine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionLineExists(int id)
        {
          return _context.PrescriptionLines.Any(e => e.PrescriptionLineId == id);
        }
    }
}
