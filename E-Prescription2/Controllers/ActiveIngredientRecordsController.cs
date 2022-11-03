using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Prescription2.Areas.Identity.Data;
using E_Prescription2.Models;
using Microsoft.AspNetCore.Authorization;

namespace E_Prescription2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActiveIngredientRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActiveIngredientRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActiveIngredientRecords
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;


            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewData["CurrentFilter"] = SearchString;
                var applicationDbContexts = _context.ActiveIngredientRecords
                    .Where(b => b.ActiveIngredientName.Contains(SearchString));
                return View(await applicationDbContexts.ToListAsync());
            }
            else
            {
               
                return View(await _context.ActiveIngredientRecords.ToListAsync());
            }

                
        }

        // GET: ActiveIngredientRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActiveIngredientRecords == null)
            {
                return NotFound();
            }

            var activeIngredientRecord = await _context.ActiveIngredientRecords
                .FirstOrDefaultAsync(m => m.ActiveIngredientId == id);
            if (activeIngredientRecord == null)
            {
                return NotFound();
            }

            return View(activeIngredientRecord);
        }

        // GET: ActiveIngredientRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActiveIngredientRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActiveIngredientId,ActiveIngredientName")] ActiveIngredientRecord activeIngredientRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activeIngredientRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activeIngredientRecord);
        }

        // GET: ActiveIngredientRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActiveIngredientRecords == null)
            {
                return NotFound();
            }

            var activeIngredientRecord = await _context.ActiveIngredientRecords.FindAsync(id);
            if (activeIngredientRecord == null)
            {
                return NotFound();
            }
            return View(activeIngredientRecord);
        }

        // POST: ActiveIngredientRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActiveIngredientId,ActiveIngredientName")] ActiveIngredientRecord activeIngredientRecord)
        {
            if (id != activeIngredientRecord.ActiveIngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeIngredientRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiveIngredientRecordExists(activeIngredientRecord.ActiveIngredientId))
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
            return View(activeIngredientRecord);
        }

        // GET: ActiveIngredientRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActiveIngredientRecords == null)
            {
                return NotFound();
            }

            var activeIngredientRecord = await _context.ActiveIngredientRecords
                .FirstOrDefaultAsync(m => m.ActiveIngredientId == id);
            if (activeIngredientRecord == null)
            {
                return NotFound();
            }

            return View(activeIngredientRecord);
        }

        // POST: ActiveIngredientRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActiveIngredientRecords == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ActiveIngredientRecords'  is null.");
            }
            var activeIngredientRecord = await _context.ActiveIngredientRecords.FindAsync(id);
            if (activeIngredientRecord != null)
            {
                _context.ActiveIngredientRecords.Remove(activeIngredientRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveIngredientRecordExists(int id)
        {
          return _context.ActiveIngredientRecords.Any(e => e.ActiveIngredientId == id);
        }
    }
}
