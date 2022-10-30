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
    public class ContraIndicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContraIndicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContraIndications
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;

            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewData["CurrentFilter"] = SearchString;
                var applicationDbContext = _context.ContraIndications
                .Include(c => c.ActiveIngredientRecords)
                .Include(c => c.Conditions)
                .Where(c => c.ActiveIngredientRecords.ActiveIngredientName.Contains(SearchString));
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.ContraIndications
               .Include(c => c.ActiveIngredientRecords)
               .Include(c => c.Conditions);
                return View(await applicationDbContext.ToListAsync());
            }
               
        }

        // GET: ContraIndications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContraIndications == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndications
                .Include(c => c.ActiveIngredientRecords)
                .Include(c => c.Conditions)
                .FirstOrDefaultAsync(m => m.ContraId == id);
            if (contraIndication == null)
            {
                return NotFound();
            }

            return View(contraIndication);
        }

        // GET: ContraIndications/Create
        public IActionResult Create()
        {
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName");
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ICD_10_CODE");
            ViewData["ConditionIds"] = new SelectList(_context.Conditions, "ConditionId", "Diagnosis");
            return View();
        }

        // POST: ContraIndications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContraId,ActiveIngredientId,ConditionId")] ContraIndication contraIndication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contraIndication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", contraIndication.ActiveIngredientId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ICD_10_CODE", contraIndication.ConditionId);
            ViewData["ConditionIds"] = new SelectList(_context.Conditions, "ConditionId", "Diagnosis", contraIndication.ConditionId);
            return View(contraIndication);
        }

        // GET: ContraIndications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContraIndications == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndications.FindAsync(id);
            if (contraIndication == null)
            {
                return NotFound();
            }
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", contraIndication.ActiveIngredientId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ICD_10_CODE", contraIndication.ConditionId);
            ViewData["ConditionIds"] = new SelectList(_context.Conditions, "ConditionId", "Diagnosis", contraIndication.ConditionId);
            return View(contraIndication);
        }

        // POST: ContraIndications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContraId,ActiveIngredientId,ConditionId")] ContraIndication contraIndication)
        {
            if (id != contraIndication.ContraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contraIndication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContraIndicationExists(contraIndication.ContraId))
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
            ViewData["ActiveIngredientId"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", contraIndication.ActiveIngredientId);
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ICD_10_CODE", contraIndication.ConditionId);
            ViewData["ConditionIds"] = new SelectList(_context.Conditions, "ConditionId", "Diagnosis", contraIndication.ConditionId);
            return View(contraIndication);
        }

        // GET: ContraIndications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContraIndications == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndications
                .Include(c => c.ActiveIngredientRecords)
                .Include(c => c.Conditions)
                .FirstOrDefaultAsync(m => m.ContraId == id);
            if (contraIndication == null)
            {
                return NotFound();
            }

            return View(contraIndication);
        }

        // POST: ContraIndications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContraIndications == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ContraIndications'  is null.");
            }
            var contraIndication = await _context.ContraIndications.FindAsync(id);
            if (contraIndication != null)
            {
                _context.ContraIndications.Remove(contraIndication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContraIndicationExists(int id)
        {
          return _context.ContraIndications.Any(e => e.ContraId == id);
        }
    }
}
