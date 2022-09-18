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
    public class SweetProductsController : Controller
    {
        private readonly SweetContext _context;

        public SweetProductsController(SweetContext context)
        {
            _context = context;
        }

        // GET: SweetProducts
        public async Task<IActionResult> Index()
        {
            return _context.sweetProducts != null ? 
            View(await _context.sweetProducts.ToListAsync()) :
             Problem("Entity set 'SweetContext.sweetProducts'  is null.");
          
        }
        public ActionResult ProductList(int id)
        {
            return _context.sweetProducts != null ?
                        View(_context.sweetProducts.ToList()) :
                        Problem("Entity set 'SweetContext.sweetProducts'  is null.");
        }

        // GET: SweetProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sweetProducts == null)
            {
                return NotFound();
            }

            var sweetProduct = await _context.sweetProducts
                .FirstOrDefaultAsync(m => m.id == id);
            if (sweetProduct == null)
            {
                return NotFound();
            }

            return View(sweetProduct);
        }

        // GET: SweetProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SweetProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,CategID,price")] SweetProduct sweetProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweetProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sweetProduct);
        }

        // GET: SweetProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sweetProducts == null)
            {
                return NotFound();
            }

            var sweetProduct = await _context.sweetProducts.FindAsync(id);
            if (sweetProduct == null)
            {
                return NotFound();
            }
            return View(sweetProduct);
        }

        // POST: SweetProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,CategID,price")] SweetProduct sweetProduct)
        {
            if (id != sweetProduct.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweetProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetProductExists(sweetProduct.id))
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
            return View(sweetProduct);
        }

        // GET: SweetProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sweetProducts == null)
            {
                return NotFound();
            }

            var sweetProduct = await _context.sweetProducts
                .FirstOrDefaultAsync(m => m.id == id);
            if (sweetProduct == null)
            {
                return NotFound();
            }

            return View(sweetProduct);
        }

        // POST: SweetProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sweetProducts == null)
            {
                return Problem("Entity set 'SweetContext.sweetProducts'  is null.");
            }
            var sweetProduct = await _context.sweetProducts.FindAsync(id);
            if (sweetProduct != null)
            {
                _context.sweetProducts.Remove(sweetProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetProductExists(int id)
        {
          return (_context.sweetProducts?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
