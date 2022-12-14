using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Prescription2.Areas.Identity.Data;
using E_Prescription2.Models;
using Newtonsoft.Json;
using E_Prescription2.ViewModel;
using E_Prescription2.Areas.Identity.Enums;
using Microsoft.AspNetCore.Authorization;

namespace E_Prescription2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MedicationActiveIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationActiveIngredientsController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // GET: MedicationActiveIngredients
        public async Task<IActionResult> Index(string SearchString)
        {
            
            //.Where(b => b.MedicationRecords.MedicationName.Equals("Concerta"));

            ViewData["CurrentFilter"] = SearchString;
            ViewBag.mssg = TempData["mssg"] as string;
            if (!String.IsNullOrEmpty(SearchString))
            {
                ViewData["CurrentFilter"] = SearchString;
                var applicationDbContexts = _context.MedicationActiveIngredient
                  .Include(m => m.ActiveIngredientRecord1)
                  .Include(m => m.ActiveIngredientRecord2)
                  .Include(m => m.ActiveIngredientRecord3)
                  .Include(m => m.ActiveIngredientRecord4)
                  .Include(m => m.DosageForms)
                  
                  .Include(m => m.Schedules)
                  .Where(b=>b.MedicationName.Contains(SearchString));

                return View(await applicationDbContexts.ToListAsync());

            }
            else
            {
                var applicationDbContext = _context.MedicationActiveIngredient
                .Include(m => m.ActiveIngredientRecord1)
                .Include(m => m.ActiveIngredientRecord2)
                  .Include(m => m.ActiveIngredientRecord3)
                  .Include(m => m.ActiveIngredientRecord4)
                .Include(m => m.DosageForms)
                
                .Include(m => m.Schedules);
                return View(await applicationDbContext.ToListAsync());
            }

           
            
        }

        // GET: MedicationActiveIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicationActiveIngredient == null)
            {
                return NotFound();
            }

            var medicationActiveIngredient = await _context.MedicationActiveIngredient
                .Include(m => m.ActiveIngredientRecord1)
                .Include(m => m.ActiveIngredientRecord2)
                .Include(m=>m.ActiveIngredientRecord3)
                .Include(m=>m.ActiveIngredientRecord4)
                .Include(m => m.DosageForms)
                
                .Include(m => m.Schedules)
                .FirstOrDefaultAsync(m => m.MediActiveId == id);
            if (medicationActiveIngredient == null)
            {
                return NotFound();
            }

            return View(medicationActiveIngredient);
        }
        //[HttpGet]
        //public IActionResult IngredientsStrength()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult IngredientsStrength(IndexViewModel va)
        //{
        //    return View();
        //}

        // GET: MedicationActiveIngredients/Create
        public IActionResult Create()
        {
            //ViewBag.ActiveIngredients = _context.ActiveIngredientRecords.ToList();
            //ViewBag.ActiveIngredient_s = JsonConvert.SerializeObject(_context.ActiveIngredientRecords.ToList());
            //ViewBag.Stregnths=_context.MedicationActiveIngredient.ToList();
            //ViewBag.Stregnth_s=JsonConvert.SerializeObject(_context.MedicationActiveIngredient.ToList());
           
           
            ViewData["ActiveIngredientId1"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName");
            ViewData["ActiveIngredientId2"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName");
            ViewData["ActiveIngredientId3"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName");
            ViewData["ActiveIngredientId4"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName");
            ViewData["DosageFormId"] = new SelectList(_context.DosageForms, "DosageFormId", "DosageFormName");
            
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "ScheduleId", "ScheduleName");
            ViewData["AciveIngredient"] = _context.ActiveIngredientRecords;
            return View();
        }

        // POST: MedicationActiveIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MediActiveId,MedicationName,Strength,Strength2, Strength3, Strength4 ,ActiveIngredientId1,ActiveIngredientId2,ActiveIngredientId3,ActiveIngredientId4,ScheduleId,DosageFormId")] MedicationActiveIngredient medicationActiveIngredient)
        {


            IndexViewModel index = new IndexViewModel();
            if (ModelState.IsValid)
            {
                _context.Add(medicationActiveIngredient);
                await _context.SaveChangesAsync();
                TempData["mssg"] = "Medication Added";
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiveIngredientId1"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId1);
            ViewData["ActiveIngredientId2"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId2);
            ViewData["ActiveIngredientId3"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId3);
            ViewData["ActiveIngredientId4"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId4);
            ViewData["DosageFormId"] = new SelectList(_context.DosageForms, "DosageFormId", "DosageFormName", medicationActiveIngredient.DosageFormId);
            
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "ScheduleId", "ScheduleName", medicationActiveIngredient.ScheduleId);
            return View(medicationActiveIngredient);

        }

        // GET: MedicationActiveIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicationActiveIngredient == null)
            {
                return NotFound();
            }

            var medicationActiveIngredient = await _context.MedicationActiveIngredient.FindAsync(id);
            if (medicationActiveIngredient == null)
            {
                return NotFound();
            }
            ViewData["ActiveIngredientId1"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId1);
            ViewData["ActiveIngredientId2"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId2);
            ViewData["ActiveIngredientId3"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId3);
            ViewData["ActiveIngredientId4"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId4);
            ViewData["DosageFormId"] = new SelectList(_context.DosageForms, "DosageFormId", "DosageFormName", medicationActiveIngredient.DosageFormId);
            
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "ScheduleId", "ScheduleName", medicationActiveIngredient.ScheduleId);
            return View(medicationActiveIngredient);
        }

        // POST: MedicationActiveIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MediActiveId,MedicationName,Strength,Strength2, Strength3, Strength4,ActiveIngredientId1,ActiveIngredientId2,ActiveIngredientId3,ActiveIngredientId4,ScheduleId,DosageFormId")] MedicationActiveIngredient medicationActiveIngredient)
        {
            if (id != medicationActiveIngredient.MediActiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationActiveIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationActiveIngredientExists(medicationActiveIngredient.MediActiveId))
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
            ViewData["ActiveIngredientId1"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId1);
            ViewData["ActiveIngredientId2"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId2);
            ViewData["ActiveIngredientId3"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId3);
            ViewData["ActiveIngredientId4"] = new SelectList(_context.ActiveIngredientRecords, "ActiveIngredientId", "ActiveIngredientName", medicationActiveIngredient.ActiveIngredientId4);
            ViewData["DosageFormId"] = new SelectList(_context.DosageForms, "DosageFormId", "DosageFormName", medicationActiveIngredient.DosageFormId);
            
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "ScheduleId", "ScheduleName", medicationActiveIngredient.ScheduleId);
            return View(medicationActiveIngredient);
        }

        // GET: MedicationActiveIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicationActiveIngredient == null)
            {
                return NotFound();
            }

            var medicationActiveIngredient = await _context.MedicationActiveIngredient
                .Include(m => m.ActiveIngredientRecord1)
                .Include(m => m.ActiveIngredientRecord2)
                .Include(m => m.ActiveIngredientRecord3)
                .Include(m => m.ActiveIngredientRecord4)
                .Include(m => m.DosageForms)
              
                .Include(m => m.Schedules)
                .FirstOrDefaultAsync(m => m.MediActiveId == id);
            if (medicationActiveIngredient == null)
            {
                return NotFound();
            }

            return View(medicationActiveIngredient);
        }

        // POST: MedicationActiveIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicationActiveIngredient == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicationActiveIngredient'  is null.");
            }
            var medicationActiveIngredient = await _context.MedicationActiveIngredient.FindAsync(id);
            if (medicationActiveIngredient != null)
            {
                _context.MedicationActiveIngredient.Remove(medicationActiveIngredient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationActiveIngredientExists(int id)
        {
          return _context.MedicationActiveIngredient.Any(e => e.MediActiveId == id);
        }

    }
}
