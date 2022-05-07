#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class AircraftsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AircraftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aircrafts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aircrafts.ToListAsync());
        }

        // GET: Aircrafts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // GET: Aircrafts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aircrafts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aircraft);
        }

        // GET: Aircrafts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            return View(aircraft);
        }

        // POST: Aircrafts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Aircraft aircraft)
        {
            if (id != aircraft.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftExists(aircraft.Id))
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
            return View(aircraft);
        }

        // GET: Aircrafts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // POST: Aircrafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aircraft = await _context.Aircrafts.FindAsync(id);
            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftExists(int id)
        {
            return _context.Aircrafts.Any(e => e.Id == id);
        }
    }
}
