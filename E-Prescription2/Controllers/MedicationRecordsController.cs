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
    public class MedicationRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicationRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MedicationRecords.Include(m => m.DosageForms);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MedicationRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicationRecords == null)
            {
                return NotFound();
            }

            var medicationRecord = await _context.MedicationRecords
                .Include(m => m.DosageForms)
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (medicationRecord == null)
            {
                return NotFound();
            }

            return View(medicationRecord);
        }

        // GET: MedicationRecords/Create
        public IActionResult Create()
        {
            
            ViewData["DosageFormId"] = new SelectList(_context.DosageForms, "DosageFormId", "DosageFormId");
            //medication.MedicationActiveIngredients.Add(new MedicationActiveIngredient() { MedicationId=1,ActiveIngredientId=1});
            //medication.MedicationActiveIngredients.Add(new MedicationActiveIngredient() { MedicationId=2,ActiveIngredientId=2});
            //medication.MedicationActiveIngredients.Add(new MedicationActiveIngredient(){ MedicationId=3,ActiveIngredientId=3});
            return View();
        }

        // POST: MedicationRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicationId,MedicationName,Schedule,DosageFormId")] MedicationRecord medicationRecord)
        {
            //foreach(MedicationActiveIngredient medicationActiveIngredient in medicationRecord.MedicationActiveIngredients)
            //{
            //    if(medicationActiveIngredient.Strength ==null || medicationActiveIngredient.Strength.Length ==0)
            //    {
            //        medicationRecord.MedicationActiveIngredients.Remove(medicationActiveIngredient);
            //    }
            //}
            if (ModelState.IsValid)
            {
                _context.Add(medicationRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DosageFormId"] = new SelectList(_context.DosageForms, "DosageFormId", "DosageFormId", medicationRecord.DosageFormId);
            return View(medicationRecord);
        }

        // GET: MedicationRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicationRecords == null)
            {
                return NotFound();
            }

            var medicationRecord = await _context.MedicationRecords.FindAsync(id);
            if (medicationRecord == null)
            {
                return NotFound();
            }
            ViewData["DosageFormId"] = new SelectList(_context.DosageForms, "DosageFormId", "DosageFormId", medicationRecord.DosageFormId);
            return View(medicationRecord);
        }

        // POST: MedicationRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicationId,MedicationName,Schedule,DosageFormId")] MedicationRecord medicationRecord)
        {
            if (id != medicationRecord.MedicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationRecordExists(medicationRecord.MedicationId))
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
            ViewData["DosageFormId"] = new SelectList(_context.DosageForms, "DosageFormId", "DosageFormId", medicationRecord.DosageFormId);
            return View(medicationRecord);
        }

        // GET: MedicationRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicationRecords == null)
            {
                return NotFound();
            }

            var medicationRecord = await _context.MedicationRecords
                .Include(m => m.DosageForms)
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (medicationRecord == null)
            {
                return NotFound();
            }

            return View(medicationRecord);
        }

        // POST: MedicationRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicationRecords == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicationRecords'  is null.");
            }
            var medicationRecord = await _context.MedicationRecords.FindAsync(id);
            if (medicationRecord != null)
            {
                _context.MedicationRecords.Remove(medicationRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationRecordExists(int id)
        {
          return _context.MedicationRecords.Any(e => e.MedicationId == id);
        }
    }
}
