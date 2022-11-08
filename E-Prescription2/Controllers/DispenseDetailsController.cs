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
    public class DispenseDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DispenseDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DispenseDetails
        public async Task<IActionResult> Index()
        {
            ViewBag.mssg = TempData["mssg"] as string;
            var applicationDbContext = _context.DispenseDetails.Include(d => d.PharmacistUser).Include(d => d.PharmacyRecords);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DispenseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DispenseDetails == null)
            {
                return NotFound();
            }

            var dispenseDetails = await _context.DispenseDetails
                .Include(d => d.PharmacistUser)
                .Include(d => d.PharmacyRecords)
                .FirstOrDefaultAsync(m => m.DispenseId == id);
            if (dispenseDetails == null)
            {
                return NotFound();
            }

            return View(dispenseDetails);
        }

        // GET: DispenseDetails/Create
        public IActionResult Create()
        {
            ViewData["PharmacistId"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["PharmacyId"] = new SelectList(_context.PharmacyRecords, "PharmacyId", "PharmacyName");
            return View();
        }

        // POST: DispenseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DispenseId,Date,PharmacistId,PharmacyId,RepeatsLeft,Status")] DispenseDetails dispenseDetails)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(dispenseDetails);
                await _context.SaveChangesAsync();
            TempData["mssg"] = "Dispensed Medication, Thank you ";
            return RedirectToAction(nameof(Index));
            //}
            ViewData["PharmacistId"] = new SelectList(_context.Users, "Id", "FullName", dispenseDetails.PharmacistId);
            ViewData["PharmacyId"] = new SelectList(_context.PharmacyRecords, "PharmacyId", "PharmacyName", dispenseDetails.PharmacyId);
            return View(dispenseDetails);
        }

        // GET: DispenseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DispenseDetails == null)
            {
                return NotFound();
            }

            var dispenseDetails = await _context.DispenseDetails.FindAsync(id);
            if (dispenseDetails == null)
            {
                return NotFound();
            }
            ViewData["PharmacistId"] = new SelectList(_context.Users, "Id", "FullName", dispenseDetails.PharmacistId);
            ViewData["PharmacyId"] = new SelectList(_context.PharmacyRecords, "PharmacyId", "PharmacyName", dispenseDetails.PharmacyId);
            return View(dispenseDetails);
        }

        // POST: DispenseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DispenseId,Date,PharmacistId,PharmacyId,RepeatsLeft,Status")] DispenseDetails dispenseDetails)
        {
            if (id != dispenseDetails.DispenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispenseDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DispenseDetailsExists(dispenseDetails.DispenseId))
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
            ViewData["PharmacistId"] = new SelectList(_context.Users, "Id", "FullName", dispenseDetails.PharmacistId);
            ViewData["PharmacyId"] = new SelectList(_context.PharmacyRecords, "PharmacyId", "PharmacyName", dispenseDetails.PharmacyId);
            return View(dispenseDetails);
        }

        // GET: DispenseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DispenseDetails == null)
            {
                return NotFound();
            }

            var dispenseDetails = await _context.DispenseDetails
                .Include(d => d.PharmacistUser)
                .Include(d => d.PharmacyRecords)
                .FirstOrDefaultAsync(m => m.DispenseId == id);
            if (dispenseDetails == null)
            {
                return NotFound();
            }

            return View(dispenseDetails);
        }

        // POST: DispenseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DispenseDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DispenseDetails'  is null.");
            }
            var dispenseDetails = await _context.DispenseDetails.FindAsync(id);
            if (dispenseDetails != null)
            {
                _context.DispenseDetails.Remove(dispenseDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DispenseDetailsExists(int id)
        {
          return _context.DispenseDetails.Any(e => e.DispenseId == id);
        }
    }
}
