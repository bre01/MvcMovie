using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class TeasController : Controller
    {
        private readonly MvcMovieContext _context;

        public TeasController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Teas
        public async Task<IActionResult> Index()
        {
              return _context.Tea != null ? 
                          View(await _context.Tea.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Tea'  is null.");
        }

        // GET: Teas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tea == null)
            {
                return NotFound();
            }

            var tea = await _context.Tea
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tea == null)
            {
                return NotFound();
            }

            return View(tea);
        }

        // GET: Teas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age,Kind,Price,PlantTime")] Tea tea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tea);
        }

        // GET: Teas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tea == null)
            {
                return NotFound();
            }

            var tea = await _context.Tea.FindAsync(id);
            if (tea == null)
            {
                return NotFound();
            }
            return View(tea);
        }

        // POST: Teas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age,Kind,Price,PlantTime")] Tea tea)
        {
            if (id != tea.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaExists(tea.ID))
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
            return View(tea);
        }

        // GET: Teas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tea == null)
            {
                return NotFound();
            }

            var tea = await _context.Tea
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tea == null)
            {
                return NotFound();
            }

            return View(tea);
        }

        // POST: Teas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tea == null)
            {
                return Problem("Entity set 'MvcMovieContext.Tea'  is null.");
            }
            var tea = await _context.Tea.FindAsync(id);
            if (tea != null)
            {
                _context.Tea.Remove(tea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeaExists(int id)
        {
          return (_context.Tea?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
