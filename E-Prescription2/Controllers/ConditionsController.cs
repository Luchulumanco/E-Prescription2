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
    public class ConditionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conditions
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewBag.mssg = TempData["mssg"] as string;
            ViewData["CurrentFilter"] = SearchString;
            var applicationDbContextss = _context.Conditions;
                

            if (!String.IsNullOrEmpty(SearchString))
            {
                if(ModelState.IsValid)
                {
                    ViewData["CurrentFilter"] = SearchString;
                var applicationDbContexts = _context.Conditions
                    .Where(b => b.ICD_10_CODE.Contains(SearchString));
                return View(await applicationDbContexts.ToListAsync());
                }
                else
                {
                    TempData["Message"] = "Please enter a valid ICD 10 CODE";
                    return View(await applicationDbContextss.ToListAsync());
                }
                 
            }
            else
            {
                return View(await _context.Conditions.ToListAsync());
            }
                
        }

        // GET: Conditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conditions == null)
            {
                return NotFound();
            }

            var condition = await _context.Conditions
                .FirstOrDefaultAsync(m => m.ConditionId == id);
            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // GET: Conditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConditionId,ICD_10_CODE,Diagnosis")] Condition condition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condition);
                await _context.SaveChangesAsync();
                TempData["mssg"] = "Condition Added, Thank you ";
                return RedirectToAction(nameof(Index));
            }
            return View(condition);
        }

        // GET: Conditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conditions == null)
            {
                return NotFound();
            }

            var condition = await _context.Conditions.FindAsync(id);
            if (condition == null)
            {
                return NotFound();
            }
            return View(condition);
        }

        // POST: Conditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConditionId,ICD_10_CODE,Diagnosis")] Condition condition)
        {
            if (id != condition.ConditionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConditionExists(condition.ConditionId))
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
            return View(condition);
        }

        // GET: Conditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conditions == null)
            {
                return NotFound();
            }

            var condition = await _context.Conditions
                .FirstOrDefaultAsync(m => m.ConditionId == id);
            if (condition == null)
            {
                return NotFound();
            }

            return View(condition);
        }

        // POST: Conditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conditions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Conditions'  is null.");
            }
            var condition = await _context.Conditions.FindAsync(id);
            if (condition != null)
            {
                _context.Conditions.Remove(condition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConditionExists(int id)
        {
          return _context.Conditions.Any(e => e.ConditionId == id);
        }
    }
}
