using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSweetShop.Models;
using OnlineSweetShop1.Models;

namespace OnlineSweetShop1.Controllers
{
    public class SweetCategoriesController : Controller
    {
        private readonly SweetContext _context; 

        public SweetCategoriesController(SweetContext context)
        {
            _context = context;
        }

        // GET: SweetCategories
        public async Task<IActionResult> Index()
        {
              return _context.sweetCategories != null ? 
                            View(await _context.sweetCategories.ToListAsync()) :
                          Problem("Entity set 'SweetContext.sweetCategories'  is null.");
        }
        public ActionResult SelectCategory()
        {
            return _context.sweetCategories != null ?
                            View(_context.sweetCategories.ToList()) :
                          Problem("Entity set 'SweetContext.sweetCategories'  is null.");

        }

        // GET: SweetCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sweetCategories == null)
            {
                return NotFound();
            }

            var sweetCategory = await _context.sweetCategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (sweetCategory == null)
            {
                return NotFound();
            }

            return View(sweetCategory);
        }

        // GET: SweetCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SweetCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,photopath")] SweetCategory sweetCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweetCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sweetCategory);
        }

        // GET: SweetCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sweetCategories == null)
            {
                return NotFound();
            }

            var sweetCategory = await _context.sweetCategories.FindAsync(id);
            if (sweetCategory == null)
            {
                return NotFound();
            }
            return View(sweetCategory);
        }

        // POST: SweetCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,photopath")] SweetCategory sweetCategory)
        {
            if (id != sweetCategory.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweetCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetCategoryExists(sweetCategory.id))
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
            return View(sweetCategory);
        }

        // GET: SweetCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sweetCategories == null)
            {
                return NotFound();
            }

            var sweetCategory = await _context.sweetCategories
                .FirstOrDefaultAsync(m => m.id == id);
            if (sweetCategory == null)
            {
                return NotFound();
            }

            return View(sweetCategory);
        }

        // POST: SweetCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sweetCategories == null)
            {
                return Problem("Entity set 'SweetContext.sweetCategories'  is null.");
            }
            var sweetCategory = await _context.sweetCategories.FindAsync(id);
            if (sweetCategory != null)
            {
                _context.sweetCategories.Remove(sweetCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetCategoryExists(int id)
        {
          return (_context.sweetCategories?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
