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
    public class OffersController : Controller
    {
        private readonly SweetContext _context;

        public OffersController(SweetContext context)
        {
            _context = context;
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
            var sweetContext = _context.offers.Include(o => o.Product);
            return View(await sweetContext.ToListAsync());
        }
        public ActionResult Viewoffer(int id)
        {
            var sweetContext = _context.offers.Include(o => o.Product);
            return View(sweetContext.ToList());
        }
        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.offers == null)
            {
                return NotFound();
            }

            var offer = await _context.offers
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["prodID"] = new SelectList(_context.sweetProducts, "id", "name");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,prodID,AmountType,offer,sdate,edata")] Offer of)
        {
            if (ModelState.IsValid)
            {
                _context.Add(of);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["prodID"] = new SelectList(_context.sweetProducts, "id", "name", of.prodID);
            return View(of);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.offers == null)
            {
                return NotFound();
            }

            var offer = await _context.offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            ViewData["prodID"] = new SelectList(_context.sweetProducts, "id", "id", offer.prodID);
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,prodID,AmountType,offer,sdate,edata")] Offer offer)
        {
            if (id != offer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.id))
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
            ViewData["prodID"] = new SelectList(_context.sweetProducts, "id", "id", offer.prodID);
            return View(offer);
        }

        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.offers == null)
            {
                return NotFound();
            }

            var offer = await _context.offers
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.offers == null)
            {
                return Problem("Entity set 'SweetContext.offers'  is null.");
            }
            var offer = await _context.offers.FindAsync(id);
            if (offer != null)
            {
                _context.offers.Remove(offer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferExists(int id)
        {
          return (_context.offers?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
