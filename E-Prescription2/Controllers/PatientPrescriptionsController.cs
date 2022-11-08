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
    public class PatientPrescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientPrescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientPrescriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prescriptions.Include(p => p.DoctorUser).Include(p=>p.PrescriptionLines.dispenseDetails)
                .Include(p => p.PatientUser)
                .Include(p => p.PrescriptionLines);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PatientPrescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prescriptions == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.DoctorUser)
                .Include(p => p.PatientUser)
                .Include(p => p.PrescriptionLines)
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // GET: PatientPrescriptions/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["PatientID"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["prescriptionLineId"] = new SelectList(_context.PrescriptionLines, "PrescriptionLineId", "PrescriptionLineId");
            return View();
        }

        // POST: PatientPrescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescriptionID,DoctorId,PatientID,prescriptionLineId,DateTime")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Users, "Id", "FullName", prescription.DoctorId);
            ViewData["PatientID"] = new SelectList(_context.Users, "Id", "FullName", prescription.PatientID);
            ViewData["prescriptionLineId"] = new SelectList(_context.PrescriptionLines, "PrescriptionLineId", "PrescriptionLineId", prescription.prescriptionLineId);
            return View(prescription);
        }

        // GET: PatientPrescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prescriptions == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Users, "Id", "FullName", prescription.DoctorId);
            ViewData["PatientID"] = new SelectList(_context.Users, "Id", "FullName", prescription.PatientID);
            ViewData["prescriptionLineId"] = new SelectList(_context.PrescriptionLines, "PrescriptionLineId", "PrescriptionLineId", prescription.prescriptionLineId);
            return View(prescription);
        }

        // POST: PatientPrescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrescriptionID,DoctorId,PatientID,prescriptionLineId,DateTime")] Prescription prescription)
        {
            if (id != prescription.PrescriptionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.PrescriptionID))
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
            ViewData["DoctorId"] = new SelectList(_context.Users, "Id", "FullName", prescription.DoctorId);
            ViewData["PatientID"] = new SelectList(_context.Users, "Id", "FullName", prescription.PatientID);
            ViewData["prescriptionLineId"] = new SelectList(_context.PrescriptionLines, "PrescriptionLineId", "PrescriptionLineId", prescription.prescriptionLineId);
            return View(prescription);
        }

        // GET: PatientPrescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prescriptions == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.DoctorUser)
                .Include(p => p.PatientUser)
                .Include(p => p.PrescriptionLines)
                .FirstOrDefaultAsync(m => m.PrescriptionID == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: PatientPrescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prescriptions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prescriptions'  is null.");
            }
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
          return _context.Prescriptions.Any(e => e.PrescriptionID == id);
        }
    }
}
