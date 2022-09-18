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
    public class FeedBacksController : Controller
    {
        private readonly SweetContext _context;

        public FeedBacksController(SweetContext context)
        {
            _context = context;
        }

        // GET: FeedBacks
        public ActionResult FeedBack(int id)
        {
              return _context.feedbacks != null ? 
                          View(_context.feedbacks.ToList()) :
                          Problem("Entity set 'SweetContext.feedbacks'  is null.");
        }
        public async Task<IActionResult> Index()
        {
            return _context.feedbacks != null ?
                        View(await _context.feedbacks.ToListAsync()) :
                        Problem("Entity set 'SweetContext.feedbacks'  is null.");
        }

        // GET: FeedBacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.feedbacks == null)
            {
                return NotFound();
            }

            var feedBack = await _context.feedbacks
                .FirstOrDefaultAsync(m => m.id == id);
            if (feedBack == null)
            {
                return NotFound();
            }

            return View(feedBack);
        }

        // GET: FeedBacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeedBacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,comments")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedBack);
                await _context.SaveChangesAsync();
                TempData["message"] = "Thanks for your order";
                return RedirectToAction(nameof(Index));
            }
            return View(feedBack);
        }

        // GET: FeedBacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.feedbacks == null)
            {
                return NotFound();
            }

            var feedBack = await _context.feedbacks.FindAsync(id);
            if (feedBack == null)
            {
                return NotFound();
            }
            return View(feedBack);
        }

        // POST: FeedBacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,comments")] FeedBack feedBack)
        {
            if (id != feedBack.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedBack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedBackExists(feedBack.id))
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
            return View(feedBack);
        }

        // GET: FeedBacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.feedbacks == null)
            {
                return NotFound();
            }

            var feedBack = await _context.feedbacks
                .FirstOrDefaultAsync(m => m.id == id);
            if (feedBack == null)
            {
                return NotFound();
            }

            return View(feedBack);
        }

        // POST: FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.feedbacks == null)
            {
                return Problem("Entity set 'SweetContext.feedbacks'  is null.");
            }
            var feedBack = await _context.feedbacks.FindAsync(id);
            if (feedBack != null)
            {
                _context.feedbacks.Remove(feedBack);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedBackExists(int id)
        {
          return (_context.feedbacks?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
