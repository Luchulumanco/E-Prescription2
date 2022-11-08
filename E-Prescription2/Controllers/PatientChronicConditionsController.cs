using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Prescription2.Areas.Identity.Data;
using E_Prescription2.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Prescription2.Controllers
{
    public class PatientChronicConditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientChronicConditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientChronicConditions
        public async Task<IActionResult> Index()
        {
           
            var applicationDbContext = _context.ChricConditions.Include(c => c.Conditions).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PatientChronicConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChricConditions == null)
            {
                return NotFound();
            }

            var chronicCondition = await _context.ChricConditions
                .Include(c => c.Conditions)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ChronicId == id);
            if (chronicCondition == null)
            {
                return NotFound();
            }

            return View(chronicCondition);
        }

        // GET: PatientChronicConditions/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionId");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: PatientChronicConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChronicId,ConditionId,UserId,Date")] ChronicCondition chronicCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chronicCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionId", chronicCondition.ConditionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", chronicCondition.UserId);
            return View(chronicCondition);
        }

        // GET: PatientChronicConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChricConditions == null)
            {
                return NotFound();
            }

            var chronicCondition = await _context.ChricConditions.FindAsync(id);
            if (chronicCondition == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionId", chronicCondition.ConditionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", chronicCondition.UserId);
            return View(chronicCondition);
        }

        // POST: PatientChronicConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChronicId,ConditionId,UserId,Date")] ChronicCondition chronicCondition)
        {
            if (id != chronicCondition.ChronicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chronicCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChronicConditionExists(chronicCondition.ChronicId))
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
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionId", chronicCondition.ConditionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", chronicCondition.UserId);
            return View(chronicCondition);
        }

        // GET: PatientChronicConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChricConditions == null)
            {
                return NotFound();
            }

            var chronicCondition = await _context.ChricConditions
                .Include(c => c.Conditions)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ChronicId == id);
            if (chronicCondition == null)
            {
                return NotFound();
            }

            return View(chronicCondition);
        }

        // POST: PatientChronicConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChricConditions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChricConditions'  is null.");
            }
            var chronicCondition = await _context.ChricConditions.FindAsync(id);
            if (chronicCondition != null)
            {
                _context.ChricConditions.Remove(chronicCondition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChronicConditionExists(int id)
        {
          return _context.ChricConditions.Any(e => e.ChronicId == id);
        }
    }
}
