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
    public class DosageFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DosageFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DosageForms
        public async Task<IActionResult> Index()
        {
              return View(await _context.DosageForms.ToListAsync());
        }

        // GET: DosageForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DosageForms == null)
            {
                return NotFound();
            }

            var dosageForm = await _context.DosageForms
                .FirstOrDefaultAsync(m => m.DosageFormId == id);
            if (dosageForm == null)
            {
                return NotFound();
            }

            return View(dosageForm);
        }

        // GET: DosageForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DosageForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosageFormId,DosageFormName")] DosageForm dosageForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosageForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dosageForm);
        }

        // GET: DosageForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DosageForms == null)
            {
                return NotFound();
            }

            var dosageForm = await _context.DosageForms.FindAsync(id);
            if (dosageForm == null)
            {
                return NotFound();
            }
            return View(dosageForm);
        }

        // POST: DosageForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DosageFormId,DosageFormName")] DosageForm dosageForm)
        {
            if (id != dosageForm.DosageFormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosageForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosageFormExists(dosageForm.DosageFormId))
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
            return View(dosageForm);
        }

        // GET: DosageForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DosageForms == null)
            {
                return NotFound();
            }

            var dosageForm = await _context.DosageForms
                .FirstOrDefaultAsync(m => m.DosageFormId == id);
            if (dosageForm == null)
            {
                return NotFound();
            }

            return View(dosageForm);
        }

        // POST: DosageForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DosageForms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DosageForms'  is null.");
            }
            var dosageForm = await _context.DosageForms.FindAsync(id);
            if (dosageForm != null)
            {
                _context.DosageForms.Remove(dosageForm);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosageFormExists(int id)
        {
          return _context.DosageForms.Any(e => e.DosageFormId == id);
        }
    }
}
