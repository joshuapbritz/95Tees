using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using evan.ninetyfivetees.web.Models;

namespace evan.ninetyfivetees.web.Controllers
{
    public class merchController : Controller
    {
        private readonly ninetyfiveteesContext _context;

        public merchController(ninetyfiveteesContext context)
        {
            _context = context;
        }

        // GET: merch
        public async Task<IActionResult> Index()
        {
            var ninetyfiveteesContext = _context.Shirts.Include(s => s.Color).Include(s => s.Design).Include(s => s.Size);
            return View(await ninetyfiveteesContext.ToListAsync());
        }

        // GET: merch/Details/5
        [ActionName("view")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirts = await _context.Shirts
                .Include(s => s.Color)
                .Include(s => s.Design)
                .Include(s => s.Size)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shirts == null)
            {
                return NotFound();
            }

            return View("Details", shirts);
        }

        // GET: merch/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id");
            ViewData["DesignId"] = new SelectList(_context.Designs, "Id", "Id");
            ViewData["SizeId"] = new SelectList(_context.Size, "Id", "Id");
            return View();
        }

        // POST: merch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DesignId,SizeId,ColorId,Description,Title,Price")] Shirts shirts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shirts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id", shirts.ColorId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "Id", "Id", shirts.DesignId);
            ViewData["SizeId"] = new SelectList(_context.Size, "Id", "Id", shirts.SizeId);
            return View(shirts);
        }

        // GET: merch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirts = await _context.Shirts.SingleOrDefaultAsync(m => m.Id == id);
            if (shirts == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id", shirts.ColorId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "Id", "Id", shirts.DesignId);
            ViewData["SizeId"] = new SelectList(_context.Size, "Id", "Id", shirts.SizeId);
            return View(shirts);
        }

        // POST: merch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DesignId,SizeId,ColorId,Description,Title,Price")] Shirts shirts)
        {
            if (id != shirts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shirts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShirtsExists(shirts.Id))
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
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id", shirts.ColorId);
            ViewData["DesignId"] = new SelectList(_context.Designs, "Id", "Id", shirts.DesignId);
            ViewData["SizeId"] = new SelectList(_context.Size, "Id", "Id", shirts.SizeId);
            return View(shirts);
        }

        // GET: merch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirts = await _context.Shirts
                .Include(s => s.Color)
                .Include(s => s.Design)
                .Include(s => s.Size)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shirts == null)
            {
                return NotFound();
            }

            return View(shirts);
        }

        // POST: merch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shirts = await _context.Shirts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Shirts.Remove(shirts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShirtsExists(int id)
        {
            return _context.Shirts.Any(e => e.Id == id);
        }
    }
}
