﻿using System;
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
    public class PharmacyRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PharmacyRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PharmacyRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PharmacyRecords.Include(p => p.Cities).Include(p => p.PostalCodes).Include(p => p.Provinces).Include(p => p.Suburbs).Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PharmacyRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PharmacyRecords == null)
            {
                return NotFound();
            }

            var pharmacyRecord = await _context.PharmacyRecords
                .Include(p => p.Cities)
                .Include(p => p.PostalCodes)
                .Include(p => p.Provinces)
                .Include(p => p.Suburbs)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PharmacyId == id);
            if (pharmacyRecord == null)
            {
                return NotFound();
            }

            return View(pharmacyRecord);
        }

        // GET: PharmacyRecords/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId");
            ViewData["PostalCodeId"] = new SelectList(_context.PostalCodes, "PostalCodeId", "PostalCodeId");
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceId");
            ViewData["SuburbId"] = new SelectList(_context.Suburbs, "SuburbId", "SuburbId");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: PharmacyRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PharmacyId,PharmacyName,AddressLine1,AddressLine2,ProvinceId,SuburbId,CityId,PostalCodeId,ContactNumber,EmailAddress,LicenseNumber,UserId")] PharmacyRecord pharmacyRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmacyRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", pharmacyRecord.CityId);
            ViewData["PostalCodeId"] = new SelectList(_context.PostalCodes, "PostalCodeId", "PostalCodeId", pharmacyRecord.PostalCodeId);
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceId", pharmacyRecord.ProvinceId);
            ViewData["SuburbId"] = new SelectList(_context.Suburbs, "SuburbId", "SuburbId", pharmacyRecord.SuburbId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", pharmacyRecord.UserId);
            return View(pharmacyRecord);
        }

        // GET: PharmacyRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PharmacyRecords == null)
            {
                return NotFound();
            }

            var pharmacyRecord = await _context.PharmacyRecords.FindAsync(id);
            if (pharmacyRecord == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", pharmacyRecord.CityId);
            ViewData["PostalCodeId"] = new SelectList(_context.PostalCodes, "PostalCodeId", "PostalCodeId", pharmacyRecord.PostalCodeId);
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceId", pharmacyRecord.ProvinceId);
            ViewData["SuburbId"] = new SelectList(_context.Suburbs, "SuburbId", "SuburbId", pharmacyRecord.SuburbId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", pharmacyRecord.UserId);
            return View(pharmacyRecord);
        }

        // POST: PharmacyRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PharmacyId,PharmacyName,AddressLine1,AddressLine2,ProvinceId,SuburbId,CityId,PostalCodeId,ContactNumber,EmailAddress,LicenseNumber,UserId")] PharmacyRecord pharmacyRecord)
        {
            if (id != pharmacyRecord.PharmacyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmacyRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmacyRecordExists(pharmacyRecord.PharmacyId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", pharmacyRecord.CityId);
            ViewData["PostalCodeId"] = new SelectList(_context.PostalCodes, "PostalCodeId", "PostalCodeId", pharmacyRecord.PostalCodeId);
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceId", pharmacyRecord.ProvinceId);
            ViewData["SuburbId"] = new SelectList(_context.Suburbs, "SuburbId", "SuburbId", pharmacyRecord.SuburbId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", pharmacyRecord.UserId);
            return View(pharmacyRecord);
        }

        // GET: PharmacyRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PharmacyRecords == null)
            {
                return NotFound();
            }

            var pharmacyRecord = await _context.PharmacyRecords
                .Include(p => p.Cities)
                .Include(p => p.PostalCodes)
                .Include(p => p.Provinces)
                .Include(p => p.Suburbs)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PharmacyId == id);
            if (pharmacyRecord == null)
            {
                return NotFound();
            }

            return View(pharmacyRecord);
        }

        // POST: PharmacyRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PharmacyRecords == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PharmacyRecords'  is null.");
            }
            var pharmacyRecord = await _context.PharmacyRecords.FindAsync(id);
            if (pharmacyRecord != null)
            {
                _context.PharmacyRecords.Remove(pharmacyRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmacyRecordExists(int id)
        {
          return (_context.PharmacyRecords?.Any(e => e.PharmacyId == id)).GetValueOrDefault();
        }
    }
}