using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSweetShop.Models;
using OnlineSweetShop1.Models;

namespace OnlineSweetShop1.Controllers
{
    [Authorize]
    public class AspnetusersController : Controller
    {
        private readonly SweetContext _context;
        public readonly IHttpContextAccessor _contextAccessor;

        public AspnetusersController(SweetContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        // GET: Aspnetusers
        public async Task<IActionResult> Index()
        {
              return _context.Aspnetusers != null ? 
                          View(await _context.Aspnetusers.ToListAsync()) :
                          Problem("Entity set 'SweetContext.Aspnetuser'  is null.");
        }

        // GET: Aspnetusers/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Aspnetusers == null)
            {
                return NotFound();
            }

            var aspnetuser = await _context.Aspnetusers
                .FirstOrDefaultAsync(m => m.id == id);
            if (aspnetuser == null)
            {
                return NotFound();
            }

            return View(aspnetuser);
        }

        // GET: Aspnetusers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aspnetusers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,firstname,middlename,lastname,gender,age,mobilenumber,address,city,district,state,zipcode,role")] Aspnetuser aspnetuser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspnetuser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspnetuser);
        }

        // GET: Aspnetusers/Edit/5.
        public async Task<IActionResult> Edit()
        {
            var UserID = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Aspnetuser user = _context.Aspnetusers.Single(e => e.id == UserID);

            //if (id == null || _context.Aspnetusers == null)
            // {
            //   return NotFound();
            // }

            //var aspnetuser = await _context.Aspnetusers.FindAsync(id);
            //if (aspnetuser == null)
            // {
            //return NotFound();
            //}
            //return View(aspnetuser);
            return Ok();
        }

        // POST: Aspnetusers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,firstname,middlename,lastname,gender,age,mobilenumber,address,city,district,state,zipcode,role")] Aspnetuser aspnetuser)
        {
            if (id != aspnetuser.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspnetuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspnetuserExists(aspnetuser.id))
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
            return View(aspnetuser);
        }

        // GET: Aspnetusers/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Aspnetusers == null)
            {
                return NotFound();
            }

            var aspnetuser = await _context.Aspnetusers
                .FirstOrDefaultAsync(m => m.id == id);
            if (aspnetuser == null)
            {
                return NotFound();
            }

            return View(aspnetuser);
        }

        // POST: Aspnetusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aspnetusers == null)
            {
                return Problem("Entity set 'SweetContext.Aspnetuser'  is null.");
            }
            var aspnetuser = await _context.Aspnetusers.FindAsync(id);
            if (aspnetuser != null)
            {
                _context.Aspnetusers.Remove(aspnetuser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspnetuserExists(string id)
        {
          return (_context.Aspnetusers?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
