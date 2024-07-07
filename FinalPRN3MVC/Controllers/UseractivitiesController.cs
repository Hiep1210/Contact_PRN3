using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalPRN3MVC.Models;

namespace FinalPRN3MVC.Controllers
{
    public class UseractivitiesController : Controller
    {
        private readonly lovetientdContext _context;

        public UseractivitiesController(lovetientdContext context)
        {
            _context = context;
        }

        // GET: Useractivities
        public async Task<IActionResult> Index()
        {
            var lovetientdContext = _context.Useractivities.Include(u => u.User);
            return View(await lovetientdContext.ToListAsync());
        }

        // GET: Useractivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Useractivities == null)
            {
                return NotFound();
            }

            var useractivity = await _context.Useractivities
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (useractivity == null)
            {
                return NotFound();
            }

            return View(useractivity);
        }

        // GET: Useractivities/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Useractivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Date,Action")] Useractivity useractivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(useractivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", useractivity.UserId);
            return View(useractivity);
        }

        // GET: Useractivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Useractivities == null)
            {
                return NotFound();
            }

            var useractivity = await _context.Useractivities.FindAsync(id);
            if (useractivity == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", useractivity.UserId);
            return View(useractivity);
        }

        // POST: Useractivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Date,Action")] Useractivity useractivity)
        {
            if (id != useractivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(useractivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UseractivityExists(useractivity.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", useractivity.UserId);
            return View(useractivity);
        }

        // GET: Useractivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Useractivities == null)
            {
                return NotFound();
            }

            var useractivity = await _context.Useractivities
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (useractivity == null)
            {
                return NotFound();
            }

            return View(useractivity);
        }

        // POST: Useractivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Useractivities == null)
            {
                return Problem("Entity set 'lovetientdContext.Useractivities'  is null.");
            }
            var useractivity = await _context.Useractivities.FindAsync(id);
            if (useractivity != null)
            {
                _context.Useractivities.Remove(useractivity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UseractivityExists(int id)
        {
          return (_context.Useractivities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
